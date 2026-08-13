using BingoAPI.Conditions.Attributes;
using BingoAPI.Conditions.Interfaces;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained the journal entry of a given <see cref="Data.Enemy"/>
/// </summary>
[Condition("has_obtained_journal_entry")]
internal sealed class HasObtainedJournalEntryCondition : ICondition
{
	/// <inheritdoc />
	public bool IsMet() => throw new NotImplementedException();
}
