using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every enemy the player can kill
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum Enemy
{
	[EnumMember(Value = "mossgrub")]
	Mossgrub,

	[EnumMember(Value = "massive_mossgrub")]
	MassiveMossgrub,

	[EnumMember(Value = "mossmir")]
	Mossmir,

	[EnumMember(Value = "aknid")]
	Aknid,

	[EnumMember(Value = "skull_scuttler")]
	SkullScuttler,

	[EnumMember(Value = "skullwing")]
	Skullwing,

	[EnumMember(Value = "skull_brute")]
	SkullBrute,

	[EnumMember(Value = "kilik")]
	Kilik,

	[EnumMember(Value = "beastfly")]
	Beastfly,

	[EnumMember(Value = "caranid")]
	Caranid,

	[EnumMember(Value = "vicious_caranid")]
	ViciousCaranid,

	[EnumMember(Value = "hardbone_hopper")]
	HardboneHopper,

	[EnumMember(Value = "hardbone_elder")]
	HardboneElder,

	[EnumMember(Value = "tarmite")]
	Tarmite,

	[EnumMember(Value = "mawling")]
	Mawling,

	[EnumMember(Value = "marrowmaw")]
	Marrowmaw,

	[EnumMember(Value = "hoker")]
	Hoker,

	[EnumMember(Value = "flintbeetle")]
	Flintbeetle,

	[EnumMember(Value = "rhinogrund")]
	Rhinogrund,

	[EnumMember(Value = "gromling")]
	Gromling,

	[EnumMember(Value = "grom")]
	Grom,

	[EnumMember(Value = "pilgrim_groveller")]
	PilgrimGroveller,

	[EnumMember(Value = "pilgrim_pouncer")]
	PilgrimPouncer,

	[EnumMember(Value = "pilgrim_hornfly")]
	PilgrimHornfly,

	[EnumMember(Value = "pilgrim_hulk")]
	PilgrimHulk,

	[EnumMember(Value = "pilgrim_bellbearer")]
	PilgrimBellbearer,

	[EnumMember(Value = "winged_pilgrim")]
	WingedPilgrim,

	[EnumMember(Value = "elder_pilgrim")]
	ElderPilgrim,

	[EnumMember(Value = "winged_pilgrim_bellbearer")]
	WingedPilgrimBellbearer,

	[EnumMember(Value = "pilgrim_hiker")]
	PilgrimHiker,

	[EnumMember(Value = "pilgrim_guide")]
	PilgrimGuide,

	[EnumMember(Value = "overgrown_pilgrim")]
	OvergrownPilgrim,

	[EnumMember(Value = "covetous_pilgrim")]
	CovetousPilgrim,

	[EnumMember(Value = "snitchfly")]
	Snitchfly,

	[EnumMember(Value = "lavalug")]
	Lavalug,

	[EnumMember(Value = "lavalarga")]
	Lavalarga,

	[EnumMember(Value = "smelt_shoveller")]
	SmeltShoveller,

	[EnumMember(Value = "flintstone_flyer")]
	FlintstoneFlyer,

	[EnumMember(Value = "flintflame_flyer")]
	FlintflameFlyer,

	[EnumMember(Value = "smokerock_sifter")]
	SmokerockSifter,

	[EnumMember(Value = "deep_diver")]
	DeepDiver,

	[EnumMember(Value = "cragglite")]
	Cragglite,

	[EnumMember(Value = "craggler")]
	Craggler,

	[EnumMember(Value = "brushflit")]
	Brushflit,

	[EnumMember(Value = "fertid")]
	Fertid,

	[EnumMember(Value = "flapping_fertid")]
	FlappingFertid,

	[EnumMember(Value = "skarrlid")]
	Skarrlid,

	[EnumMember(Value = "skarrwing")]
	Skarrwing,

	[EnumMember(Value = "skarr_scout")]
	SkarrScout,

	[EnumMember(Value = "skarr_stalker")]
	SkarrStalker,

	[EnumMember(Value = "spear_skarr")]
	SpearSkarr,

	[EnumMember(Value = "skarrgard")]
	Skarrgard,

	[EnumMember(Value = "last_claw")]
	LastClaw,

	[EnumMember(Value = "mite")]
	Mite,

	[EnumMember(Value = "fluttermite")]
	Fluttermite,

	[EnumMember(Value = "mitemother")]
	Mitemother,

	[EnumMember(Value = "dreg_catcher")]
	DregCatcher,

	[EnumMember(Value = "silk_snipper")]
	SilkSnipper,

	[EnumMember(Value = "thread_raker")]
	ThreadRaker,

	[EnumMember(Value = "wisp")]
	Wisp,

	[EnumMember(Value = "burning_bug")]
	BurningBug,

	[EnumMember(Value = "craw")]
	Craw,

	[EnumMember(Value = "tallcraw")]
	Tallcraw,

	[EnumMember(Value = "squatcraw")]
	Squatcraw,

	[EnumMember(Value = "craw_juror")]
	CrawJuror,

	[EnumMember(Value = "tallcraw_juror")]
	TallcrawJuror,

	[EnumMember(Value = "squatcraw_juror")]
	SquatcrawJuror,

	[EnumMember(Value = "muckmaggot")]
	Muckmaggot,

	[EnumMember(Value = "slubberlug")]
	Slubberlug,

	[EnumMember(Value = "muckroach")]
	Muckroach,

	[EnumMember(Value = "bloatroach")]
	Bloatroach,

	[EnumMember(Value = "roachcatcher")]
	Roachcatcher,

	[EnumMember(Value = "roachfeeder")]
	Roachfeeder,

	[EnumMember(Value = "roachkeeper")]
	Roachkeeper,

	[EnumMember(Value = "roachserver")]
	Roachserver,

	[EnumMember(Value = "wraith")]
	Wraith,

	[EnumMember(Value = "mothleaf_lagnia")]
	MothleafLagnia,

	[EnumMember(Value = "miremite")]
	Miremite,

	[EnumMember(Value = "swamp_squit")]
	SwampSquit,

	[EnumMember(Value = "spit_squit")]
	SpitSquit,

	[EnumMember(Value = "stilkin")]
	Stilkin,

	[EnumMember(Value = "stilkin_trapper")]
	StilkinTrapper,

	[EnumMember(Value = "barnak")]
	Barnak,

	[EnumMember(Value = "ductsucker")]
	Ductsucker,

	[EnumMember(Value = "pond_skipper")]
	PondSkipper,

	[EnumMember(Value = "pondcatcher")]
	Pondcatcher,

	[EnumMember(Value = "shellwood_gnat")]
	ShellwoodGnat,

	[EnumMember(Value = "wood_wasp")]
	WoodWasp,

	[EnumMember(Value = "splinter")]
	Splinter,

	[EnumMember(Value = "splinterhorn")]
	Splinterhorn,

	[EnumMember(Value = "splinterbark")]
	Splinterbark,

	[EnumMember(Value = "phacia")]
	Phacia,

	[EnumMember(Value = "pollenica")]
	Pollenica,

	[EnumMember(Value = "gahlia")]
	Gahlia,

	[EnumMember(Value = "furm")]
	Furm,

	[EnumMember(Value = "winged_furm")]
	WingedFurm,

	[EnumMember(Value = "pharlid")]
	Pharlid,

	[EnumMember(Value = "pharlid_diver")]
	PharlidDiver,

	[EnumMember(Value = "shardillard")]
	Shardillard,

	[EnumMember(Value = "sandcarver")]
	Sandcarver,

	[EnumMember(Value = "squirrm")]
	Squirrm,

	[EnumMember(Value = "judge")]
	Judge,

	[EnumMember(Value = "coral_furm")]
	CoralFurm,

	[EnumMember(Value = "driznit")]
	Driznit,

	[EnumMember(Value = "driznarga")]
	Driznarga,

	[EnumMember(Value = "pokenabbin")]
	Pokenabbin,

	[EnumMember(Value = "conchfly")]
	Conchfly,

	[EnumMember(Value = "crustcrawler")]
	Crustcrawler,

	[EnumMember(Value = "crustcrag")]
	Crustcrag,

	[EnumMember(Value = "kai")]
	Kai,

	[EnumMember(Value = "spinebeak_kai")]
	SpinebeakKai,

	[EnumMember(Value = "steelspine_kai")]
	SteelspineKai,

	[EnumMember(Value = "yuma")]
	Yuma,

	[EnumMember(Value = "yumama")]
	Yumama,

	[EnumMember(Value = "karaka")]
	Karaka,

	[EnumMember(Value = "kakri")]
	Kakri,

	[EnumMember(Value = "yago")]
	Yago,

	[EnumMember(Value = "karak_gor")]
	KarakGor,

	[EnumMember(Value = "alita")]
	Alita,

	[EnumMember(Value = "corrcrust_karaka")]
	CorrcrustKaraka,

	[EnumMember(Value = "drapefly")]
	Drapefly,

	[EnumMember(Value = "drapelord")]
	Drapelord,

	[EnumMember(Value = "drapemite")]
	Drapemite,

	[EnumMember(Value = "giant_drapemite")]
	GiantDrapemite,

	[EnumMember(Value = "underworker")]
	Underworker,

	[EnumMember(Value = "underscrub")]
	Underscrub,

	[EnumMember(Value = "undersweep")]
	Undersweep,

	[EnumMember(Value = "underpoke")]
	Underpoke,

	[EnumMember(Value = "underloft")]
	Underloft,

	[EnumMember(Value = "undercrank")]
	Undercrank,

	[EnumMember(Value = "envoy")]
	Envoy,

	[EnumMember(Value = "choir_pouncer")]
	ChoirPouncer,

	[EnumMember(Value = "choir_hornhead")]
	ChoirHornhead,

	[EnumMember(Value = "choir_bellbearer")]
	ChoirBellbearer,

	[EnumMember(Value = "choir_flyer")]
	ChoirFlyer,

	[EnumMember(Value = "choir_elder")]
	ChoirElder,

	[EnumMember(Value = "choristor")]
	Choristor,

	[EnumMember(Value = "reed")]
	Reed,

	[EnumMember(Value = "grand_reed")]
	GrandReed,

	[EnumMember(Value = "choir_clapper")]
	ChoirClapper,

	[EnumMember(Value = "clawmaiden")]
	Clawmaiden,

	[EnumMember(Value = "memoria")]
	Memoria,

	[EnumMember(Value = "minister")]
	Minister,

	[EnumMember(Value = "maestro")]
	Maestro,

	[EnumMember(Value = "dreg_husk")]
	DregHusk,

	[EnumMember(Value = "dregwheel")]
	Dregwheel,

	[EnumMember(Value = "surgeon")]
	Surgeon,

	[EnumMember(Value = "mortician")]
	Mortician,

	[EnumMember(Value = "cogwork_underfly")]
	CogworkUnderfly,

	[EnumMember(Value = "cogwork_hauler")]
	CogworkHauler,

	[EnumMember(Value = "cogwork_crawler")]
	CogworkCrawler,

	[EnumMember(Value = "cogworker")]
	Cogworker,

	[EnumMember(Value = "cogwork_spine")]
	CogworkSpine,

	[EnumMember(Value = "cogwork_choirbug")]
	CogworkChoirbug,

	[EnumMember(Value = "cogwork_cleanser")]
	CogworkCleanser,

	[EnumMember(Value = "cogwork_defender")]
	CogworkDefender,

	[EnumMember(Value = "cogwork_clapper")]
	CogworkClapper,

	[EnumMember(Value = "vaultborn")]
	Vaultborn,

	[EnumMember(Value = "lampbearer")]
	Lampbearer,

	[EnumMember(Value = "scrollreader")]
	Scrollreader,

	[EnumMember(Value = "vaultkeeper")]
	Vaultkeeper,

	[EnumMember(Value = "penitent")]
	Penitent,

	[EnumMember(Value = "puny_penitent")]
	PunyPenitent,

	[EnumMember(Value = "freshfly")]
	Freshfly,

	[EnumMember(Value = "scabfly")]
	Scabfly,

	[EnumMember(Value = "guardfly")]
	Guardfly,

	[EnumMember(Value = "wardenfly")]
	Wardenfly,

	[EnumMember(Value = "driftlin")]
	Driftlin,

	[EnumMember(Value = "mnemonid")]
	Mnemonid,

	[EnumMember(Value = "mnemonord")]
	Mnemonord,

	[EnumMember(Value = "servitor_ignim")]
	ServitorIgnim,

	[EnumMember(Value = "servitor_boran")]
	ServitorBoran,

	[EnumMember(Value = "winged_lifeseed")]
	WingedLifeseed,

	[EnumMember(Value = "plasmid")]
	Plasmid,

	[EnumMember(Value = "plasmidas")]
	Plasmidas,

	[EnumMember(Value = "leaf_glider")]
	LeafGlider,

	[EnumMember(Value = "leaf_roller")]
	LeafRoller,

	[EnumMember(Value = "pendra")]
	Pendra,

	[EnumMember(Value = "pendragor")]
	Pendragor,

	[EnumMember(Value = "nuphar")]
	Nuphar,

	[EnumMember(Value = "cloverstag")]
	Cloverstag,

	[EnumMember(Value = "kindanir")]
	Kindanir,

	[EnumMember(Value = "verdanir")]
	Verdanir,

	[EnumMember(Value = "escalion")]
	Escalion,

	[EnumMember(Value = "shadow_creeper")]
	ShadowCreeper,

	[EnumMember(Value = "shadow_charger")]
	ShadowCharger,

	[EnumMember(Value = "gloomsac")]
	Gloomsac,

	[EnumMember(Value = "gargant_gloom")]
	GargantGloom,

	[EnumMember(Value = "void_tendrils")]
	VoidTendrils,

	[EnumMember(Value = "void_mass")]
	VoidMass,

	[EnumMember(Value = "wingmould")]
	Wingmould,

	[EnumMember(Value = "garpid")]
	Garpid,

	[EnumMember(Value = "imoba")]
	Imoba,

	[EnumMember(Value = "skrill")]
	Skrill,
}
