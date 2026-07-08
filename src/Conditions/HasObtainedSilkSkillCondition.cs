using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Crest"/>
/// </summary>
[Condition("has_obtained_silk_skill")]
internal sealed class HasObtainedSilkSkillCondition : ICondition
{
	[JsonProperty("skill")]
	[JsonRequired]
	public required SilkSkill Skill { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasSilkSkill(Skill);
}