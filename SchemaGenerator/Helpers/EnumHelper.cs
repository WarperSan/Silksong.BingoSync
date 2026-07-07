using System.Reflection;
using System.Runtime.Serialization;

namespace SchemaGenerator.Helpers;

/// <summary>
/// Class helping with <see cref="Enum"/>
/// </summary>
internal static class EnumHelper
{
	/// <summary>
	/// Gets all JSON values of the given <see cref="Enum"/>
	/// </summary>
	public static IEnumerable<string> GetValues<T>() where T : Enum
	{
		foreach (var member in typeof(T).GetFields())
		{
			if (member.FieldType != typeof(T))
				continue;

			var attribute = member.GetCustomAttribute<EnumMemberAttribute>();

			if (attribute == null)
				throw new InvalidOperationException($"The field '{member.Name}' has no '{nameof(EnumMemberAttribute)}' attribute.");

			if (!attribute.IsValueSetExplicitly)
				throw new InvalidOperationException($"The field '{member.Name}' must explicitly set a value.");

			if (attribute.Value == null)
				throw new NullReferenceException($"The field '{member.Name}' must have a value.");

			yield return attribute.Value;
		}
	}
}