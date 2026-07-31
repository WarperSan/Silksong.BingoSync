using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using BingoAPI.Conditions.Attributes;
using BingoAPI.Conditions.Factories;
using BingoAPI.Conditions.Interfaces;
using SchemaGenerator.Builders;

namespace SchemaGenerator.Helpers;

/// <summary>
/// Class helping with <see cref="IConditionFactory"/>
/// </summary>
internal static class FactoryHelper
{
	/// <summary>
	/// Attempts to create a <see cref="ConditionSchemaBuilder"/> from the given type
	/// </summary>
	public static bool TryCreateFromType(
		Type type,
		SchemaContext context,
		[NotNullWhen(true)] out ConditionSchemaBuilder? builder
	)
	{
		// Only allow concrete types
		if (type.IsAbstract || type.IsInterface)
		{
			builder = null;
			return false;
		}

		// Only allow who implements interface
		if (!typeof(IConditionFactory).IsAssignableFrom(type))
		{
			builder = null;
			return false;
		}

		var attribute = type.GetCustomAttribute<ConditionFactoryAttribute>();

		if (attribute == null)
		{
			builder = null;
			return false;
		}

		var parametersType = GetParametersType(type);

		builder = ConditionSchemaBuilder
			.CreateFromType(parametersType, context)
			.Action(attribute.Action);

		return true;
	}

	/// <summary>
	/// Gets the type used as the parameters
	/// </summary>
	private static Type GetParametersType(Type original)
	{
		var parametersType = original;

		if (
			TryGetGenericArguments(
				parametersType,
				typeof(ParameterizedConditionFactory<>),
				out var genericParameterTypes
			)
		)
			parametersType = genericParameterTypes[0];

		return parametersType;
	}

	/// <summary>
	/// Attempts to get the generic arguments from the given <paramref name="type"/>
	/// </summary>
	private static bool TryGetGenericArguments(
		Type type,
		Type genericType,
		[NotNullWhen(true)] out Type[]? genericArguments
	)
	{
		var currentType = type;

		while (currentType != null && currentType != typeof(object))
		{
			var nextType = currentType.IsGenericType
				? currentType.GetGenericTypeDefinition()
				: currentType;

			if (genericType != nextType)
			{
				currentType = nextType.BaseType;
				continue;
			}

			genericArguments = currentType.GetGenericArguments();
			return true;
		}

		genericArguments = null;
		return false;
	}
}
