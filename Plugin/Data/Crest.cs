using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every crest the player can obtain
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum Crest
{
	[EnumMember(Value = "hunter")]
	Hunter,

	[EnumMember(Value = "hunter_evolved")]
	HunterEvolved,

	[EnumMember(Value = "hunter_fully_evolved")]
	HunterFullyEvolved,

	[EnumMember(Value = "reaper")]
	Reaper,

	[EnumMember(Value = "wanderer")]
	Wanderer,

	[EnumMember(Value = "beast")]
	Beast,

	[EnumMember(Value = "cursed")]
	Cursed,

	[EnumMember(Value = "witch")]
	Witch,

	[EnumMember(Value = "architect")]
	Architect,

	[EnumMember(Value = "shaman")]
	Shaman,

	[EnumMember(Value = "cloakless")]
	Cloakless,
}
