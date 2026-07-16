using System.ComponentModel;
using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Data.Crest"/>
/// </summary>
[Condition("has_obtained_crest")]
internal sealed class HasObtainedCrestCondition : ICondition
{
	[JsonProperty("crest")]
	[JsonRequired]
	[Description("Name of the crest to obtain")]
	public required Crest Crest { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasObtainedCrest(Crest);
}
