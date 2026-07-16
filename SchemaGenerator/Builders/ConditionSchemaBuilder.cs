using BingoAPI.Conditions;
using NJsonSchema;

namespace SchemaGenerator.Builders;

/// <summary>
/// Class responsible for creating a <see cref="JsonSchema"/> for a <see cref="ICondition"/>
/// </summary>
internal sealed class ConditionSchemaBuilder
{
	#region Action

	private string? _action;

	/// <summary>
	/// Sets the action to use
	/// </summary>
	public ConditionSchemaBuilder Action(string action)
	{
		_action = action;
		return this;
	}

	#endregion

	#region Parameters

	private readonly Dictionary<string, JsonSchemaProperty> _parameters = new();

	/// <summary>
	/// Adds a parameter with the given name and schema
	/// </summary>
	public ConditionSchemaBuilder Parameter(string name, JsonSchemaProperty schema)
	{
		_parameters.Add(name, schema);
		return this;
	}

	#endregion

	#region Build

	/// <summary>
	/// Creates a <see cref="JsonSchema"/> from the collected information
	/// </summary>
	public JsonSchema Build()
	{
		if (_action == null)
			throw new NullReferenceException(
				"Tried building a condition without specifying an action."
			);

		var schema = new JsonSchema { Type = JsonObjectType.Object };

		BuildAction(schema, _action);
		BuildParameters(schema, _parameters);

		return schema;
	}

	private static void BuildAction(JsonSchema schema, string action)
	{
		const string ACTION_PARAMETER_NAME = "action";

		schema.Properties.Add(
			ACTION_PARAMETER_NAME,
			new JsonSchemaProperty { Type = JsonObjectType.String, Enumeration = { action } }
		);

		schema.RequiredProperties.Add(ACTION_PARAMETER_NAME);
	}

	private static void BuildParameters(
		JsonSchema schema,
		Dictionary<string, JsonSchemaProperty> parameters
	)
	{
		const string PARAMS_PARAMETER_NAME = "params";

		if (parameters.Count <= 0)
			return;

		var paramsProp = new JsonSchemaProperty
		{
			Type = JsonObjectType.Object,
			AllowAdditionalProperties = false,
		};

		foreach ((var name, var parameter) in parameters)
			paramsProp.Properties.Add(name, parameter);

		if (paramsProp.RequiredProperties.Count > 0)
			schema.RequiredProperties.Add(PARAMS_PARAMETER_NAME);

		schema.Properties.Add(PARAMS_PARAMETER_NAME, paramsProp);
	}

	#endregion
}
