using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="Flea"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	/// <summary>
	/// Checks if the given <see cref="Flea"/> was found
	/// </summary>
	public static bool HasFoundFlea(this PlayerData data, Flea flea)
	{
		return flea switch
		{
			Flea.AboveMarrowBellways => data.SavedFlea_Bone_06,
			Flea.BehindDeepDocksBellways => data.SavedFlea_Dock_16,
			Flea.LeftOfSwiftStep => data.SavedFlea_Bone_East_05,
			Flea.BehindDeepDocksFurnaceGauntlet => data.SavedFlea_Dock_03d,
			Flea.BehindSkarrgard => data.SavedFlea_Ant_03,
			Flea.BehindBoobyTrap => data.SavedFlea_Bone_East_17b,
			Flea.NextToPilgrimsRest => data.SavedFlea_Bone_East_10_Church,
			Flea.CarriedByAknid => data.SavedFlea_Crawl_06,
			Flea.AboveCrawLake => data.SavedFlea_Greymoor_15b,
			Flea.TopOfGreymoorLeftTower => data.SavedFlea_Greymoor_06,
			Flea.Kratt => data.CaravanLechSaved,
			Flea.AboveBellhart => data.SavedFlea_Belltown_04,
			Flea.InGahliaPit => data.SavedFlea_Shellwood_03,
			Flea.AboveGrindle => data.SavedFlea_Coral_35,
			Flea.TrappedInSinnersRoad => data.SavedFlea_Dust_12,
			Flea.GuardedBySnitchflies => data.SavedFlea_Shadow_28,
			Flea.BesideExhaustOrgan => data.SavedFlea_Dust_09,
			Flea.AboveSecretBilewaterBench => data.SavedFlea_Shadow_10,
			Flea.AfterWispThicket => data.SavedFlea_Under_23,
			Flea.AcrossCogworkHaulersRoom => data.SavedFlea_Under_21,
			Flea.AfterChoralChambersPlatforming => data.SavedFlea_Song_14,
			Flea.AfterVerticalSawbladesRoom => data.SavedFlea_Song_11,
			Flea.HugeFlea => data.tamedGiantFlea,
			Flea.JailedInSlab => data.SavedFlea_Slab_Cell,
			Flea.AboveSlabBench => data.SavedFlea_Slab_06,
			Flea.FrozenInIce => data.SavedFlea_Peak_05c,
			Flea.UnderVoltnest => data.SavedFlea_Coral_24,
			Flea.Vog => data.MetTroupeHunterWild,
			Flea.RightOfSongclave => data.SavedFlea_Library_09,
			Flea.RightOfBoxPuzzle => data.SavedFlea_Library_01,
			_ => throw new InvalidCheckException<Flea>(flea),
		};
	}
}
