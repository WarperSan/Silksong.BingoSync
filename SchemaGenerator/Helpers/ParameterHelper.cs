using NJsonSchema;

namespace SchemaGenerator.Helpers;

/// <summary>
/// Class helping with <see cref="JsonSchemaProperty"/>
/// </summary>
internal static class ParameterHelper
{
	/// <summary>
	/// Creates a <see cref="JsonSchemaProperty"/> limited to the values of <typeparamref name="T"/>
	/// </summary>
	public static JsonSchemaProperty CreateFromEnum<T>() where T : Enum
	{
		var property = new JsonSchemaProperty
		{
			Type = JsonObjectType.String,
		};

		foreach (var value in EnumHelper.GetValues<T>())
			property.Enumeration.Add(value);

		return property;
	}
}