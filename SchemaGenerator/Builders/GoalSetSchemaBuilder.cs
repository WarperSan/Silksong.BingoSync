using BingoAPI.Conditions;
using BingoAPI.Goals;
using NJsonSchema;

namespace SchemaGenerator.Builders;

/// <summary>
/// Class responsible to create a <see cref="JsonSchema"/> for <see cref="GoalSet"/> 
/// </summary>
internal sealed class GoalSetSchemaBuilder
{
	#region Conditions

	/// <summary>
	/// Compiles the gathered information about <see cref="ICondition"/> into a <see cref="JsonSchema"/>
	/// </summary>
	private JsonSchema BuildConditionsSchema()
	{
		return new JsonSchema();
	}

	#endregion

	/// <summary>
	/// Compiles the gathered information into a <see cref="JsonSchema"/>
	/// </summary>
	public JsonSchema Build()
	{
		var conditionsSchema = BuildConditionsSchema();

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
				["goals"] = new JsonSchemaProperty
				{
					Description = "List of goals added by this set",
					Type = JsonObjectType.Array,
					Item = new JsonSchema
					{
						Type = JsonObjectType.Object,
						Properties =
						{
							["name"] = new JsonSchemaProperty
							{
								Description = "Text to display for this goal",
								Type = JsonObjectType.String,
							},
							["condition"] = new JsonSchemaProperty
							{
								Description = "Condition to meet to complete this goal",
								Reference = conditionsSchema,
							},
						},
					},
					MinItems = 1,
					UniqueItems = true,
				},
			},
			RequiredProperties =
			{
				"goals",
			},
			Definitions =
			{
				["conditions"] = conditionsSchema,
			},
		};

		return schema;
	}
}