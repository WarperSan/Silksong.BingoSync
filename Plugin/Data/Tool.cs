using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every tool the player can obtain
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum Tool
{
	[EnumMember(Value = "straight_pin")]
	StraightPin,

	[EnumMember(Value = "threefold_pin")]
	ThreefoldPin,

	[EnumMember(Value = "sting_shard")]
	StingShard,

	[EnumMember(Value = "tacks")]
	Tacks,

	[EnumMember(Value = "longpin")]
	Longpin,

	[EnumMember(Value = "curveclaw")]
	Curveclaw,

	[EnumMember(Value = "curvesickle")]
	Curvesickle,

	[EnumMember(Value = "throwing_ring")]
	ThrowingRing,

	[EnumMember(Value = "pimpillo")]
	Pimpillo,

	[EnumMember(Value = "conchcutter")]
	Conchcutter,

	[EnumMember(Value = "weaver_silkshot")]
	WeaverSilkshot,

	[EnumMember(Value = "architect_silkshot")]
	ArchitectSilkshot,

	[EnumMember(Value = "forge_silkshot")]
	ForgeSilkshot,

	[EnumMember(Value = "delvers_drill")]
	DelversDrill,

	[EnumMember(Value = "cogwork_wheel")]
	CogworkWheel,

	[EnumMember(Value = "cogfly")]
	Cogfly,

	[EnumMember(Value = "rosary_cannon")]
	RosaryCannon,

	[EnumMember(Value = "voltvessels")]
	Voltvessels,

	[EnumMember(Value = "flintslate")]
	Flintslate,

	[EnumMember(Value = "snare_setter")]
	SnareSetter,

	[EnumMember(Value = "flea_brew")]
	FleaBrew,

	[EnumMember(Value = "plasmium_phial")]
	PlasmiumPhial,

	[EnumMember(Value = "needle_phial")]
	NeedlePhial,

	[EnumMember(Value = "druids_eye")]
	DruidsEye,

	[EnumMember(Value = "druids_eyes")]
	DruidsEyes,

	[EnumMember(Value = "magma_bell")]
	MagmaBell,

	[EnumMember(Value = "warding_bell")]
	WardingBell,

	[EnumMember(Value = "pollip_pouch")]
	PollipPouch,

	[EnumMember(Value = "fractured_mask")]
	FracturedMask,

	[EnumMember(Value = "multibinder")]
	Multibinder,

	[EnumMember(Value = "weavelight")]
	Weavelight,

	[EnumMember(Value = "sawtooth_circlet")]
	SawtoothCirclet,

	[EnumMember(Value = "injector_band")]
	InjectorBand,

	[EnumMember(Value = "spool_extender")]
	SpoolExtender,

	[EnumMember(Value = "reserve_bind")]
	ReserveBind,

	[EnumMember(Value = "claw_mirror")]
	ClawMirror,

	[EnumMember(Value = "claw_mirrors")]
	ClawMirrors,

	[EnumMember(Value = "memory_crystal")]
	MemoryCrystal,

	[EnumMember(Value = "snitch_pick")]
	SnitchPick,

	[EnumMember(Value = "volt_filament")]
	VoltFilament,

	[EnumMember(Value = "quick_sling")]
	QuickSling,

	[EnumMember(Value = "wreath_of_purity")]
	WreathOfPurity,

	[EnumMember(Value = "longclaw")]
	Longclaw,

	[EnumMember(Value = "wispfire_lantern")]
	WispfireLantern,

	[EnumMember(Value = "egg_of_flealia")]
	EggOfFlealia,

	[EnumMember(Value = "pin_badge")]
	PinBadge,

	[EnumMember(Value = "compass")]
	Compass,

	[EnumMember(Value = "shard_pendant")]
	ShardPendant,

	[EnumMember(Value = "magnetite_brooch")]
	MagnetiteBrooch,

	[EnumMember(Value = "weighted_belt")]
	WeightedBelt,

	[EnumMember(Value = "barbed_bracelet")]
	BarbedBracelet,

	[EnumMember(Value = "dead_bugs_purse")]
	DeadBugsPurse,

	[EnumMember(Value = "shell_satchel")]
	ShellSatchel,

	[EnumMember(Value = "magnetite_dice")]
	MagnetiteDice,

	[EnumMember(Value = "scuttlebrace")]
	Scuttlebrace,

	[EnumMember(Value = "ascendants_grip")]
	AscendantsGrip,

	[EnumMember(Value = "spider_strings")]
	SpiderStrings,

	[EnumMember(Value = "silkspeed_anklets")]
	SilkspeedAnklets,

	[EnumMember(Value = "thiefs_mark")]
	ThiefsMark,
}
