using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has completed a given <see cref="Data.Wish"/>
/// </summary>
[Condition("has_completed_wish")]
internal class HasCompletedWishCondition : ICondition
{
	[JsonProperty("wish")]
	[JsonRequired]
	public required Wish Wish { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasCompletedWish(Wish);
}