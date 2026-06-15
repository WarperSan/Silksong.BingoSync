using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Crest"/>
/// </summary>
internal sealed class HasObtainedSilkSkillCondition : ICondition
{
	private readonly SilkSkill _skill;

	public HasObtainedSilkSkillCondition(ConditionData data)
	{
		_skill = data.GetRequiredParameter<SilkSkill>("skill");
	}

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasSilkSkill(_skill);
}