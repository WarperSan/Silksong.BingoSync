using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace SchemaGenerator.Helpers;

/// <summary>
/// Class helping with <see cref="Type"/>
/// </summary>
internal static class TypeHelper
{
	/// <summary>
	/// Checks if the given <see cref="Type"/> is a <see cref="IEnumerable"/>
	/// </summary>
	public static bool IsEnumerable(Type type)
	{
		if (type.IsArray)
			return true;

		var interfaces = type.GetInterfaces();

		return interfaces.Any(i =>
			i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)
		);
	}

	/// <summary>
	/// Attempts to get the type of the item from the given type
	/// </summary>
	public static bool TryGetItemType(Type type, [NotNullWhen(true)] out Type? itemType)
	{
		if (type.IsArray)
		{
			itemType = type.GetElementType();
			return itemType != null;
		}

		if (type.IsGenericType)
		{
			itemType = type.GetGenericArguments().FirstOrDefault();
			return itemType != null;
		}

		itemType = null;
		return false;
	}
}
