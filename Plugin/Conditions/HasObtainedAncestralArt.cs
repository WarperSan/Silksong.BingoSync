using System.ComponentModel;
using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Crest"/>
/// </summary>
[Condition("has_obtained_ancestral_art")]
internal sealed class HasObtainedAncestralArt : ICondition
{
	[JsonProperty("art")]
	[JsonRequired]
	[Description("Name of the ancestral art to obtain")]
	public required AncestralArt Art { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasObtainedAncestralArt(Art);
}
