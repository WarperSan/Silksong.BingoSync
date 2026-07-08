using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Newtonsoft.Json;
using NJsonSchema;

namespace SchemaGenerator.Helpers;

/// <summary>
/// Class helping with <see cref="JsonSchemaProperty"/>
/// </summary>
internal static class ParameterHelper
{
	/// <summary>
	/// Attempts to create a <see cref="JsonSchemaProperty"/> from the given <see cref="MemberInfo"/>
	/// </summary>
	public static bool TryCreateFromMember(MemberInfo member, [NotNullWhen(true)] out JsonSchemaProperty? schema)
	{
		var dataType = member switch
		{
			PropertyInfo propertyInfo => propertyInfo.PropertyType,
			FieldInfo fieldInfo       => fieldInfo.FieldType,
			_                         => null,
		};

		if (dataType is null)
		{
			schema = null;
			return false;
		}

		schema = CreateFromType(dataType);
		schema.IsRequired = member.GetCustomAttribute<JsonRequiredAttribute>() != null;
		return true;
	}

	/// <summary>
	/// Creates a <see cref="JsonSchemaProperty"/> from the given <see cref="Type"/>
	/// </summary>
	private static JsonSchemaProperty CreateFromType(Type type)
	{
		JsonSchemaProperty schema;

		if (type.IsEnum)
			schema = CreateFromEnum(type);
		else if (type.IsArray)
			schema = CreateFromArray(type);
		else
			schema = new JsonSchemaProperty();

		return schema;
	}

	/// <summary>
	/// Creates a <see cref="JsonSchemaProperty"/> limited to the values of the given type
	/// </summary>
	private static JsonSchemaProperty CreateFromEnum(Type type)
	{
		var property = new JsonSchemaProperty
		{
			Type = JsonObjectType.String,
		};

		foreach (var value in EnumHelper.GetValues(type))
			property.Enumeration.Add(value);

		return property;
	}

	/// <summary>
	/// Creates a <see cref="JsonSchemaProperty"/> for the given array type
	/// </summary>
	private static JsonSchemaProperty CreateFromArray(Type type)
	{
		var elementType = type.GetElementType();

		if (elementType is null)
			throw new ArgumentNullException(nameof(type));

		var property = new JsonSchemaProperty
		{
			Type = JsonObjectType.Array,
			Item = CreateFromType(elementType),
		};

		Console.WriteLine(elementType);

		return property;
	}
}