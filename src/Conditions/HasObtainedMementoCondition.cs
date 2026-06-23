using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Memento"/>
/// </summary>
internal sealed class HasObtainedMementoCondition : ICondition
{
	private readonly Memento _memento;
	
	[Condition("has_obtained_memento")]
	public HasObtainedMementoCondition(ConditionData data)
	{
		_memento = data.GetRequiredParameter<Memento>("memento");
	}
	
	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasMemento(_memento);
}