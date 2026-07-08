using System.Diagnostics.CodeAnalysis;
using NJsonSchema;

namespace SchemaGenerator;

/// <summary>
/// Class holding information related to the context while creating a <see cref="JsonSchema"/>
/// </summary>
internal sealed class SchemaContext
{
	private readonly Dictionary<Type, JsonSchema> _schemaPerType = new();

	/// <summary>
	/// Adds the given <see cref="JsonSchema"/> under the given <typeparamref name="T"/>
	/// </summary>
	public void AddSchema<T>(JsonSchema schema) => _schemaPerType.Add(typeof(T), schema);
	
	/// <summary>
	/// Attempts to get the schema under the given <see cref="Type"/>
	/// </summary>
	public bool TryGetSchema(Type type, [NotNullWhen(true)] out JsonSchema? schema) => _schemaPerType.TryGetValue(type, out schema);
}