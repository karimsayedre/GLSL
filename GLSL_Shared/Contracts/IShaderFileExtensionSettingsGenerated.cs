
namespace DMS.GLSL.Contracts
{
	public interface IShaderFileExtensions
	{
		string AutoDetectShaderFileExtensions { get; }
		string ShaderHeaderFileExtensions { get; }

		string FragmentShaderFileExtensions { get; }

		string VertexShaderFileExtensions { get; }

		string GeometryShaderFileExtensions { get; }

		string ComputeShaderFileExtensions { get; }

		string TessellationControlShaderFileExtensions { get; }

		string TessellationEvaluationShaderFileExtensions { get; }

		string MeshShaderFileExtensions { get; }

		string TaskShaderFileExtensions { get; }

		string RayGenerationShaderFileExtensions { get; }

		string RayIntersectionShaderFileExtensions { get; }

		string RayMissShaderFileExtensions { get; }

		string RayAnyHitShaderFileExtensions { get; }

		string RayClosestHitShaderFileExtensions { get; }

		string RayCallableShaderFileExtensions { get; }
	}

	public interface IShaderStages
	{
		string FragmentShaderStages { get; }

		string VertexShaderStages { get; }

		string GeometryShaderStages { get; }

		string ComputeShaderStages { get; }

		string TessellationControlShaderStages { get; }

		string TessellationEvaluationShaderStages { get; }

		string MeshShaderStages { get; }

		string TaskShaderStages { get; }

		string RayGenerationShaderStages { get; }

		string RayIntersectionShaderStages { get; }

		string RayMissShaderStages { get; }

		string RayAnyHitShaderStages { get; }

		string RayClosestHitShaderStages { get; }

		string RayCallableShaderStages { get; }
	}
}
