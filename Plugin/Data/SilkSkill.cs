using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every silk skill the player can obtain
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
public enum SilkSkill
{
	[EnumMember(Value = "silkspear")]
	Silkspear,

	[EnumMember(Value = "thread_storm")]
	ThreadStorm,

	[EnumMember(Value = "cross_stitch")]
	CrossStitch,

	[EnumMember(Value = "sharpdart")]
	Sharpdart,

	[EnumMember(Value = "rune_rage")]
	RuneRage,

	[EnumMember(Value = "pale_nails")]
	PaleNails,
}
