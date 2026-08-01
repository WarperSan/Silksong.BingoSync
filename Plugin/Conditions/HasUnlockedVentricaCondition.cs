using System.ComponentModel;
using BingoAPI.Conditions.Attributes;
using BingoAPI.Conditions.Interfaces;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has unlocked a given <see cref="Ventrica"/>
/// </summary>
[Condition("has_unlocked_ventrica")]
internal sealed class HasUnlockedVentricaCondition : ICondition
{
	[JsonProperty("station")]
	[JsonRequired]
	[Description("Name of the Ventrica station to unlock")]
	public required Ventrica Station { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasUnlockedStation(Station);
}
