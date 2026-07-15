using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every quill the player can obtain
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
public enum Quill
{
	[EnumMember(Value = "white")]
	White,

	[EnumMember(Value = "red")]
	Red,

	[EnumMember(Value = "purple")]
	Purple,
}