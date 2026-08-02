using System.ComponentModel;
using BingoAPI.Conditions.Attributes;
using BingoAPI.Conditions.Interfaces;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

[Condition("has_found_flea")]
internal sealed class HasFoundFleaCondition : ICondition
{
	[JsonProperty("flea")]
	[JsonRequired]
	[Description("Name of the flea to find")]
	public required Flea Flea { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasFoundFlea(Flea);
}
