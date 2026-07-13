using System.ComponentModel;
using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has deposited a given <see cref="Data.Memento"/>
/// </summary>
[Condition("has_deposited_memento")]
internal sealed class HasDepositedMementoCondition : ICondition
{
	[JsonProperty("memento")]
	[JsonRequired]
	[Description("Name of the memento to deposit")]
	public required Memento Memento { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasDepositedMemento(Memento);
}