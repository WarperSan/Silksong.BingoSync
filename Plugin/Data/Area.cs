using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every area the player can explore
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum Area
{
	[EnumMember(Value = "the_abyss")]
	TheAbyss,

	[EnumMember(Value = "bellhart")]
	Bellhart,

	[EnumMember(Value = "bilewater")]
	Bilewater,

	[EnumMember(Value = "blasted_steps")]
	BlastedSteps,

	[EnumMember(Value = "bone_bottom")]
	BoneBottom,

	[EnumMember(Value = "the_cradle")]
	TheCradle,

	[EnumMember(Value = "deep_docks")]
	DeepDocks,

	[EnumMember(Value = "far_fields")]
	FarFields,

	[EnumMember(Value = "greymoor")]
	Greymoor,

	[EnumMember(Value = "hunters_march")]
	HuntersMarch,

	[EnumMember(Value = "the_marrow")]
	TheMarrow,

	[EnumMember(Value = "the_mist")]
	TheMist,

	[EnumMember(Value = "moss_grotto")]
	MossGrotto,

	[EnumMember(Value = "mount_fay")]
	MountFay,

	[EnumMember(Value = "putrified_ducts")]
	PutrifiedDucts,

	[EnumMember(Value = "red_memory")]
	RedMemory,

	[EnumMember(Value = "sands_of_karak")]
	SandsOfKarak,

	[EnumMember(Value = "shellwood")]
	Shellwood,

	[EnumMember(Value = "sinners_road")]
	SinnersRoad,

	[EnumMember(Value = "the_slab")]
	TheSlab,

	[EnumMember(Value = "underworks")]
	Underworks,

	[EnumMember(Value = "verdania")]
	Verdania,

	[EnumMember(Value = "weavenest_atla")]
	WeavenestAtla,

	[EnumMember(Value = "wisp_thicket")]
	WispThicket,

	[EnumMember(Value = "wormways")]
	Wormways,

	[EnumMember(Value = "choral_chambers")]
	ChoralChambers,

	[EnumMember(Value = "cogwork_core")]
	CogworkCore,

	[EnumMember(Value = "grand_gate")]
	GrandGate,

	[EnumMember(Value = "high_halls")]
	HighHalls,

	[EnumMember(Value = "memorium")]
	Memorium,

	[EnumMember(Value = "whispering_vaults")]
	WhisperingVaults,

	[EnumMember(Value = "whiteward")]
	Whiteward,
}
