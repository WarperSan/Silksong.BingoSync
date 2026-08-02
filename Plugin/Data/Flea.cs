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
	[EnumMember(Value = "above_marrow_bellways")]
	AboveMarrowBellways,

	[EnumMember(Value = "behind_deep_docks_bellways")]
	BehindDeepDocksBellways,

	[EnumMember(Value = "left_of_swift_step")]
	LeftOfSwiftStep,

	[EnumMember(Value = "behind_deep_docks_furnace_gauntlet")]
	BehindDeepDocksFurnaceGauntlet,

	[EnumMember(Value = "behind_skarrgard")]
	BehindSkarrgard,

	[EnumMember(Value = "behind_booby_trap")]
	BehindBoobyTrap,

	[EnumMember(Value = "next_to_pilgrims_rest")]
	NextToPilgrimsRest,

	[EnumMember(Value = "carried_by_aknid")]
	CarriedByAknid,

	[EnumMember(Value = "above_craw_lake")]
	AboveCrawLake,

	[EnumMember(Value = "top_of_greymoor_left_tower")]
	TopOfGreymoorLeftTower,

	[EnumMember(Value = "kratt")]
	Kratt,

	[EnumMember(Value = "above_bellhart")]
	AboveBellhart,

	[EnumMember(Value = "in_gahlia_pit")]
	InGahliaPit,

	[EnumMember(Value = "above_grindle")]
	AboveGrindle,

	[EnumMember(Value = "trapped_in_sinners_road")]
	TrappedInSinnersRoad,

	[EnumMember(Value = "guarded_by_snitchflies")]
	GuardedBySnitchflies,

	[EnumMember(Value = "beside_exhaust_organ")]
	BesideExhaustOrgan,

	[EnumMember(Value = "above_secret_bilewater_bench")]
	AboveSecretBilewaterBench,

	[EnumMember(Value = "after_wisp_thicket")]
	AfterWispThicket,

	[EnumMember(Value = "across_cogwork_haulers_room")]
	AcrossCogworkHaulersRoom,

	[EnumMember(Value = "after_choral_chambers_platforming")]
	AfterChoralChambersPlatforming,

	[EnumMember(Value = "after_vertical_sawblades_room")]
	AfterVerticalSawbladesRoom,

	[EnumMember(Value = "huge_flea")]
	HugeFlea,

	[EnumMember(Value = "jailed_in_slab")]
	JailedInSlab,

	[EnumMember(Value = "above_slab_bench")]
	AboveSlabBench,

	[EnumMember(Value = "frozen_in_ice")]
	FrozenInIce,

	[EnumMember(Value = "under_voltnest")]
	UnderVoltnest,

	[EnumMember(Value = "vog")]
	Vog,

	[EnumMember(Value = "right_of_songclave")]
	RightOfSongclave,

	[EnumMember(Value = "right_of_box_puzzle")]
	RightOfBoxPuzzle,
}
