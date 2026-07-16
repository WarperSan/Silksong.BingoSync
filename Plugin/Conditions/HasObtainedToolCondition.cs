using System.ComponentModel;
using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Data.Tool"/>
/// </summary>
[Condition("has_obtained_tool")]
internal sealed class HasObtainedToolCondition : ICondition
{
	[JsonProperty("tool")]
	[JsonRequired]
	[Description("Name of the tool to obtain")]
	public required Tool Tool { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasObtainedTool(Tool);
}
