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
			Flea.TheMarrow => data.SavedFlea_Bone_06,
			Flea.DeepDocks1 => data.SavedFlea_Dock_16,
			Flea.DeepDocks2 => data.SavedFlea_Bone_East_05,
			Flea.DeepDocks3 => data.SavedFlea_Dock_03d,
			Flea.HuntersMarch => data.SavedFlea_Ant_03,
			Flea.FarFields1 => data.SavedFlea_Bone_East_17b,
			Flea.FarFields2 => data.SavedFlea_Bone_East_10_Church,
			Flea.Wormways => data.SavedFlea_Crawl_06,
			Flea.Greymoor1 => data.SavedFlea_Greymoor_15b,
			Flea.Greymoor2 => data.SavedFlea_Greymoor_06,
			Flea.Kratt => data.CaravanLechSaved,
			Flea.Bellhart => data.SavedFlea_Belltown_04,
			Flea.Shellwood => data.SavedFlea_Shellwood_03,
			Flea.BlastedSteps => data.SavedFlea_Coral_35,
			Flea.SinnersRoad => data.SavedFlea_Dust_12,
			Flea.Bilewater1 => data.SavedFlea_Shadow_28,
			Flea.Bilewater2 => data.SavedFlea_Dust_09,
			Flea.Bilewater3 => data.SavedFlea_Shadow_10,
			Flea.Underworks1 => data.SavedFlea_Under_23,
			Flea.Underworks2 => data.SavedFlea_Under_21,
			Flea.ChoralChambers1 => data.SavedFlea_Song_14,
			Flea.ChoralChambers2 => data.SavedFlea_Song_11,
			Flea.HugeFlea => data.tamedGiantFlea,
			Flea.TheSlab1 => data.SavedFlea_Slab_Cell,
			Flea.TheSlab2 => data.SavedFlea_Slab_06,
			Flea.MountFay => data.SavedFlea_Peak_05c,
			Flea.SandsOfKarak => data.SavedFlea_Coral_24,
			Flea.Vog => data.MetTroupeHunterWild,
			Flea.WhisperingVaults1 => data.SavedFlea_Library_09,
			Flea.WhisperingVaults2 => data.SavedFlea_Library_01,
			_ => throw new InvalidCheckException<Flea>(flea),
		};
	}
}
