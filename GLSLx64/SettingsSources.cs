using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DMS.GLSL.Contracts;
using Microsoft.Build.Framework.XamlTypes;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace GLSLx64
{
	[Serializable]
	// [Category("General Settings")]
	public class GeneralSettings : IUserKeywords
	{
		[Category("General")]
		[DisplayName("External Compiler Path")]
		[Description("Path to external compiler (without quotes).\nKeep empty to use the embedded compiler.")]
		public string ExternalCompilerExeFilePath { get; set; }

		[Category("General")]
		[DisplayName("Compiler Arguments")]
		[Description("Command line arguments for the external compiler executable.\n" +
		             "Can contain environment variables, like %USERPROFILE% and also the Visual Studio variable $(SolutionDir).\n" +
		             "A single argument that includes spaces must be surrounded by quotation marks, \n" +
		             "but those quotation marks are not carried through to the target application. \n" +
		             "In include quotation marks in the final parsed argument, triple-escape each mark.")]
		public string ExternalCompilerArguments { get; set; }

		[Category("General")]
		[DisplayName("Live Compiling")]
		[Description("Compile the shader code in the background and show resulting errors.")]
		public bool LiveCompiling { get; set; }

		[Category("General")]
		[DisplayName("Compile Delay (ms)")]
		[Description("Minimal delay between two compiles.")]
		public int CompileDelay { get; set; }

		[Category("General")]
		[DisplayName("Maximum Compile delay (ms)")]
		[Description("Maximum delay before aborting.")]
		public int MaxCompileDelay { get; set; }

		[Category("General")]
		[DisplayName("Expand includes")]
		[Description("Expand includes to support shader compilers which do not support the #include pragma.\n" +
		             "This option only works if include paths are absolute or relative to the current file")]
		public bool ExpandIncludes { get; set; }


		[Category("General")]
		[DisplayName("Print shader log")]
		[Description("Print the log of the shader compiler into the output pane and the log file")]
		public bool PrintShaderCompilerLog { get; set; }

		private string _userKeyWords1;
		private string _userKeyWords2;

		[Category("General")]
		[DisplayName("User key words 1")]
		[Description("Space separated list of user key words (used for coloring)")]
		public string UserKeyWords1
		{
			get => _userKeyWords1;
			set
			{
				_userKeyWords1 = value;
				userKeywordArray1 = ParseWords(value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(userKeywordArray1)));
			}
		}

		[Category("General")]
		[DisplayName("User key words 2")]
		[Description("Space separated list of user key words (used for coloring)")]
		public string UserKeyWords2
		{
			get => _userKeyWords2;
			set
			{
				_userKeyWords2 = value;
				userKeywordArray2 = ParseWords(value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(userKeywordArray2)));
			}
		}

		
		public event PropertyChangedEventHandler PropertyChanged;

		IEnumerable<string> IUserKeywords.UserKeywordArray1 => userKeywordArray1;
		IEnumerable<string> IUserKeywords.UserKeywordArray2 => userKeywordArray2;

		private IEnumerable<string> userKeywordArray1 = Enumerable.Empty<string>();
		private IEnumerable<string> userKeywordArray2 = Enumerable.Empty<string>();

		private static string[] ParseWords(string words)
		{
			char[] blanks = { ' ' };
			return words.Split(blanks, StringSplitOptions.RemoveEmptyEntries);
		}




	}

	//////////////////////////////////////////////////////////////////////////////////////////////////
	/// Extensions
	//////////////////////////////////////////////////////////////////////////////////////////////////
	public class ExtensionsSettings
	{
		[Category("File extensions")]
		[DisplayName("Auto detect shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string AutoDetectShaderFileExtensions { get; set; } = ".glsl";

		[Category("File extensions")]
		[DisplayName("Shader header file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string ShaderHeaderFileExtensions { get; set; } = ".glslh";

		[Category("File extensions")]
		[DisplayName("Vertex shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string VertexShaderFileExtensions { get; set; } = ".vert";

		[Category("File extensions")]
		[DisplayName("Geometry shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string GeometryShaderFileExtensions { get; set; } = ".geom";

		[Category("File extensions")]
		[DisplayName("Tessellation control shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string TessellationControlShaderFileExtensions { get; set; } = ".tesc";

		[Category("File extensions")]
		[DisplayName("Tessellation evaluation shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string TessellationEvaluationShaderFileExtensions { get; set; } = ".tese";

		[Category("File extensions")]
		[DisplayName("Fragment shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string FragmentShaderFileExtensions { get; set; } = ".frag";

		[Category("File extensions")]
		[DisplayName("Compute shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string ComputeShaderFileExtensions { get; set; } = ".comp";

		[Category("File extensions")]
		[DisplayName("Mesh shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string MeshShaderFileExtensions { get; set; } = ".mesh";

		[Category("File extensions")]
		[DisplayName("Task shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string TaskShaderFileExtensions { get; set; } = ".task";

		[Category("File extensions")]
		[DisplayName("Ray generation shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayGenerationShaderFileExtensions { get; set; } = ".rgen";

		[Category("File extensions")]
		[DisplayName("Ray intersection shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayIntersectionShaderFileExtensions { get; set; } = ".rint";

		[Category("File extensions")]
		[DisplayName("Ray miss shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayMissShaderFileExtensions { get; set; } = ".rmiss";

		[Category("File extensions")]
		[DisplayName("Ray any hit shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayAnyHitShaderFileExtensions { get; set; } = ".rahit";

		[Category("File extensions")]
		[DisplayName("Ray closest hit shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayClosestHitShaderFileExtensions { get; set; } = ".rchit";

		[Category("File extensions")]
		[DisplayName("Ray callable shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayCallableShaderFileExtensions { get; set; } = ".rcall";


	}

	//////////////////////////////////////////////////////////////////////////////////////////////////
	/// Stages
	//////////////////////////////////////////////////////////////////////////////////////////////////
	public class StagesSettings
	{
		[Category("Internal Stages")]
		[DisplayName("Vertex shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string VertexShaderStages { get; set; } = "vert";

		[Category("Internal Stages")]
		[DisplayName("Geometry shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string GeometryShaderStages { get; set; } = "geom";

		[Category("Internal Stages")]
		[DisplayName("Tessellation control shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string TessellationControlShaderStages { get; set; } = "tesc";

		[Category("Internal Stages")]
		[DisplayName("Tessellation evaluation shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string TessellationEvaluationShaderStages { get; set; } = "tese";
		[Category("Internal Stages")]
		[DisplayName("Fragment shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string FragmentShaderStages { get; set; } = "frag";

		[Category("Internal Stages")]
		[DisplayName("Compute shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string ComputeShaderStages { get; set; } = "comp";


		[Category("Internal Stages")]
		[DisplayName("Mesh shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string MeshShaderStages { get; set; } = "mesh";

		[Category("Internal Stages")]
		[DisplayName("Task shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string TaskShaderStages { get; set; } = "task";

		[Category("Internal Stages")]
		[DisplayName("Ray generation shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayGenerationShaderStages { get; set; } = "rgen";

		[Category("Internal Stages")]
		[DisplayName("Ray intersection shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayIntersectionShaderStages { get; set; } = "rint";

		[Category("Internal Stages")]
		[DisplayName("Ray miss shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayMissShaderStages { get; set; } = "rmiss";

		[Category("Internal Stages")]
		[DisplayName("Ray any hit shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayAnyHitShaderStages { get; set; } = "rahit";

		[Category("Internal Stages")]
		[DisplayName("Ray closest hit shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayClosestHitShaderStages { get; set; } = "rchit";

		[Category("Internal Stages")]
		[DisplayName("Ray callable shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string RayCallableShaderStages { get; set; } = "rcall";
	}

}
