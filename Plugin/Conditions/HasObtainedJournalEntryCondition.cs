using System.ComponentModel;
using BingoAPI.Conditions.Attributes;
using BingoAPI.Conditions.Interfaces;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained the journal entry of a given <see cref="Data.Enemy"/>
/// </summary>
[Condition("has_obtained_journal_entry")]
internal sealed class HasObtainedJournalEntryCondition : ICondition
{
	[JsonProperty("enemy")]
	[JsonRequired]
	[Description("Name of the enemy to obtain the journal entry for")]
	public required Enemy Enemy { get; init; }

	/// <inheritdoc />
	public bool IsMet() => throw new NotImplementedException();
}
