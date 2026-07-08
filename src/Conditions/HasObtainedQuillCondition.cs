using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Data.Quill"/>
/// </summary>
[Condition("has_obtained_quill")]
internal sealed class HasObtainedQuillCondition : ICondition
{
	[JsonProperty("quill")]
	[JsonRequired]
	public required Quill Quill { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasQuill(Quill);
}