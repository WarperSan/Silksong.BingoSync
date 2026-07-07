using BingoAPI.Goals;
using NJsonSchema;

namespace SchemaGenerator.Builders;

/// <summary>
/// Class responsible to create a <see cref="JsonSchema"/> for <see cref="GoalSet"/> 
/// </summary>
internal sealed class GoalSetSchemaBuilder
{
	/// <summary>
	/// Compiles the gathered information into a <see cref="JsonSchema"/>
	/// </summary>
	public JsonSchema Build()
	{
		var schema = new JsonSchema
		{
			Title = "Goals",
			Description = "Set of goals available",
			Type = JsonObjectType.Object,
			Properties =
			{
				["name"] = new JsonSchemaProperty
				{
					Description = "Name of the goal",
					Type = JsonObjectType.String,
				},
				["description"] = new JsonSchemaProperty
				{
					Description = "Description of the set",
					Type = JsonObjectType.String,
				},
			},
		};

		return schema;
	}
}