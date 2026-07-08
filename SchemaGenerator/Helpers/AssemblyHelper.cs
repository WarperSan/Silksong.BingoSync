using System.Reflection;

namespace SchemaGenerator.Helpers;

/// <summary>
/// Class helping with <see cref="Assembly"/>
/// </summary>
internal static class AssemblyHelper
{
	/// <summary>
	/// Gets all assemblies referenced from the given <see cref="Type"/>
	/// </summary>
	public static IEnumerable<Assembly> GetReferencedAssemblies(Type type)
	{
		var visited = new HashSet<string>();
		var toProcess = new Queue<Assembly?>();
		toProcess.Enqueue(Assembly.GetAssembly(type));

		while (toProcess.Count > 0)
		{
			var asm = toProcess.Dequeue();

			if (asm == null)
				continue;

			if (asm.FullName != null && !visited.Add(asm.FullName))
				continue;

			yield return asm;

			foreach (var refName in asm.GetReferencedAssemblies())
			{
				try
				{
					var refAsm = Assembly.Load(refName);
					toProcess.Enqueue(refAsm);
				}
				catch (Exception e)
				{
					Console.WriteLine($"Could not load {refName.FullName}: {e.Message}");
				}
			}
		}
	}
}