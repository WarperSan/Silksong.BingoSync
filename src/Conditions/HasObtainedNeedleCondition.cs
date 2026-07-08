using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained the given <see cref="Data.Needle"/>
/// </summary>
[Condition("has_obtained_needle")]
internal sealed class HasObtainedNeedleCondition : ICondition
{
	[JsonProperty("needle")]
	[JsonRequired]
	public required Needle Needle { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasObtainedNeedle(Needle);
}