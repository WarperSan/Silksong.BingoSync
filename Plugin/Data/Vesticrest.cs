using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every vesticrest the player can obtain
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum Vesticrest
{
	[EnumMember(Value = "basic")]
	Basic,

	[EnumMember(Value = "upgraded")]
	Upgraded,
}