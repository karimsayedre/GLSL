using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace GLSL_Shared.Core
{
	[Flags]
	public enum ShaderStages
	{
		None = 0,
		Vertex = 1,
		Fragment = 2,
		Geometry = 4,
		TessellationEvaluation = 8,
		TessellationControl = 16,
		Compute = 32,
		Task = 64,
		Mesh = 128,
		RayGen = 256,
		RayIntersect = 512,
		RayAnyHit = 1024,
		RayClosestHit = 2048,
		RayMiss = 4096,
		RayCallable = 8192,
		Header = 16384,

	}

	public class ShaderTypeDetector
	{

		internal static readonly Regex TessellationControlVertices = new Regex("layout\\s*\\(\\s*vertices");


		public static List<Tuple<int, ShaderStages>> AutoDetectFromCode(string shaderCode, Dictionary<ShaderStages, List<string>> potentialStages)
		{
			List<Tuple<int, ShaderStages>> result = new List<Tuple<int, ShaderStages>>();

			foreach (var ext in potentialStages)
			{
				foreach (var v in ext.Value)
				{
					Match match = Regex.Match(shaderCode, $@"#\s*version\s+\d{{3,}}(\s+\w+|)\s*\r*\n\s*#\s*pragma\s+stage\s*:\s*{v}\s*\r*\n");
					if (match.Success)
					{
					result.Add(new Tuple<int, ShaderStages>(match.Index, ext.Key));
						break;
					}
				}
			}

			if (result.Count > 0)
			{
				result.OrderBy(o => o.Item1);
				return result;
			}

			if (shaderCode.Contains("EmitVertex"))
			{
				result.Add(new Tuple<int, ShaderStages>(0, ShaderStages.Geometry));
			}

			if (shaderCode.Contains("local_size_"))
			{
				result.Add(new Tuple<int, ShaderStages>(0, ShaderStages.Compute));
			}

			if (TessellationControlVertices.IsMatch(shaderCode))
			{
				result.Add(new Tuple<int, ShaderStages>(0, ShaderStages.TessellationControl));
			}

			if (shaderCode.Contains("gl_TessCoord"))
			{
				result.Add(new Tuple<int, ShaderStages>(0, ShaderStages.TessellationEvaluation));
			}

			if (shaderCode.Contains("gl_Position"))
			{
				result.Add(new Tuple<int, ShaderStages>(0, ShaderStages.Vertex));
			}
			result.Add(new Tuple<int, ShaderStages>(0, ShaderStages.Fragment));

			return result;
		}

	}
}
