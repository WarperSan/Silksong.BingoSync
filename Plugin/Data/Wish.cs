using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every wish the player can accept
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum Wish
{
	[EnumMember(Value = "the_lost_fleas")]
	TheLostFleas,

	[EnumMember(Value = "pinmasters_oil")]
	PinmastersOil,

	[EnumMember(Value = "my_missing_courier")]
	MyMissingCourier,

	[EnumMember(Value = "my_missing_brother")]
	MyMissingBrother,

	[EnumMember(Value = "balm_for_the_wounded")]
	BalmForTheWounded,

	[EnumMember(Value = "the_wandering_merchant")]
	TheWanderingMerchant,

	[EnumMember(Value = "the_lost_merchant")]
	TheLostMerchant,

	[EnumMember(Value = "rite_of_rebirth")]
	RiteOfRebirth,

	[EnumMember(Value = "infestation_operation")]
	InfestationOperation,

	[EnumMember(Value = "trails_end")]
	TrailsEnd,

	[EnumMember(Value = "final_audience")]
	FinalAudience,

	[EnumMember(Value = "silk_and_soul")]
	SilkAndSoul,

	[EnumMember(Value = "fatal_resolve")]
	FatalResolve,

	[EnumMember(Value = "pain_anguish_and_misery")]
	PainAnguishAndMisery,

	[EnumMember(Value = "heros_call")]
	HerosCall,

	[EnumMember(Value = "ecstasy_of_the_end")]
	EcstasyOfTheEnd,

	[EnumMember(Value = "berry_picking")]
	BerryPicking,

	[EnumMember(Value = "rite_of_the_pollip")]
	RiteOfThePollip,

	[EnumMember(Value = "silver_bells")]
	SilverBells,

	[EnumMember(Value = "alchemists_assistant")]
	AlchemistsAssistant,

	[EnumMember(Value = "great_taste_of_pharloom")]
	GreatTasteOfPharloom,

	[EnumMember(Value = "advanced_alchemy")]
	AdvancedAlchemy,

	[EnumMember(Value = "garb_of_the_pilgrims")]
	GarbOfThePilgrims,

	[EnumMember(Value = "flexile_spines")]
	FlexileSpines,

	[EnumMember(Value = "volatile_flintbeetles")]
	VolatileFlintbeetles,

	[EnumMember(Value = "crawbug_clearing")]
	CrawbugClearing,

	[EnumMember(Value = "roach_guts")]
	RoachGuts,

	[EnumMember(Value = "fine_pins")]
	FinePins,

	[EnumMember(Value = "cloaks_of_the_choir")]
	CloaksOfTheChoir,

	[EnumMember(Value = "broodfeast")]
	Broodfeast,

	[EnumMember(Value = "runtfeast")]
	Runtfeast,

	[EnumMember(Value = "dark_hearts")]
	DarkHearts,

	[EnumMember(Value = "the_terrible_tyrant")]
	TheTerribleTyrant,

	[EnumMember(Value = "savage_beastfly")]
	SavageBeastfly,

	[EnumMember(Value = "the_wailing_mother")]
	TheWailingMother,

	[EnumMember(Value = "the_hidden_hunter")]
	TheHiddenHunter,

	[EnumMember(Value = "bone_bottom_repairs")]
	BoneBottomRepairs,

	[EnumMember(Value = "a_lifesaving_bridge")]
	ALifesavingBridge,

	[EnumMember(Value = "restoration_of_bellhart")]
	RestorationOfBellhart,

	[EnumMember(Value = "an_icon_of_hope")]
	AnIconOfHope,

	[EnumMember(Value = "bellharts_glory")]
	BellhartsGlory,

	[EnumMember(Value = "building_up_songclave")]
	BuildingUpSongclave,

	[EnumMember(Value = "strengthening_songclave")]
	StrengtheningSongclave,

	[EnumMember(Value = "bone_bottom_supplies")]
	BoneBottomSupplies,

	[EnumMember(Value = "pilgrims_rest_supplies")]
	PilgrimsRestSupplies,

	[EnumMember(Value = "queens_egg")]
	QueensEgg,

	[EnumMember(Value = "songclave_supplies")]
	SongclaveSupplies,

	[EnumMember(Value = "fleatopia_supplies")]
	FleatopiaSupplies,

	[EnumMember(Value = "liquid_lacquer")]
	LiquidLacquer,

	[EnumMember(Value = "survivors_camp_supplies")]
	SurvivorsCampSupplies,

	[EnumMember(Value = "bugs_of_pharloom")]
	BugsOfPharloom,

	[EnumMember(Value = "fastest_in_pharloom")]
	FastestInPharloom,

	[EnumMember(Value = "passing_of_the_age")]
	PassingOfTheAge,

	[EnumMember(Value = "a_vassal_lost")]
	AVassalLost,
}
