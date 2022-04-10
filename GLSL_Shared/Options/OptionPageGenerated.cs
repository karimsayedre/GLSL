
namespace DMS.GLSL.Options
{
	using DMS.GLSL.Contracts;
	using Microsoft.VisualStudio.Shell;
	using System.ComponentModel;

	public partial class OptionPage : DialogPage, IShaderFileExtensions, IShaderStages
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
		[DisplayName("Fragment shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string FragmentShaderFileExtensions { get; set; } = ".frag";

		[Category("File extensions")]
		[DisplayName("Vertex shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string VertexShaderFileExtensions { get; set; } = ".vert";

		[Category("File extensions")]
		[DisplayName("Geometry shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string GeometryShaderFileExtensions { get; set; } = ".geom";

		[Category("File extensions")]
		[DisplayName("Compute shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string ComputeShaderFileExtensions { get; set; } = ".comp";

		[Category("File extensions")]
		[DisplayName("Tessellation control shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string TessellationControlShaderFileExtensions { get; set; } = ".tesc";

		[Category("File extensions")]
		[DisplayName("Tessellation evaluation shader type file extensions")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string TessellationEvaluationShaderFileExtensions { get; set; } = ".tese";

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



		//////////////////////////////////////////////////////////////////////////////////////////////////
		/// Stages
		//////////////////////////////////////////////////////////////////////////////////////////////////

		[Category("Internal Stages")]
		[DisplayName("Fragment shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string FragmentShaderStages { get; set; } = "frag";

		[Category("Internal Stages")]
		[DisplayName("Vertex shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string VertexShaderStages { get; set; } = "vert";

		[Category("Internal Stages")]
		[DisplayName("Geometry shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string GeometryShaderStages { get; set; } = "geom";

		[Category("Internal Stages")]
		[DisplayName("Compute shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string ComputeShaderStages { get; set; } = "comp";

		[Category("Internal Stages")]
		[DisplayName("Tessellation control shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string TessellationControlShaderStages { get; set; } = "tesc";

		[Category("Internal Stages")]
		[DisplayName("Tessellation evaluation shader stage")]
		[Description("Space or semicolon separated list of extensions that will receive syntax coloring")]
		public string TessellationEvaluationShaderStages { get; set; } = "tese";

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
