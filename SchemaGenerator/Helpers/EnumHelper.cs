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
	public static IEnumerable<string> GetValues(Type type)
	{
		if (!typeof(Enum).IsAssignableFrom(type))
			throw new ArgumentException($"The type '{type.Name}' is not an enum.");

		foreach (var member in type.GetFields())
		{
			if (member.FieldType != type)
				continue;

			var attribute = member.GetCustomAttribute<EnumMemberAttribute>();

			if (attribute == null)
				throw new InvalidOperationException(
					$"The field '{member.Name}' has no '{nameof(EnumMemberAttribute)}' attribute."
				);

			if (!attribute.IsValueSetExplicitly)
				throw new InvalidOperationException(
					$"The field '{member.Name}' must explicitly set a value."
				);

			if (attribute.Value == null)
				throw new NullReferenceException($"The field '{member.Name}' must have a value.");

			yield return attribute.Value;
		}
	}
}
