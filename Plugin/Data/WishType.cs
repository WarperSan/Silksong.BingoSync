using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every type of wish the player can accept
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum WishType
{
	[EnumMember(Value = "wayfarer")]
	Wayfarer,

	[EnumMember(Value = "gather")]
	Gather,

	[EnumMember(Value = "hunt")]
	Hunt,

	[EnumMember(Value = "grand_hunt")]
	GrandHunt,

	[EnumMember(Value = "donate")]
	Donate,

	[EnumMember(Value = "delivery")]
	Delivery,

	[EnumMember(Value = "unique")]
	Unique,
}
