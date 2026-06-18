using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Tool"/>
/// </summary>
internal sealed class HasObtainedToolCondition : ICondition
{
	private readonly Tool _tool;

	[Condition("has_obtained_tool")]
	public HasObtainedToolCondition(ConditionData data)
	{
		_tool = data.GetRequiredParameter<Tool>("tool");
	}

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasTool(_tool);
}