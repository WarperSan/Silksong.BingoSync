using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every ending the player can complete
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum Ending
{
	[EnumMember(Value = "weaver_queen")]
	WeaverQueen,

	[EnumMember(Value = "snared_silk")]
	SnaredSilk,

	[EnumMember(Value = "twisted_child")]
	TwistedChild,

	[EnumMember(Value = "sister_of_the_void")]
	SisterOfTheVoid,

	[EnumMember(Value = "passing_of_the_age")]
	PassingOfTheAge,
}