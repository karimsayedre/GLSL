using DMS.GLSL.Contracts;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using GLSL_Shared.Core;

namespace DMS.GLSL.Errors
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)] //default singleton behavior
    internal class ShaderCompiler
    {
        [ImportingConstructor]
        public ShaderCompiler(ICompilerSettings settings, ILogger logger)
        {
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        internal delegate void OnCompilationFinished(IEnumerable<GLSLhelper.ShaderLogLine> errorLog);

        internal void RequestCompile(string shaderCode, string sShaderType, OnCompilationFinished compilationFinishedHandler, string documentDir)
        {
            StartGlThreadOnce();
            while (compileRequests.TryTake(out _)) ; //remove pending compiles
            var data = new CompileData(shaderCode, sShaderType, compilationFinishedHandler, documentDir);
            compileRequests.TryAdd(data); //put compile on request list
        }

        private struct CompileData
        {
            public CompileData(string shaderCode, string shaderType, OnCompilationFinished compilationFinished, string documentDir)
            {
                ShaderCode = shaderCode;
                ShaderType = shaderType;
                CompilationFinished = compilationFinished;
                DocumentDir = documentDir;
            }

            public string ShaderCode { get; }
            public string ShaderType { get; }
            public OnCompilationFinished CompilationFinished { get; }
            public string DocumentDir { get; }
        }

        private static readonly IReadOnlyDictionary<string, ShaderStages> mappingContentTypeToShaderStage = new Dictionary<string, ShaderStages>()
        {
            [ShaderContentTypes.Header] = ShaderStages.Header,
            [ShaderContentTypes.RayIntersection] = ShaderStages.RayIntersect,
            [ShaderContentTypes.RayGeneration] = ShaderStages.RayGen,
            [ShaderContentTypes.RayMiss] = ShaderStages.RayMiss,
            [ShaderContentTypes.RayAnyHit] = ShaderStages.RayAnyHit,
            [ShaderContentTypes.RayCallable] = ShaderStages.RayCallable,
            [ShaderContentTypes.RayClosestHit] = ShaderStages.RayClosestHit,
            [ShaderContentTypes.Mesh] = ShaderStages.Mesh,
            [ShaderContentTypes.Task] = ShaderStages.Task,
            [ShaderContentTypes.Fragment] = ShaderStages.Fragment,
            [ShaderContentTypes.Vertex] = ShaderStages.Vertex,
            [ShaderContentTypes.Geometry] = ShaderStages.Geometry,
            [ShaderContentTypes.TessellationControl] = ShaderStages.TessellationControl,
            [ShaderContentTypes.TessellationEvaluation] = ShaderStages.TessellationEvaluation,
            [ShaderContentTypes.Compute] = ShaderStages.Compute,
        };


        private static readonly IReadOnlyDictionary<ShaderStages, string> mappingShaderStageToContentType = new Dictionary<ShaderStages, string>()
        {
            [ShaderStages.Header] = ShaderContentTypes.Header,
            [ShaderStages.RayIntersect] = ShaderContentTypes.RayIntersection,
            [ShaderStages.RayGen] = ShaderContentTypes.RayGeneration,
            [ShaderStages.RayMiss] = ShaderContentTypes.RayMiss,
            [ShaderStages.RayAnyHit] = ShaderContentTypes.RayAnyHit,
            [ShaderStages.RayCallable] = ShaderContentTypes.RayCallable,
            [ShaderStages.RayClosestHit] = ShaderContentTypes.RayClosestHit,
            [ShaderStages.Mesh] = ShaderContentTypes.Mesh,
            [ShaderStages.Task] = ShaderContentTypes.Task,
            [ShaderStages.Fragment] = ShaderContentTypes.Fragment,
            [ShaderStages.Vertex] = ShaderContentTypes.Vertex,
            [ShaderStages.Geometry] = ShaderContentTypes.Geometry,
            [ShaderStages.TessellationControl] = ShaderContentTypes.TessellationControl,
            [ShaderStages.TessellationEvaluation] = ShaderContentTypes.TessellationEvaluation,
            [ShaderStages.Compute] = ShaderContentTypes.Compute,
        };

        private Task taskGL;
        private readonly BlockingCollection<CompileData> compileRequests = new BlockingCollection<CompileData>();
        private readonly ICompilerSettings settings;
        private readonly ILogger logger;

        private void StartGlThreadOnce()
        {
            if (!(taskGL is null)) return;
            //start up GL task for doing shader compilations in background
            taskGL = Task.Factory.StartNew(TaskGlAction, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
        }

        private void TaskGlAction()
        {
            //create a game window for rendering context, until run is called it is invisible so no problem
            var context = new GameWindow(1, 1);
            while (!compileRequests.IsAddingCompleted)
            {
                var compileData = compileRequests.Take(); //block until compile requested
                var expandedCode = ExpandedCode(compileData.ShaderCode, compileData.DocumentDir, settings);
                var log = Compile(expandedCode, compileData.ShaderType, logger, settings);
                var errorLog = new GLSLhelper.ShaderLogParser(log);
                if (!string.IsNullOrWhiteSpace(log) && settings.PrintShaderCompilerLog)
                {
                    logger.Log($"Dumping shader log:\n{log}\n", false);
                }
                compileData.CompilationFinished?.Invoke(errorLog.Lines);
            }
        }

        private static Dictionary<ShaderStages, string> AutoDetectShaderContentType(string shaderCode, Dictionary<ShaderStages, List<string>> potentialStages)
        {

            List<Tuple<int, ShaderStages>> indicesOfStages = ShaderTypeDetector.AutoDetectFromCode(shaderCode, potentialStages);

            Dictionary<ShaderStages, string> result = new Dictionary<ShaderStages, string>();


            if (indicesOfStages.Count > 1)
            {
                // Get first stage
                int index = indicesOfStages[0].Item1;
                ShaderStages stage = indicesOfStages[0].Item2;

                string stageStr = shaderCode.Substring(0, indicesOfStages[1].Item1);
                int lineCount = stageStr.Substring(0, index).Split('\n').Length;

                int endOfFirstLine = stageStr.IndexOf('\n', lineCount + 1);
                stageStr = stageStr.Insert(endOfFirstLine, "\r#extension GL_GOOGLE_include_directive : enable");
                lineCount += stageStr.Substring(index).Split('\n').Length - 1;
                result.Add(stage, stageStr);

                string skippedLines = string.Empty;

                for (int i = 1; i < indicesOfStages.Count - 1; ++i)
                {
                    index = indicesOfStages[i].Item1;
                    stage = indicesOfStages[i].Item2;

                    for (int j = 0; j < lineCount; ++j)
                        skippedLines.Insert(0, "\n");

                    stageStr = shaderCode.Substring(index, indicesOfStages[i + 1].Item1 - index);
                    endOfFirstLine = stageStr.IndexOf('\n');
                    stageStr = stageStr.Insert(endOfFirstLine, "\r#extension GL_GOOGLE_include_directive : enable");

                    lineCount += stageStr.Split('\n').Length - 1;

                    result.Add(stage, skippedLines + stageStr);
                }

                index = indicesOfStages[indicesOfStages.Count - 1].Item1;
                stage = indicesOfStages[indicesOfStages.Count - 1].Item2;

                stageStr = shaderCode.Substring(index);
                endOfFirstLine = stageStr.IndexOf('\n');
                stageStr = stageStr.Insert(endOfFirstLine, "\r#extension GL_GOOGLE_include_directive : enable");


                skippedLines = "";
                for (int j = 0; j < lineCount - 1; ++j)
                    skippedLines += "\n";

                result.Add(stage, skippedLines + stageStr);
            }
            else
            {
                int endOfFirstLine = shaderCode.IndexOf('\n', indicesOfStages[0].Item1 + 1);
                if (endOfFirstLine != -1)
                    shaderCode = shaderCode.Insert(endOfFirstLine, "\r#extension GL_GOOGLE_include_directive : enable");

                result.Add(indicesOfStages[0].Item2, shaderCode);
            }

            return result;
        }

        private static string ExpandedCode(string shaderCode, string shaderFileDir, ICompilerSettings settings, HashSet<string> includedFiles = null)
        {
            if (includedFiles is null)
            {
                includedFiles = new HashSet<string>();
            }

            string SpecialCommentReplacement(string code, string specialComment)
            {
                var lines = code.Split(new[] { '\n' }, StringSplitOptions.None); //if UNIX style line endings still working so do not use Envirnoment.NewLine
                for (int i = 0; i < lines.Length; ++i)
                {
                    var index = lines[i].IndexOf(specialComment); // search for special comment
                    if (-1 != index)
                    {
                        lines[i] = lines[i].Substring(index + specialComment.Length); // remove everything before special comment
                    }
                }
                return string.Join("\n", lines);
            }

            string GetIncludeCode(string includeName)
            {
                var includeFileName = Path.GetFullPath(Path.Combine(shaderFileDir, includeName));

                if (File.Exists(includeFileName))
                {
                    var includeCode = File.ReadAllText(includeFileName);

                    if (includedFiles.Contains(includeFileName))
                    {
                        return includeCode;
                    }
                    includedFiles.Add(includeFileName);

                    return ExpandedCode(includeCode, Path.GetDirectoryName(includeFileName), settings, includedFiles: includedFiles);
                }
                return $"#error include file '{includeName}' not found";
            }

            shaderCode = SpecialCommentReplacement(shaderCode, "//!");
            if (includedFiles.Count == 0)
            {
                shaderCode = SpecialCommentReplacement(shaderCode, "//?");
            }
            if (settings.ExpandIncludes)
            {
                return GLSLhelper.Transformation.ExpandIncludes(shaderCode, GetIncludeCode);
            }
            else
            {
                return shaderCode;
            }
        }

        private static string Compile(string shaderCode, string shaderContentType, ILogger logger, ICompilerSettings settings)
        {
            Dictionary<ShaderStages, string> shaderStageStrs;
            if (ShaderContentTypes.AutoDetect == shaderContentType)
            {
                shaderStageStrs = AutoDetectShaderContentType(shaderCode, Options.RegisterVSFileExtensions.GetStages());
                string stages = string.Empty;
                foreach (var stage in shaderStageStrs.Keys)
                    stages += stage + ", ";
                logger.Log($"Auto detecting shader stages to '{stages}'", true);
            }
            else
            {
                if (shaderContentType == ShaderContentTypes.Header)
                {
                    // Wrap header in a shader, as a hack it is a fragment shader.
                    shaderCode = shaderCode.Insert(0, "#version 450\n#extension GL_GOOGLE_include_directive : enable\n#line 1\n");
                    shaderCode = shaderCode.Insert(shaderCode.Length, "\nvoid main() {}");
                }

                shaderStageStrs = new Dictionary<ShaderStages, string>
                {
                    { mappingContentTypeToShaderStage[shaderContentType], shaderCode }
                };
            }

            string output = string.Empty;
            if (string.IsNullOrWhiteSpace(settings.ExternalCompilerExeFilePath))
            {
                foreach (var stage in shaderStageStrs)
                {
                    output = string.Concat(output, CompileOnGPU(stage.Value, mappingShaderStageToContentType[stage.Key], logger));
                }
            }
            else
            {
                foreach (var stage in shaderStageStrs)
                {
                    output = string.Concat(output, CompileExternal(stage.Value, mappingShaderStageToContentType[stage.Key], logger, settings));
                }
            }

            return output;
        }

        private static string CompileExternal(string shaderCode, string shaderContentType, ILogger logger, ICompilerSettings settings)
        {
            //create temp shader file for external compiler
            var tempPath = Path.GetTempPath();
            var shaderFileName = Path.Combine(tempPath, $"shader{ShaderContentTypes.DefaultFileExtension(shaderContentType)}");
            try
            {
                File.WriteAllText(shaderFileName, shaderCode);
                using (var process = new Process())
                {
                    process.StartInfo.FileName = VsExpand.EnvironmentVariables(settings.ExternalCompilerExeFilePath);
                    var arguments = VsExpand.EnvironmentVariables(settings.ExternalCompilerArguments);

                    process.StartInfo.Arguments = $"{arguments} \"{shaderFileName}\""; //arguments
                    process.StartInfo.WorkingDirectory = tempPath;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.CreateNoWindow = true; //do not display a windows
                    logger.Log($"Using external compiler '{settings.ExternalCompilerExeFilePath}' with arguments '{arguments}' on temporal shader file '{shaderFileName}'", true);
                    process.Start();
                    if (!process.WaitForExit(10000))
                    {
                        logger.Log("External compiler did take more than 10 seconds to finish. Aborting!", true);
                    }
                    return process.StandardOutput.ReadToEnd() + process.StandardError.ReadToEnd(); //The output result
                }
            }
            catch (Exception e)
            {
                var message = "Error executing external compiler with message\n" + e.ToString();
                logger.Log(message, true);
                return string.Empty;
            }
        }

        private static readonly IReadOnlyDictionary<string, ShaderType> mappingContentTypeToOpenGL = new Dictionary<string, ShaderType>()
        {
            [ShaderContentTypes.Header] = ShaderType.FragmentShader, //Hack to make it compile
            [ShaderContentTypes.Fragment] = ShaderType.FragmentShader,
            [ShaderContentTypes.Vertex] = ShaderType.VertexShader,
            [ShaderContentTypes.Geometry] = ShaderType.GeometryShader,
            [ShaderContentTypes.TessellationControl] = ShaderType.TessControlShader,
            [ShaderContentTypes.TessellationEvaluation] = ShaderType.TessEvaluationShader,
            [ShaderContentTypes.Compute] = ShaderType.ComputeShader,
        };

        [HandleProcessCorruptedStateExceptions]
        private static string CompileOnGPU(string shaderCode, string shaderType, ILogger logger)
        {
            // detect shader type
            if (!mappingContentTypeToOpenGL.TryGetValue(shaderType, out ShaderType glShaderType))
            {
                logger.Log($"Unsupported shader type '{shaderType}' by OpenTK shader compiler. Use an external compiler", true);
            }
            try
            {
                var id = GL.CreateShader(glShaderType);
                if (0 == id)
                {
                    var message = $"Could not create {shaderType} instance. Are your drivers up-to-date?";
                    logger.Log(message, true);
                    return message;
                }
                else
                {
                    GL.ShaderSource(id, shaderCode);
                    GL.CompileShader(id);
                    GL.GetShader(id, ShaderParameter.CompileStatus, out int status_code);
                    string log = string.Empty;
                    if (1 != status_code)
                    {
                        log = GL.GetShaderInfoLog(id);
                    }
                    GL.DeleteShader(id);
                    return log;
                }
            }
            catch (AccessViolationException)
            {
                return "(1 1):ERROR: OpenGL shader compiler has crashed";
            }
        }
    }
}
