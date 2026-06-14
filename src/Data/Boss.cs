using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every boss the player can kill
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum Boss
{
	[EnumMember(Value = "bell_beast")]
	BellBeast,

	[EnumMember(Value = "fourth_chorus")]
	FourthChorus,

	[EnumMember(Value = "great_conchflies")]
	GreatConchflies,

	[EnumMember(Value = "lace_1")]
	Lace1,

	[EnumMember(Value = "last_judge")]
	LastJudge,

	[EnumMember(Value = "Moorwing")]
	Moorwing,

	[EnumMember(Value = "moss_mother_1")]
	MossMother1,

	[EnumMember(Value = "moss_mothers")]
	MossMothers,

	[EnumMember(Value = "phantom")]
	Phantom,

	[EnumMember(Value = "savage_beastfly_1")]
	SavageBeastfly1,

	[EnumMember(Value = "sister_splinter")]
	SisterSplinter,

	[EnumMember(Value = "skull_tyrant_1")]
	SkullTyrant1,

	[EnumMember(Value = "skull_tyrant_2")]
	SkullTyrant2,

	[EnumMember(Value = "Widow")]
	Widow,

	[EnumMember(Value = "Broodmother")]
	Broodmother,

	[EnumMember(Value = "cogwork_dancers")]
	CogworkDancers,

	[EnumMember(Value = "disgraced_chef_lugoli")]
	DisgracedChefLugoli,

	[EnumMember(Value = "father_of_the_flame")]
	FatherOfTheFlame,

	[EnumMember(Value = "first_sinner")]
	FirstSinner,

	[EnumMember(Value = "forebrothers")]
	Forebrothers,

	[EnumMember(Value = "garmond")]
	Garmond,

	[EnumMember(Value = "grand_mother_silk")]
	GrandMotherSilk,

	[EnumMember(Value = "groal_the_great")]
	Groal,

	[EnumMember(Value = "lace_2")]
	Lace2,

	[EnumMember(Value = "raging_conchfly")]
	RagingConchfly,

	[EnumMember(Value = "savage_beastfly_2")]
	SavageBeastfly2,

	[EnumMember(Value = "second_sentinel")]
	SecondSentinel,

	[EnumMember(Value = "Shakra")]
	Shakra,

	[EnumMember(Value = "the_unravelled")]
	TheUnravelled,

	[EnumMember(Value = "Trobbio")]
	Trobbio,

	[EnumMember(Value = "Voltvyrm")]
	Voltvyrm,

	[EnumMember(Value = "bell_eater")]
	BellEater,

	[EnumMember(Value = "clover_dancers")]
	CloverDancers,

	[EnumMember(Value = "Crawfather")]
	Crawfather,

	[EnumMember(Value = "crust_king_khann")]
	CrustKingKhann,

	[EnumMember(Value = "gurr_the_outcast")]
	GurrTheOutcast,

	[EnumMember(Value = "lost_garmond")]
	LostGarmond,

	[EnumMember(Value = "lost_lace")]
	LostLace,

	[EnumMember(Value = "Nyleth")]
	Nyleth,

	[EnumMember(Value = "Palestag")]
	Palestag,

	[EnumMember(Value = "Pinstress")]
	Pinstress,

	[EnumMember(Value = "plasmified_zango")]
	PlasmifiedZango,

	[EnumMember(Value = "shrine_guardian_seth")]
	ShrineGuardianSeth,

	[EnumMember(Value = "skarrsinger_karmelita")]
	SkarrsingerKarmelita,

	[EnumMember(Value = "tormented_trobbio")]
	TormentedTrobbio,

	[EnumMember(Value = "watcher_at_the_edge")]
	Watcher,
}

//[EnumMember(Value = "radiance")]
//Radiance,