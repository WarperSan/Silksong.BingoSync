using System.ComponentModel;
using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Data.Memento"/>
/// </summary>
[Condition("has_obtained_memento")]
internal sealed class HasObtainedMementoCondition : ICondition
{
	[JsonProperty("memento")]
	[JsonRequired]
	[Description("Name of the memento to obtain")]
	public required Memento Memento { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasObtainedMemento(Memento);
}