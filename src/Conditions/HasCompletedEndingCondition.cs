using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has completed a given <see cref="Ending"/>
/// </summary>
internal sealed class HasCompletedEndingCondition : ICondition
{
	private readonly Ending _ending;

	public HasCompletedEndingCondition(ConditionData data)
	{
		_ending = data.GetRequiredParameter<Ending>("ending");
	}

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.IsEndingCompleted(_ending);
}