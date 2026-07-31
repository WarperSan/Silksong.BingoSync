using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using BingoAPI.Conditions.Attributes;
using BingoAPI.Conditions.Interfaces;
using SchemaGenerator.Builders;

namespace SchemaGenerator.Helpers;

/// <summary>
/// Class helping with <see cref="ICondition"/>
/// </summary>
internal static class ConditionHelper
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
		if (!typeof(ICondition).IsAssignableFrom(type))
		{
			builder = null;
			return false;
		}

		var attribute = type.GetCustomAttribute<ConditionAttribute>();

		if (attribute == null)
		{
			builder = null;
			return false;
		}

		builder = ConditionSchemaBuilder.CreateFromType(type, context).Action(attribute.Action);

		return true;
	}
}
