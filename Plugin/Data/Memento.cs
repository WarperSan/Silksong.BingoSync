using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every memento the player can obtain
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum Memento
{
	[EnumMember(Value = "sprintmaster")]
	Sprintmaster,

	[EnumMember(Value = "guardian")]
	Guardian,

	[EnumMember(Value = "hero")]
	Hero,

	[EnumMember(Value = "hunter")]
	Hunter,

	[EnumMember(Value = "grey")]
	Grey,
	
	[EnumMember(Value = "surface")]
	Surface,

	[EnumMember(Value = "craw")]
	Craw,

	[EnumMember(Value = "encrusted_heart")]
	EncrustedHeart,

	[EnumMember(Value = "pollen_heart")]
	PollenHeart,

	[EnumMember(Value = "hunter_heart")]
	HunterHeart,

	[EnumMember(Value = "conjoined_heart")]
	ConjoinedHeart,
}