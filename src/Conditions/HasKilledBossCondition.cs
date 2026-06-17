using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has killed a given <see cref="Boss"/>
/// </summary>
internal sealed class HasKilledBossCondition : ICondition
{
	private readonly Boss _boss;

	[Condition("has_killed_boss")]
	public HasKilledBossCondition(ConditionData data)
	{
		_boss = data.GetRequiredParameter<Boss>("boss");
	}

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.IsBossKilled(_boss);
}