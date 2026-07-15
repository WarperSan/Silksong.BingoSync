using System.ComponentModel;
using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has killed a given <see cref="Data.Boss"/>
/// </summary>
[Condition("has_killed_boss")]
internal sealed class HasKilledBossCondition : ICondition
{
	[JsonProperty("boss")]
	[JsonRequired]
	[Description("Name of the boss to kill")]
	public required Boss Boss  { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasKilledBoss(Boss);
}