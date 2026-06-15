using BingoAPI.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Crest"/>
/// </summary>
internal sealed class HasObtainedCrestCondition : ICondition
{
	private readonly Crest _crest;

	public HasObtainedCrestCondition(ConditionData data)
	{
		_crest = data.GetRequiredParameter<Crest>("crest");
	}

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasCrest(_crest);
}