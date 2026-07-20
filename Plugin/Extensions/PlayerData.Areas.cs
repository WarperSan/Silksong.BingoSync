using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="Area"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	/// <summary>
	/// Checks if the map of the given <see cref="Area"/> was obtained
	/// </summary>
	public static bool HasObtainedMap(this PlayerData data, Area area)
	{
		return area switch
		{
			Area.TheAbyss => data.HasAbyssMap,
			Area.Bellhart => data.HasBellhartMap,
			Area.Bilewater => data.HasSwampMap,
			Area.BlastedSteps => data.HasJudgeStepsMap,
			Area.BoneBottom => data.HasMossGrottoMap,
			Area.TheCradle => data.HasCradleMap,
			Area.DeepDocks => data.HasDocksMap,
			Area.FarFields => data.HasWildsMap,
			Area.Greymoor => data.HasGreymoorMap,
			Area.HuntersMarch => data.HasHuntersNestMap,
			Area.TheMarrow => data.HasBoneforestMap,
			Area.TheMist => false,
			Area.MossGrotto => false,
			Area.MountFay => data.HasPeakMap,
			Area.PutrifiedDucts => data.HasAqueductMap,
			Area.RedMemory => false,
			Area.SandsOfKarak => data.HasCoralMap,
			Area.Shellwood => data.HasShellwoodMap,
			Area.SinnersRoad => data.HasDustpensMap,
			Area.TheSlab => data.HasSlabMap,
			Area.Underworks => data.HasCitadelUnderstoreMap,
			Area.Verdania => data.HasCloverMap,
			Area.WeavenestAtla => data.HasWeavehomeMap,
			Area.WispThicket => false,
			Area.Wormways => data.HasCrawlMap,
			Area.ChoralChambers => data.HasHallsMap, // TODO: Check if this check is actually valid
			Area.CogworkCore => data.HasCogMap,
			Area.GrandGate => data.HasSongGateMap,
			Area.HighHalls => data.HasHangMap,
			Area.Memorium => data.HasArboriumMap,
			Area.WhisperingVaults => data.HasLibraryMap,
			Area.Whiteward => data.HasWardMap,
			_ => throw new InvalidCheckException<Area>(area),
		};
	}
}
