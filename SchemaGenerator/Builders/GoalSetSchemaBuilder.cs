using BingoAPI.Goals;
using Json.Schema;

namespace SchemaGenerator.Builders;

/// <summary>
/// Class responsible to create a <see cref="JsonSchema"/> for <see cref="GoalSet"/> 
/// </summary>
internal sealed class GoalSetSchemaBuilder
{
	#region Conditions

	private JsonSchemaBuilder CreateConditionsSchema()
	{
		var schema = new JsonSchemaBuilder()
			.OneOf(
				new JsonSchemaBuilder()
					.Properties(new Dictionary<string, JsonSchemaBuilder>()
					{
						["action"] = new JsonSchemaBuilder().Const("uwu"),
					}),
				new JsonSchemaBuilder()
					.Properties(new Dictionary<string, JsonSchemaBuilder>()
					{
						["action"] = new JsonSchemaBuilder().Const("owo"),
					})
			);

		/*var schema = new JsonSchema
		{
			OneOf =
			{
				new JsonSchema
				{
					Properties =
					{
						["action"] = new JsonSchemaProperty
						{
							Type = JsonObjectType.String,
							Enumeration = { "OwO" },
						},
					},
					RequiredProperties =
					{
						"action",
					},
					AllowAdditionalProperties = false,
				},
				new JsonSchema
				{
					Properties =
					{
						["action"] = new JsonSchemaProperty
						{
							Type = JsonObjectType.String,
							Enumeration = { "UwU" },
						},
					},
					RequiredProperties =
					{
						"action",
						"params",
					},
					AllowAdditionalProperties = false,
				},
			},
		};*/

		return schema;
	}

	#endregion

	private static JsonSchemaBuilder CreateGoalSchema(string conditionRef)
	{
		const string NAME_PROPERTY_NAME = "name";
		const string CONDITION_PROPERTY_NAME = "condition";

		var schema = new JsonSchemaBuilder()
		             .Type(SchemaValueType.Object)
		             .Properties(new Dictionary<string, JsonSchemaBuilder>
		             {
			             [NAME_PROPERTY_NAME] = new JsonSchemaBuilder()
			                                    .Description("Text to display for this goal")
			                                    .Type(SchemaValueType.String),
			             [CONDITION_PROPERTY_NAME] = new JsonSchemaBuilder()
			                                         .Description("Condition to meet to complete this goal")
			                                         .Ref(conditionRef),
		             })
		             .Required(NAME_PROPERTY_NAME, CONDITION_PROPERTY_NAME);

		return schema;
	}

	/// <summary>
	/// Compiles the gathered information into a <see cref="JsonSchemaBuilder"/>
	/// </summary>
	public JsonSchema Build()
	{
		const string GOALS_PROPERTY_NAME = "goals";
		const string CONDITIONS_DEFINITION_NAME = "conditions";

		var goalSchema = CreateGoalSchema($"#/$defs/{CONDITIONS_DEFINITION_NAME}");
		var conditionsSchema = CreateConditionsSchema();

		var schema = new JsonSchemaBuilder()
		             .Title("Goals")
		             .Description("Set of goals available")
		             .Type(SchemaValueType.Object)
		             .Properties(new Dictionary<string, JsonSchemaBuilder>
		             {
			             ["name"] = new JsonSchemaBuilder()
			                        .Description("Name of the goal")
			                        .Type(SchemaValueType.String),
			             ["description"] = new JsonSchemaBuilder()
			                               .Description("Description of the set")
			                               .Type(SchemaValueType.String),
			             [GOALS_PROPERTY_NAME] = new JsonSchemaBuilder()
			                                     .Description("List of goals added by this set")
			                                     .Type(SchemaValueType.Array)
			                                     .Items(goalSchema)
			                                     .MinItems(1)
			                                     .UniqueItems(true),
		             })
		             .Defs(new Dictionary<string, JsonSchemaBuilder>
		             {
			             [CONDITIONS_DEFINITION_NAME] = conditionsSchema,
		             })
		             .Required(GOALS_PROPERTY_NAME);

		return schema.Build();
	}
}