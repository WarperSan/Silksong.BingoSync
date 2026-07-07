using BingoAPI.Goals;
using NJsonSchema;

namespace SchemaGenerator.Builders;

/// <summary>
/// Class responsible for creating a <see cref="JsonSchema"/> for a <see cref="GoalSet"/>
/// </summary>
internal sealed class GoalSetSchemaBuilder
{
	/// <summary>
	/// Creates a <see cref="JsonSchema"/> from the collected information
	/// </summary>
	public JsonSchema Build()
	{
		var conditionsSchema = new JsonSchema
		{
			OneOf =
			{
				new ConditionSchemaBuilder()
					.Action("owo")
					.RequiredParameter(
						"test",
						new JsonSchemaProperty
						{
							Type = JsonObjectType.Integer,
						}
					)
					.Build(),
				new ConditionSchemaBuilder()
					.Action("uwu")
					.RequiredParameter(
						"test5",
						new JsonSchemaProperty
						{
							Type = JsonObjectType.String,
						}
					)
					.OptionalParameter(
						"secret",
						new JsonSchemaProperty
						{
							Default = "20",
						}
					)
					.Build(),
			},
		};

		return CreateGoalSetSchema(conditionsSchema);
	}

	private static JsonSchema CreateGoalSetSchema(JsonSchema conditionsSchema)
	{
		const string GOALS_PROPERTY_NAME = "goals";

		var goalSchema = CreateGoalSchema(conditionsSchema);

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
				[GOALS_PROPERTY_NAME] = new JsonSchemaProperty
				{
					Type = JsonObjectType.Array,
					Description = "List of goals added by this set",
					Item = goalSchema,
					MinItems = 1,
					UniqueItems = true,
				},
			},
			RequiredProperties = { GOALS_PROPERTY_NAME },
			Definitions =
			{
				["conditions"] = conditionsSchema,
			},
		};

		return schema;
	}

	private static JsonSchema CreateGoalSchema(JsonSchema conditionsSchema)
	{
		const string NAME_PROPERTY_NAME = "name";
		const string CONDITION_PROPERTY_NAME = "condition";

		var schema = new JsonSchema
		{
			Type = JsonObjectType.Object,
			Properties =
			{
				[NAME_PROPERTY_NAME] = new JsonSchemaProperty
				{
					Type = JsonObjectType.String,
					Description = "Text to display for this goal",
				},
				[CONDITION_PROPERTY_NAME] = new JsonSchemaProperty
				{
					Type = JsonObjectType.Object,
					Description = "Condition to meet to complete this goal",
					Reference = conditionsSchema,
				},
			},
			RequiredProperties = { NAME_PROPERTY_NAME, CONDITION_PROPERTY_NAME },
		};

		return schema;
	}
}