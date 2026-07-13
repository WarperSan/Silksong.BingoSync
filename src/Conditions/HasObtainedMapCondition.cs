using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained the map of a given <see cref="Data.Area"/>
/// </summary>
[Condition("has_obtained_map")]
internal sealed class HasObtainedMapCondition : ICondition
{
	[JsonProperty("area")]
	[JsonRequired]
	public required Area Area { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasObtainedMap(Area);
}