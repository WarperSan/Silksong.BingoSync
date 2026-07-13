using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has completed a given <see cref="Data.Ending"/>
/// </summary>
[Condition("has_completed_ending")]
internal sealed class HasCompletedEndingCondition : ICondition
{
	[JsonProperty("ending")]
	[JsonRequired]
	public required Ending Ending { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasCompletedEnding(Ending);
}