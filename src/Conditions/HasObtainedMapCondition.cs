using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained the map of a given <see cref="Area"/>
/// </summary>
internal sealed class HasObtainedMapCondition : ICondition
{
	private readonly Area _area;

	[Condition("has_obtained_map")]
	public HasObtainedMapCondition(ConditionData data)
	{
		_area = data.GetRequiredParameter<Area>("area");
	}

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasMap(_area);
}