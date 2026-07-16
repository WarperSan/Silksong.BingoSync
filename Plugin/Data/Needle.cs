using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every needle the player can complete
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum Needle
{
	[EnumMember(Value = "needle")]
	Needle,

	[EnumMember(Value = "sharpened_needle")]
	SharpenedNeedle,

	[EnumMember(Value = "shining_needle")]
	ShiningNeedle,

	[EnumMember(Value = "hivesteel_needle")]
	HivesteelNeedle,

	[EnumMember(Value = "pale_steel_needle")]
	PaleSteelNeedle,
}
