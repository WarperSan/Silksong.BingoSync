using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Vesticrest"/>
/// </summary>
internal sealed class HasObtainedVesticrestCondition : ICondition
{
	private readonly Vesticrest _vesticrest;

	[Condition("has_obtained_vesticrest")]
	public HasObtainedVesticrestCondition(ConditionData data)
	{
		_vesticrest = data.GetRequiredParameter<Vesticrest>("vesticrest");
	}

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasVesticrest(_vesticrest);
}