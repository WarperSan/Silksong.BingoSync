using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="Boss"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	/// <summary>
	/// Checks if the given <see cref="Boss"/> was killed
	/// </summary>
	public static bool IsBossKilled(this PlayerData data, Boss boss) => boss switch
	{
		Boss.BellBeast           => data.defeatedBellBeast,
		Boss.FourthChorus        => data.defeatedSongGolem,
		Boss.GreatConchflies     => data.defeatedCoralDrillers,
		Boss.Lace1               => data.defeatedLace1,
		Boss.LastJudge           => data.defeatedLastJudge,
		Boss.Moorwing            => data.defeatedVampireGnatBoss,
		Boss.MossMother          => data.defeatedMossMother,
		Boss.MossMothers         => data.HasJournalEntry(Boss.MossMothers),
		Boss.Phantom             => data.defeatedPhantom,
		Boss.SavageBeastfly1     => data.defeatedBoneFlyerGiant,
		Boss.SisterSplinter      => data.defeatedSplinterQueen,
		Boss.SkullTyrant1        => data.skullKingDefeated,
		Boss.SkullTyrant2        => data.HasJournalEntry(Boss.SkullTyrant2),
		Boss.Widow               => data.spinnerDefeated,
		Boss.Broodmother         => data.defeatedBroodMother,
		Boss.CogworkDancers      => data.defeatedCogworkDancers,
		Boss.DisgracedChefLugoli => data.defeatedRoachkeeperChef,
		Boss.FatherOfTheFlame    => data.defeatedWispPyreEffigy,
		Boss.FirstSinner         => data.defeatedFirstWeaver,
		Boss.Forebrothers        => data.defeatedDockForemen,
		Boss.Garmond             => data.HasJournalEntry(Boss.Garmond),
		Boss.GrandMotherSilk => data.IsEndingCompleted(Ending.WeaverQueen) || data.IsEndingCompleted(Ending.SnaredSilk)
		                                                                   || data.IsEndingCompleted(Ending.TwistedChild),
		Boss.Groal                => data.DefeatedSwampShaman,
		Boss.Lace2                => data.defeatedLaceTower,
		Boss.RagingConchfly       => data.defeatedCoralDrillerSolo,
		Boss.SavageBeastfly2      => data.defeatedBoneFlyerGiantGolemScene,
		Boss.SecondSentinel       => data.defeatedSongChevalierBoss,
		Boss.Shakra               => data.HasJournalEntry(Boss.Shakra),
		Boss.TheUnravelled        => data.wardBossDefeated,
		Boss.Trobbio              => data.defeatedTrobbio,
		Boss.Voltvyrm             => data.defeatedZapCoreEnemy,
		Boss.BellEater            => data.HasJournalEntry(Boss.BellEater),
		Boss.CloverDancers        => data.defeatedCloverDancers,
		Boss.Crawfather           => data.defeatedCrowCourt,
		Boss.CrustKingKhann       => data.defeatedCoralKing,
		Boss.GurrTheOutcast       => data.defeatedAntTrapper,
		Boss.LostGarmond          => data.garmondBlackThreadDefeated,
		Boss.LostLace             => data.IsEndingCompleted(Ending.SisterOfTheVoid),
		Boss.Nyleth               => data.defeatedFlowerQueen,
		Boss.Palestag             => data.defeatedWhiteCloverstag,
		Boss.Pinstress            => data.HasJournalEntry(Boss.Pinstress),
		Boss.PlasmifiedZango      => data.BlueScientistDead,
		Boss.ShrineGuardianSeth   => data.defeatedSeth,
		Boss.SkarrsingerKarmelita => data.defeatedAntQueen,
		Boss.TormentedTrobbio     => data.defeatedTormentedTrobbio,
		Boss.Watcher              => data.defeatedGreyWarrior,
		_                         => throw new InvalidCheckException<Boss>(boss),
	};
}