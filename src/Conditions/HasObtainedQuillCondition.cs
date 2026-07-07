using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Quill"/>
/// </summary>
internal sealed class HasObtainedQuillCondition : ICondition
{
	private readonly Quill _quill;

	[Condition("has_obtained_quill")]
	public HasObtainedQuillCondition(ConditionData data)
	{
		_quill = data.GetRequiredParameter<Quill>("quill");
	}

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasQuill(_quill);
}