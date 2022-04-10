
namespace DMS.GLSL.Options
{
	using DMS.GLSL.Contracts;
	using DMS.GLSL.Errors;
	using Microsoft.VisualStudio.Utilities;
	using System.ComponentModel.Composition;

	internal sealed partial class RegisterVSFileExtensions
	{
		[ImportingConstructor]
		public RegisterVSFileExtensions(IContentTypeRegistryService contentTypeRegistry, IFileExtensionRegistryService fileExtensionRegistry, ILogger logger, IShaderFileExtensions settings, IShaderStages stageSettings)
		{
			if (contentTypeRegistry is null)
			{
				throw new System.ArgumentNullException(nameof(contentTypeRegistry));
			}

			if (fileExtensionRegistry is null)
			{
				throw new System.ArgumentNullException(nameof(fileExtensionRegistry));
			}

			if (logger is null)
			{
				throw new System.ArgumentNullException(nameof(logger));
			}

			if (settings is null)
			{
				throw new System.ArgumentNullException(nameof(settings));
			}

			void Register(string sExtensions, string contentType)
			{
				RegisterFileExtensions(fileExtensionRegistry, sExtensions, contentTypeRegistry.GetContentType(contentType), logger);
			}

			ClearExts();

			Register(settings.AutoDetectShaderFileExtensions, ShaderContentTypes.AutoDetect);
			Register(settings.ShaderHeaderFileExtensions, ShaderContentTypes.Header);
			Register(settings.FragmentShaderFileExtensions, ShaderContentTypes.Fragment);
			Register(settings.VertexShaderFileExtensions, ShaderContentTypes.Vertex);
			Register(settings.GeometryShaderFileExtensions, ShaderContentTypes.Geometry);
			Register(settings.ComputeShaderFileExtensions, ShaderContentTypes.Compute);
			Register(settings.TessellationControlShaderFileExtensions, ShaderContentTypes.TessellationControl);
			Register(settings.TessellationEvaluationShaderFileExtensions, ShaderContentTypes.TessellationEvaluation);
			Register(settings.MeshShaderFileExtensions, ShaderContentTypes.Mesh);
			Register(settings.TaskShaderFileExtensions, ShaderContentTypes.Task);
			Register(settings.RayGenerationShaderFileExtensions, ShaderContentTypes.RayGeneration);
			Register(settings.RayIntersectionShaderFileExtensions, ShaderContentTypes.RayIntersection);
			Register(settings.RayMissShaderFileExtensions, ShaderContentTypes.RayMiss);
			Register(settings.RayAnyHitShaderFileExtensions, ShaderContentTypes.RayAnyHit);
			Register(settings.RayClosestHitShaderFileExtensions, ShaderContentTypes.RayClosestHit);
			Register(settings.RayCallableShaderFileExtensions, ShaderContentTypes.RayCallable);

			RegisterStages(stageSettings.VertexShaderStages, ShaderContentTypes.Vertex);
			RegisterStages(stageSettings.TessellationControlShaderStages, ShaderContentTypes.TessellationControl);
			RegisterStages(stageSettings.TessellationEvaluationShaderStages, ShaderContentTypes.TessellationEvaluation);
			RegisterStages(stageSettings.GeometryShaderStages, ShaderContentTypes.Geometry);
			RegisterStages(stageSettings.FragmentShaderStages, ShaderContentTypes.Fragment);
			RegisterStages(stageSettings.ComputeShaderStages, ShaderContentTypes.Compute);
			RegisterStages(stageSettings.MeshShaderStages, ShaderContentTypes.Mesh);
			RegisterStages(stageSettings.TaskShaderStages, ShaderContentTypes.Task);
			RegisterStages(stageSettings.RayGenerationShaderStages, ShaderContentTypes.RayGeneration);
			RegisterStages(stageSettings.RayClosestHitShaderStages, ShaderContentTypes.RayClosestHit);
			RegisterStages(stageSettings.RayMissShaderStages, ShaderContentTypes.RayMiss);
			RegisterStages(stageSettings.RayIntersectionShaderStages, ShaderContentTypes.RayIntersection);
			RegisterStages(stageSettings.RayAnyHitShaderStages, ShaderContentTypes.RayAnyHit);
			RegisterStages(stageSettings.RayCallableShaderStages, ShaderContentTypes.RayCallable);

		}
	}
}
