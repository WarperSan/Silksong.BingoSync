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
	public static bool HasJournalEntry(this PlayerData data, Boss boss)
	{
		return boss switch
		{
			Boss.Shakra => data.HasJournalEntry("Shakra"),
			Boss.BellBeast => throw new NotImplementedException(),
			Boss.FourthChorus => throw new NotImplementedException(),
			Boss.GreatConchflies => throw new NotImplementedException(),
			Boss.Lace1 => throw new NotImplementedException(),
			Boss.LastJudge => throw new NotImplementedException(),
			Boss.Moorwing => throw new NotImplementedException(),
			Boss.MossMother => data.HasJournalEntry("Mossbone Mother"),
			Boss.MossMothers => data.GetKillCount("Mossbone Mother") >= 3,
			Boss.Phantom => throw new NotImplementedException(),
			Boss.SavageBeastfly1 => throw new NotImplementedException(),
			Boss.SisterSplinter => throw new NotImplementedException(),
			Boss.SkullTyrant1 => data.HasJournalEntry("Skull King"),
			Boss.SkullTyrant2 => data.GetKillCount("Skull King") >= 2,
			Boss.Widow => throw new NotImplementedException(),
			Boss.Broodmother => throw new NotImplementedException(),
			Boss.CogworkDancers => throw new NotImplementedException(),
			Boss.DisgracedChefLugoli => throw new NotImplementedException(),
			Boss.FatherOfTheFlame => throw new NotImplementedException(),
			Boss.FirstSinner => throw new NotImplementedException(),
			Boss.Forebrothers => throw new NotImplementedException(),
			Boss.Garmond => data.HasJournalEntry("Garmond"),
			Boss.GrandMotherSilk => throw new NotImplementedException(),
			Boss.Groal => throw new NotImplementedException(),
			Boss.Lace2 => throw new NotImplementedException(),
			Boss.RagingConchfly => throw new NotImplementedException(),
			Boss.SavageBeastfly2 => throw new NotImplementedException(),
			Boss.SecondSentinel => throw new NotImplementedException(),
			Boss.TheUnravelled => throw new NotImplementedException(),
			Boss.Trobbio => throw new NotImplementedException(),
			Boss.Voltvyrm => throw new NotImplementedException(),
			Boss.BellEater => data.HasJournalEntry("Giant Centipede"),
			Boss.CloverDancers => throw new NotImplementedException(),
			Boss.Crawfather => throw new NotImplementedException(),
			Boss.CrustKingKhann => throw new NotImplementedException(),
			Boss.GurrTheOutcast => throw new NotImplementedException(),
			Boss.LostGarmond => throw new NotImplementedException(),
			Boss.LostLace => throw new NotImplementedException(),
			Boss.Nyleth => throw new NotImplementedException(),
			Boss.Palestag => throw new NotImplementedException(),
			Boss.Pinstress => data.HasJournalEntry("Pinstress Boss"),
			Boss.PlasmifiedZango => throw new NotImplementedException(),
			Boss.ShrineGuardianSeth => throw new NotImplementedException(),
			Boss.SkarrsingerKarmelita => throw new NotImplementedException(),
			Boss.TormentedTrobbio => throw new NotImplementedException(),
			Boss.Watcher => throw new NotImplementedException(),
			_ => throw new InvalidCheckException<Boss>(boss),
		};
	}
}
