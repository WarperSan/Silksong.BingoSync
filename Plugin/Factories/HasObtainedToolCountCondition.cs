using System.ComponentModel;
using BingoAPI.Conditions.Attributes;
using BingoAPI.Conditions.BuiltIn;
using BingoAPI.Conditions.Factories;
using BingoAPI.Conditions.Interfaces;
using Newtonsoft.Json;
using Silksong.BingoSync.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Factories;

[ConditionFactory("has_obtained_tool_count")]
internal sealed class HasObtainedToolCountCondition
	: ParameterizedConditionFactory<HasObtainedToolCountCondition.Parameters>
{
	public sealed class Parameters
	{
		[JsonProperty("amount")]
		[JsonRequired]
		[Description("Minimum number of conditions that must be met")]
		public uint Amount { get; init; }

		[JsonProperty("type")]
		[Description("Type of the tool to keep")]
		public ToolType? Type { get; init; }
	}

	/// <summary>
	/// Creates a <see cref="ICondition"/> for the given <see cref="Tool"/>
	/// </summary>
	private static ICondition CreateCondition(Tool tool) =>
		new HasObtainedToolCondition { Tool = tool };

	/// <summary>
	/// Gets all the <see cref="Tool"/> that match the given <see cref="Parameters"/>
	/// </summary>
	private static IEnumerable<Tool> GetTools(Parameters parameters)
	{
		foreach (Tool tool in Enum.GetValues(typeof(Tool)))
		{
			if (parameters.Type.HasValue)
			{
				var toolType = tool.GetToolType();

				if (parameters.Type.Value != toolType)
					continue;
			}

			yield return tool;
		}
	}

	/// <inheritdoc />
	protected override ICondition Generate(Parameters parameters)
	{
		var conditions = GetTools(parameters).Select(CreateCondition).ToList();

		return new SomeCondition { Amount = parameters.Amount, Conditions = conditions };
	}
}
