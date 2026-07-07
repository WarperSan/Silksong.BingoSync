using NJsonSchema;

namespace SchemaGenerator.Builders;

/// <summary>
/// Class responsible for creating a <see cref="JsonSchema"/>
/// </summary>
internal sealed class GoalSetSchemaBuilder
{
	public JsonSchema Build()
	{
		var goalSchema = CreateGoalSchema();

		var schema = new JsonSchema
		{
			Title = "Goals",
			Description = "Set of goals available",
			Type = JsonObjectType.Object,
			Properties =
			{
				["name"] = new JsonSchemaProperty
				{
					Type = JsonObjectType.String,
					Description = "Name of the goal",
				},
				["description"] = new JsonSchemaProperty
				{
					Type = JsonObjectType.String,
					Description = "Description of the set",
				},
				["goals"] = new JsonSchemaProperty
				{
					Type = JsonObjectType.Array,
					Description = "List of goals added by this set",
					Item = goalSchema,
					MinItems = 1,
					UniqueItems = true,
				},
			},
			RequiredProperties = { "goals" },
		};

		return schema;
	}

	private static JsonSchema CreateGoalSchema()
	{
		var schema = new JsonSchema
		{
			Type = JsonObjectType.Object,
			Properties =
			{
				["name"] = new JsonSchemaProperty
				{
					Type = JsonObjectType.String,
					Description = "Text to display for this goal",
				},
				["condition"] = new JsonSchemaProperty
				{
					Type = JsonObjectType.Object,
					Description = "Condition to meet to complete this goal",
				},
			},
			RequiredProperties = { "name", "condition" },
		};

		return schema;
	}
}