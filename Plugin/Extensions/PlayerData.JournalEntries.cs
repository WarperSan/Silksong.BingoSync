using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning journal entries
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	/// <summary>
	/// Gets the key of the given <see cref="Enemy"/>
	/// </summary>
	private static string GetKey(this Enemy enemy)
	{
		return enemy switch
		{
			Enemy.Mossgrub => "MossBone Crawler",
			Enemy.MassiveMossgrub => "MossBone Crawler Fat",
			Enemy.Mossmir => "MossBone Fly",
			Enemy.Aknid => "Aspid Collector",
			Enemy.SkullScuttler => "Bone Goomba",
			Enemy.Skullwing => "Bone Goomba Bounce Fly",
			Enemy.SkullBrute => "Bone Goomba Large",
			Enemy.Kilik => "Bone Crawler",
			Enemy.Beastfly => "Bone Flyer",
			Enemy.Caranid => "Bone Circler",
			Enemy.ViciousCaranid => "Bone Circler Vicious",
			Enemy.HardboneHopper => "Bone Hopper",
			Enemy.HardboneElder => "Bone Hopper Giant",
			Enemy.Tarmite => "Bone Splitter",
			Enemy.Mawling => "Bone Roller",
			Enemy.Marrowmaw => "Bone Thumper",
			Enemy.Hoker => "Spine Floater",
			Enemy.Flintbeetle => "Rock Roller",
			Enemy.Rhinogrund => "Rhino",
			Enemy.Gromling => "Crypt Worm",
			Enemy.Grom => "Bone Worm",
			Enemy.PilgrimGroveller => "Pilgrim 03",
			Enemy.PilgrimPouncer => "Pilgrim 01",
			Enemy.PilgrimHornfly => "Pilgrim 04",
			Enemy.PilgrimHulk => "Pilgrim 02",
			Enemy.PilgrimBellbearer => "Pilgrim Bell Thrower",
			Enemy.WingedPilgrim => "Pilgrim Fly",
			Enemy.ElderPilgrim => "Pilgrim 05",
			Enemy.WingedPilgrimBellbearer => "Pilgrim Bellthrower Fly",
			Enemy.PilgrimHiker => "Pilgrim Hiker",
			Enemy.PilgrimGuide => "Pilgrim StaffWielder",
			Enemy.OvergrownPilgrim => "Pilgrim Moss Spitter",
			Enemy.CovetousPilgrim => "Rosary Pilgrim",
			Enemy.Snitchfly => "Rosary Thief",
			Enemy.Lavalug => "Tar Slug",
			Enemy.Lavalarga => "Tar Slug Huge",
			Enemy.SmeltShoveller => "Dock Worker",
			Enemy.FlintstoneFlyer => "Dock Flyer",
			Enemy.FlintflameFlyer => "Dock Bomber",
			Enemy.SmokerockSifter => "Shield Dock Worker",
			Enemy.DeepDiver => "Dock Charger",
			Enemy.Cragglite => "Small Crab",
			Enemy.Craggler => "Roof Crab",
			Enemy.Brushflit => "Fields Flock Flyers",
			Enemy.Fertid => "Fields Goomba",
			Enemy.FlappingFertid => "Fields Flyer",
			Enemy.Skarrlid => "Bone Hunter Tiny",
			Enemy.Skarrwing => "Bone Hunter Buzzer",
			Enemy.SkarrScout => "Bone Hunter Child",
			Enemy.SkarrStalker => "Bone Hunter",
			Enemy.SpearSkarr => "Bone Hunter Fly",
			Enemy.Skarrgard => "Bone Hunter Throw",
			Enemy.LastClaw => "Bone Hunter Chief",
			Enemy.Mite => "Mite",
			Enemy.Fluttermite => "Mitefly",
			Enemy.Mitemother => "Gnat Giant",
			Enemy.DregCatcher => "Farmer Catcher",
			Enemy.SilkSnipper => "Farmer Scissors",
			Enemy.ThreadRaker => "Farmer Centipede",
			Enemy.Wisp => "Wisp",
			Enemy.BurningBug => "Farmer Wisp",
			Enemy.Craw => "Crow",
			Enemy.Tallcraw => "Crowman",
			Enemy.Squatcraw => "Crowman Dagger",
			Enemy.CrawJuror => "Crowman Juror Tiny",
			Enemy.TallcrawJuror => "Crowman Juror",
			Enemy.SquatcrawJuror => "Crowman Dagger Juror",
			Enemy.Muckmaggot => "Maggots",
			Enemy.Slubberlug => "Dustroach Pollywog",
			Enemy.Muckroach => "Dustroach",
			Enemy.Bloatroach => "Bloat Roach",
			Enemy.Roachcatcher => "Roachfeeder Short",
			Enemy.Roachfeeder => "Roachfeeder Tall",
			Enemy.Roachkeeper => "Roachkeeper",
			Enemy.Roachserver => "Roachkeeper Chef Tiny",
			Enemy.Wraith => "Wraith",
			Enemy.MothleafLagnia => "Swamp Drifter",
			Enemy.Miremite => "Swamp Goomba",
			Enemy.SwampSquit => "Swamp Mosquito",
			Enemy.SpitSquit => "Swamp Mosquito Skinny",
			Enemy.Stilkin => "Swamp Muckman",
			Enemy.StilkinTrapper => "Swamp Muckman Tall",
			Enemy.Barnak => "Swamp Barnacle",
			Enemy.Ductsucker => "Swamp Ductsucker",
			Enemy.PondSkipper => "Pond Skater",
			Enemy.Pondcatcher => "Pilgrim Fisher",
			Enemy.ShellwoodGnat => "Shellwood Gnat",
			Enemy.WoodWasp => "Shellwood Wasp",
			Enemy.Splinter => "Stick Insect",
			Enemy.Splinterhorn => "Stick Insect Charger",
			Enemy.Splinterbark => "Stick Insect Flyer",
			Enemy.Phacia => "Flower Drifter",
			Enemy.Pollenica => "Bloom Shooter",
			Enemy.Gahlia => "Bloom Puncher",
			Enemy.Furm => "Bell Goomba",
			Enemy.WingedFurm => "Bell Fly",
			Enemy.Pharlid => "Blade Spider",
			Enemy.PharlidDiver => "Blade Spider Hang",
			Enemy.Shardillard => "Shell Fossil Mimic",
			Enemy.Sandcarver => "Sand Centipede",
			Enemy.Squirrm => "Coral Judge Child",
			Enemy.Judge => "Coral Judge",
			Enemy.CoralFurm => "Coral Spike Goomba",
			Enemy.Driznit => "Coral Conch Shooter",
			Enemy.Driznarga => "Coral Conch Shooter Heavy",
			Enemy.Pokenabbin => "Coral Conch Stabber",
			Enemy.Conchfly => "Coral Conch Driller",
			Enemy.Crustcrawler => "Coral Goombas",
			Enemy.Crustcrag => "Coral Goomba Large",
			Enemy.Kai => "Coral Swimmer Fat",
			Enemy.SpinebeakKai => "Poke Swimmer",
			Enemy.SteelspineKai => "Spike Swimmer",
			Enemy.Yuma => "Coral Swimmer Small",
			Enemy.Yumama => "Coral Big Jellyfish",
			Enemy.Karaka => "Coral Warrior",
			Enemy.Kakri => "Coral Flyer",
			Enemy.Yago => "Coral Flyer Throw",
			Enemy.KarakGor => "Coral Brawler",
			Enemy.Alita => "Coral Hunter",
			Enemy.CorrcrustKaraka => "Coral Bubble Brute",
			Enemy.Drapefly => "Citadel Bat",
			Enemy.Drapelord => "Citadel Bat Large",
			Enemy.Drapemite => "Mite Heavy",
			Enemy.GiantDrapemite => "Understore Mite Giant",
			Enemy.Underworker => "Understore Small",
			Enemy.Underscrub => "Pilgrim 03 Understore",
			Enemy.Undersweep => "Pilgrim Staff Understore",
			Enemy.Underpoke => "Understore Poker",
			Enemy.Underloft => "Understore Thrower",
			Enemy.Undercrank => "Understore Heavy",
			Enemy.Envoy => "Song Pilgrim 01",
			Enemy.ChoirPouncer => "Pilgrim 01 Song",
			Enemy.ChoirHornhead => "Pilgrim 02 Song",
			Enemy.ChoirBellbearer => "Pilgrim 03 Song",
			Enemy.ChoirFlyer => "Pilgrim 04 Song",
			Enemy.ChoirElder => "Pilgrim Stomper Song",
			Enemy.Choristor => "Song Pilgrim 03",
			Enemy.Reed => "Song Reed",
			Enemy.GrandReed => "Song Reed Grand",
			Enemy.ChoirClapper => "Song Heavy Sentry",
			Enemy.Clawmaiden => "Song Handmaiden",
			Enemy.Memoria => "Arborium Keeper",
			Enemy.Minister => "Song Administrator",
			Enemy.Maestro => "Song Pilgrim Maestro",
			Enemy.DregHusk => "Song Threaded Husk",
			Enemy.Dregwheel => "Song Threaded Husk Spin",
			Enemy.Surgeon => "Song Pilgrim 02",
			Enemy.Mortician => "Song Creeper",
			Enemy.CogworkUnderfly => "Understore Automaton",
			Enemy.CogworkHauler => "Understore Automaton EX",
			Enemy.CogworkCrawler => "Song Automaton Goomba",
			Enemy.Cogworker => "Song Automaton Fly",
			Enemy.CogworkSpine => "Song Automaton Fly Spike",
			Enemy.CogworkChoirbug => "Song Automaton 01",
			Enemy.CogworkCleanser => "Song Automaton 02",
			Enemy.CogworkDefender => "Song Automaton Shield",
			Enemy.CogworkClapper => "Song Automaton Ball",
			Enemy.Vaultborn => "Song Scholar Acolyte",
			Enemy.Lampbearer => "Lightbearer",
			Enemy.Scrollreader => "Scrollkeeper",
			Enemy.Vaultkeeper => "Scholar",
			Enemy.Penitent => "Slab Prisoner Leaper New",
			Enemy.PunyPenitent => "Slab Prisoner Fly New",
			Enemy.Freshfly => "Slab Fly Small Fresh",
			Enemy.Scabfly => "Slab Fly Small",
			Enemy.Guardfly => "Slab Fly Mid",
			Enemy.Wardenfly => "Slab Fly Large",
			Enemy.Driftlin => "Peaks Drifter",
			Enemy.Mnemonid => "Crystal Drifter",
			Enemy.Mnemonord => "Crystal Drifter Giant",
			Enemy.ServitorIgnim => "Weaver Servitor",
			Enemy.ServitorBoran => "Weaver Servitor Large",
			Enemy.WingedLifeseed => "Lifeblood Fly",
			Enemy.Plasmid => "Bone Worm BlueBlood",
			Enemy.Plasmidas => "Bone Worm BlueTurret",
			Enemy.LeafGlider => "Lilypad Fly",
			Enemy.LeafRoller => "Grass Goomba",
			Enemy.Pendra => "Hornet Dragonfly",
			Enemy.Pendragor => "Dragonfly Large",
			Enemy.Nuphar => "Lilypad Trap",
			Enemy.Cloverstag => "Cloverstag",
			Enemy.Kindanir => "Grasshopper Child",
			Enemy.Verdanir => "Grasshopper Slasher",
			Enemy.Escalion => "Grasshopper Fly",
			Enemy.ShadowCreeper => "Abyss Crawler",
			Enemy.ShadowCharger => "Abyss Crawler Large",
			Enemy.Gloomsac => "Gloomfly",
			Enemy.GargantGloom => "Gloom Beast",
			Enemy.VoidTendrils => "Void Tendrils",
			Enemy.VoidMass => "Black Thread Core",
			Enemy.Wingmould => "White Palace Fly",
			Enemy.Garpid => "Centipede Trap",
			Enemy.Imoba => "Spike Lazy Flyer",
			Enemy.Skrill => "Surface Scuttler",
			_ => throw new InvalidCheckException<Enemy>(enemy),
		};
	}

	/// <summary>
	/// Gets the <see cref="EnemyJournalKillData.KillData"/> of the given key
	/// </summary>
	private static EnemyJournalKillData.KillData GetKillData(this PlayerData data, string key) =>
		data.EnemyJournalKillData.GetKillData(key);

	/// <summary>
	/// Gets the amount of kills of the journal entry of the given key
	/// </summary>
	private static int GetKillCount(this PlayerData data, string key) =>
		data.GetKillData(key).Kills;

	/// <summary>
	/// Checks if a journal entry is set for the given key
	/// </summary>
	private static bool HasJournalEntry(this PlayerData data, string key) =>
		data.GetKillCount(key) > 0;

	/// <summary>
	/// Checks if the journal entry of the given <see cref="Boss"/> has been obtained
	/// </summary>
	public static bool HasObtainedJournalEntry(this PlayerData data, Boss boss)
	{
		return boss switch
		{
			Boss.Shakra => data.HasJournalEntry("Shakra"),
			Boss.BellBeast => data.HasJournalEntry("Bone Beast"),
			Boss.FourthChorus => data.HasJournalEntry("Song Golem"),
			Boss.GreatConchflies or Boss.RagingConchfly => data.HasJournalEntry(
				"Coral Conch Driller Giant"
			),
			Boss.Lace1 or Boss.Lace2 => data.HasJournalEntry("Lace"),
			Boss.LastJudge => data.HasJournalEntry("Last Judge"),
			Boss.Moorwing => data.HasJournalEntry("Vampire Gnat"),
			Boss.MossMother => data.HasJournalEntry("Mossbone Mother"),
			Boss.MossMothers => data.GetKillCount("Mossbone Mother") >= 3,
			Boss.Phantom => data.HasJournalEntry("Phantom"),
			Boss.SavageBeastfly1 or Boss.SavageBeastfly2 => data.HasJournalEntry(
				"Bone Flyer Giant"
			),
			Boss.SisterSplinter => data.HasJournalEntry("Splinter Queen"),
			Boss.SkullTyrant1 => data.HasJournalEntry("Skull King"),
			Boss.SkullTyrant2 => data.GetKillCount("Skull King") >= 2,
			Boss.Widow => data.HasJournalEntry("Spinner Boss"),
			Boss.Broodmother => data.HasJournalEntry("Slab Fly Broodmother"),
			Boss.CogworkDancers => data.HasJournalEntry("Clockwork Dancer"),
			Boss.DisgracedChefLugoli => data.HasJournalEntry("Roachkeeper Chef"),
			Boss.FatherOfTheFlame => data.HasJournalEntry("Wisp Pyre Effigy"),
			Boss.FirstSinner => data.HasJournalEntry("First Weaver"),
			Boss.Forebrothers => data.HasJournalEntry("Dock Guard Thrower"),
			Boss.Garmond => data.HasJournalEntry("Garmond"),
			Boss.GrandMotherSilk => data.HasJournalEntry("Silk Boss"),
			Boss.Groal => data.HasJournalEntry("Swamp Shaman"),
			Boss.SecondSentinel => data.HasJournalEntry("Song Knight"),
			Boss.TheUnravelled => data.HasJournalEntry("Conductor Boss"),
			Boss.Trobbio => data.HasJournalEntry("Trobbio"),
			Boss.Voltvyrm => data.HasJournalEntry("Zap Core Enemy"),
			Boss.BellEater => data.HasJournalEntry("Giant Centipede"),
			Boss.CloverDancers => data.HasJournalEntry("Clover Dancer"),
			Boss.Crawfather => data.HasJournalEntry("Crawfather"),
			Boss.CrustKingKhann => data.HasJournalEntry("Coral King"),
			Boss.GurrTheOutcast => data.HasJournalEntry("Bone Hunter Trapper"),
			Boss.LostGarmond => data.HasJournalEntry("Garmond"),
			Boss.LostLace => data.HasJournalEntry("Lost Lace"),
			Boss.Nyleth => data.HasJournalEntry("Flower Queen"),
			Boss.Palestag => data.HasJournalEntry("Cloverstag White"),
			Boss.Pinstress => data.HasJournalEntry("Pinstress Boss"),
			Boss.PlasmifiedZango => data.HasJournalEntry("Blue Assistant"),
			Boss.ShrineGuardianSeth => data.HasJournalEntry("Seth"),
			Boss.SkarrsingerKarmelita => data.HasJournalEntry("Hunter Queen"),
			Boss.TormentedTrobbio => data.HasJournalEntry("Tormented Trobbio"),
			Boss.Watcher => data.HasJournalEntry("Coral Warrior Grey"),
			_ => throw new InvalidCheckException<Boss>(boss),
		};
	}

	/// <summary>
	/// Checks if the journal entry of the given <see cref="Enemy"/> has been obtained
	/// </summary>
	public static bool HasObtainedJournalEntry(this PlayerData data, Enemy enemy)
	{
		var key = enemy.GetKey();

		return data.HasJournalEntry(key);
	}
}
