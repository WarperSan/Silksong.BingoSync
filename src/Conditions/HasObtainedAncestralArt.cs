using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Crest"/>
/// </summary>
internal sealed class HasObtainedAncestralArt : ICondition
{
	private readonly AncestralArt _art;

	[Condition("has_obtained_ancestral_art")]
	public HasObtainedAncestralArt(ConditionData data)
	{
		_art = data.GetRequiredParameter<AncestralArt>("art");
	}

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasAncestralArt(_art);
}