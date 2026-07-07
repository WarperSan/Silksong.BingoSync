using BingoAPI.Conditions;
using Json.Schema;

namespace SchemaGenerator.Builders;

/// <summary>
/// Class responsible to create a <see cref="JsonSchemaBuilder"/> for <see cref="ICondition"/> 
/// </summary>
internal sealed class ConditionSchemaBuilder
{
	/// <summary>
	/// Compiles the gathered information into a <see cref="JsonSchemaBuilder"/>
	/// </summary>
	public JsonSchemaBuilder Prepare()
	{
		return new JsonSchemaBuilder();
	}
}