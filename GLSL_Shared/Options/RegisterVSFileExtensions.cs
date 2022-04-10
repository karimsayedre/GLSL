using DMS.GLSL.Contracts;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using DMS.GLSL.Errors;

namespace DMS.GLSL.Options
{
	[Export(typeof(RegisterVSFileExtensions))]
	internal sealed partial class RegisterVSFileExtensions
	{

		private static Dictionary<GLSL_Shared.Core.ShaderStages, List<string>> Stages = new Dictionary<GLSL_Shared.Core.ShaderStages, List<string>>();

		public static Dictionary<GLSL_Shared.Core.ShaderStages, List<string>> GetStages()
		{
			return Stages;
		}

		private static readonly IReadOnlyDictionary<string, GLSL_Shared.Core.ShaderStages> mappingContentTypeToShaderType = new Dictionary<string, GLSL_Shared.Core.ShaderStages>()
		{
			[ShaderContentTypes.Header] = GLSL_Shared.Core.ShaderStages.Header,
			[ShaderContentTypes.RayIntersection] = GLSL_Shared.Core.ShaderStages.RayIntersect,
			[ShaderContentTypes.RayGeneration] = GLSL_Shared.Core.ShaderStages.RayGen,
			[ShaderContentTypes.RayMiss] = GLSL_Shared.Core.ShaderStages.RayMiss,
			[ShaderContentTypes.RayAnyHit] = GLSL_Shared.Core.ShaderStages.RayAnyHit,
			[ShaderContentTypes.RayCallable] = GLSL_Shared.Core.ShaderStages.RayCallable,
			[ShaderContentTypes.RayClosestHit] = GLSL_Shared.Core.ShaderStages.RayClosestHit,
			[ShaderContentTypes.Mesh] = GLSL_Shared.Core.ShaderStages.Mesh,
			[ShaderContentTypes.Task] = GLSL_Shared.Core.ShaderStages.Task,
			[ShaderContentTypes.Fragment] = GLSL_Shared.Core.ShaderStages.Fragment,
			[ShaderContentTypes.Vertex] = GLSL_Shared.Core.ShaderStages.Vertex,
			[ShaderContentTypes.Geometry] = GLSL_Shared.Core.ShaderStages.Geometry,
			[ShaderContentTypes.TessellationControl] = GLSL_Shared.Core.ShaderStages.TessellationControl,
			[ShaderContentTypes.TessellationEvaluation] = GLSL_Shared.Core.ShaderStages.TessellationEvaluation,
			[ShaderContentTypes.Compute] = GLSL_Shared.Core.ShaderStages.Compute,
		};
		private static void RegisterStages(string sStages, string shaderContent)
		{
			var stages = sStages.Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
			
			List<string> fileExtensions = new List<string>(stages);
			Stages.Add(mappingContentTypeToShaderType[shaderContent], fileExtensions);
		}

		private static void RegisterFileExtensions(IFileExtensionRegistryService fileExtensionRegistry, string sExtensions, IContentType contentType, ILogger logger)
		{
			var extensions = sExtensions.Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

			foreach (string ext in extensions)
			{
				try
				{
					fileExtensionRegistry.RemoveFileExtension(ext);
					fileExtensionRegistry.AddFileExtension(ext, contentType);
				}
				catch (InvalidOperationException ioe)
				{
					var otherContentType = fileExtensionRegistry.GetContentTypeForExtension(ext);
					const string title = "GLSL language integration";
					var message = $"{title}:Extension '{ext}' is ignored because it is already registered " +
						$"with the content type '{otherContentType.TypeName}'. " +
						$"Please use a different extension on the {title} options page!" +
						$"Following is the detailed exception message {ioe}";
					logger.Log(message, true);
				}
			}
		}

		private static void ClearExts()
		{
			Stages.Clear();
		}
	}
}
