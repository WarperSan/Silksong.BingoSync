using System.ComponentModel;
using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks if the player has obtained a given <see cref="Data.Vesticrest"/>
/// </summary>
[Condition("has_obtained_vesticrest")]
internal sealed class HasObtainedVesticrestCondition : ICondition
{
	[JsonProperty("vesticrest")]
	[JsonRequired]
	[Description("Name of the vesticrest to obtain")]
	public required Vesticrest Vesticrest { get; init; }

	/// <inheritdoc />
	public bool IsMet() => PlayerData.instance.HasObtainedVesticrest(Vesticrest);
}