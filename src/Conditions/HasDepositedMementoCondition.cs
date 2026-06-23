using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has deposited a given <see cref="Memento"/>
/// </summary>
internal sealed class HasDepositedMementoCondition : ICondition
{
	private readonly Memento _memento;
	
	[Condition("has_deposited_memento")]
	public HasDepositedMementoCondition(ConditionData data)
	{
		_memento = data.GetRequiredParameter<Memento>("memento");
	}
	
	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasDepositedMemento(_memento);
}