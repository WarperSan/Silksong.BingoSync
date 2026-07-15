using System.ComponentModel;
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
	public static bool TryCreateFromMember(
		MemberInfo                                  member,
		SchemaContext                               context,
		[NotNullWhen(true)] out JsonSchemaProperty? schema
	)
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

		schema = CreateFromType(dataType, context);
		schema.IsRequired = member.GetCustomAttribute<JsonRequiredAttribute>() != null;

		schema.Default = member.GetCustomAttribute<DefaultValueAttribute>()?.Value;
		schema.Description = member.GetCustomAttribute<DescriptionAttribute>()?.Description;

		return true;
	}

	/// <summary>
	/// Creates a <see cref="JsonSchemaProperty"/> from the given <see cref="Type"/>
	/// </summary>
	private static JsonSchemaProperty CreateFromType(Type type, SchemaContext context)
	{
		JsonSchemaProperty schema;

		if (type.IsEnum)
			schema = CreateFromEnum(type);
		else if (type.IsArray)
			schema = CreateFromArray(type, context);
		else if (type.IsPrimitive)
			schema = CreateFromPrimitive(type);
		else if (context.TryGetSchema(type, out var referenceSchema))
		{
			schema = new JsonSchemaProperty
			{
				Reference = referenceSchema,
			};
		} else
			throw new NotImplementedException($"Type '{type}' is not implemented yet.");

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
	private static JsonSchemaProperty CreateFromArray(Type type, SchemaContext context)
	{
		var elementType = type.GetElementType();

		if (elementType is null)
			throw new ArgumentException($"Type '{type}' has no element type.", nameof(type));

		var property = new JsonSchemaProperty
		{
			Type = JsonObjectType.Array,
			Item = CreateFromType(elementType, context),
		};

		return property;
	}

	/// <summary>
	/// Creates a <see cref="JsonSchemaProperty"/> for the given primitive type
	/// </summary>
	private static JsonSchemaProperty CreateFromPrimitive(Type type)
	{
		JsonObjectType objectType;

		if (type == typeof(int) || type == typeof(uint))
			objectType = JsonObjectType.Integer;
		else if (type == typeof(bool))
			objectType = JsonObjectType.Boolean;
		else if (type == typeof(string))
			objectType = JsonObjectType.String;
		else
			objectType = JsonObjectType.None;

		return new JsonSchemaProperty
		{
			Type = objectType,
		};
	}
}