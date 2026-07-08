using BingoAPI.Goals;
using NJsonSchema;

namespace SchemaGenerator.Builders;

/// <summary>
/// Class responsible for creating a <see cref="JsonSchema"/> for a <see cref="GoalSet"/>
/// </summary>
internal sealed class GoalSetSchemaBuilder
{
	#region Conditions

	private readonly List<JsonSchema> _conditions = [];

	public GoalSetSchemaBuilder AddCondition(ConditionSchemaBuilder builder)
	{
		_conditions.Add(builder.Build());
		return this;
	}

	#endregion

	/// <summary>
	/// Creates a <see cref="JsonSchema"/> from the collected information
	/// </summary>
	public JsonSchema Build()
	{
		var conditionsSchema = new JsonSchema();

		foreach (var condition in _conditions)
			conditionsSchema.OneOf.Add(condition);

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
				["goals"] = new JsonSchemaProperty
				{
					Type = JsonObjectType.Array,
					Description = "List of goals added by this set",
					Item = goalSchema,
					MinItems = 1,
					UniqueItems = true,
					IsRequired = true,
				},
			},
			Definitions =
			{
				["conditions"] = conditionsSchema,
			},
		};

		return schema;
	}

	private static JsonSchema CreateGoalSchema(JsonSchema conditionsSchema)
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
					IsRequired = true,
				},
				["condition"] = new JsonSchemaProperty
				{
					Type = JsonObjectType.Object,
					Description = "Condition to meet to complete this goal",
					Reference = conditionsSchema,
					IsRequired = true,
				},
			},
		};

		return schema;
	}
}