using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every flea the player can free
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum Flea
{
	TheMarrow,
	DeepDocks1,
	DeepDocks2,
	DeepDocks3,
	HuntersMarch,
	FarFields1,
	FarFields2,
	Wormways,
	Greymoor1,
	Greymoor2,

	[EnumMember(Value = "kratt")]
	Kratt,
	Bellhart,
	Shellwood,
	BlastedSteps,
	SinnersRoad,
	Bilewater1,
	Bilewater2,
	Bilewater3,
	Underworks1,
	Underworks2,
	ChoralChambers1,
	ChoralChambers2,

	[EnumMember(Value = "huge_flea")]
	HugeFlea,
	TheSlab1,
	TheSlab2,
	MountFay,
	SandsOfKarak,

	[EnumMember(Value = "vog")]
	Vog,
	WhisperingVaults1,
	WhisperingVaults2,
}
