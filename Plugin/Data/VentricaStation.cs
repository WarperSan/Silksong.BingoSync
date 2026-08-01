using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every ventrica station the player can obtain
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum VentricaStation
{
	[EnumMember(Value = "memorium")]
	Memorium,

	[EnumMember(Value = "high_halls")]
	HighHalls,

	[EnumMember(Value = "first_shrine")]
	FirstShrine,

	[EnumMember(Value = "choral_chambers")]
	ChoralChambers,

	[EnumMember(Value = "grand_bellway")]
	GrandBellway,

	[EnumMember(Value = "underworks")]
	Underworks,
}
