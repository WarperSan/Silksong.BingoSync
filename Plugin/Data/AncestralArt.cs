using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every ancestral art the player can obtain
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum AncestralArt
{
	[EnumMember(Value = "swift_step")]
	SwiftStep,

	[EnumMember(Value = "cling_grip")]
	ClingGrip,

	[EnumMember(Value = "needolin")]
	Needolin,

	[EnumMember(Value = "clawline")]
	Clawline,

	[EnumMember(Value = "silk_soar")]
	SilkSoar,

	[EnumMember(Value = "sylphsong")]
	Sylphsong,
}
