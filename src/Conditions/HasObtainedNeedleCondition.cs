using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained the given <see cref="Needle"/>
/// </summary>
internal sealed class HasObtainedNeedleCondition : ICondition
{
	private readonly Needle _needle;

	[Condition("has_obtained_needle")]
	public HasObtainedNeedleCondition(ConditionData data)
	{
		_needle = data.GetRequiredParameter<Needle>("needle");
	}

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasObtainedNeedle(_needle);
}