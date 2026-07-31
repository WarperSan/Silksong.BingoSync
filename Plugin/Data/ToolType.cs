using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every type of tool the player can obtain
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum ToolType
{
	[EnumMember(Value = "red")]
	Red,

	[EnumMember(Value = "blue")]
	Blue,

	[EnumMember(Value = "yellow")]
	Yellow,
}
