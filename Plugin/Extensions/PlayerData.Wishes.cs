using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="Wish"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	/// <summary>
	/// Gets the identifier of the given <see cref="Wish"/>
	/// </summary>
	private static string GetWishId(Wish wish)
	{
		return wish switch
		{
			// ReSharper disable StringLiteralTypo
			Wish.FlexileSpines => "Brolly Get",
			Wish.Broodfeast => "Huntress Quest",
			Wish.SilverBells => "Shiny Bell Goomba",
			Wish.VolatileFlintbeetles => "Rock Rollers",
			Wish.GarbOfThePilgrims => "Pilgrim Rags",
			Wish.FinePins => "Fine Pins",
			Wish.CloaksOfTheChoir => "Song Pilgrim Cloaks",
			Wish.RoachGuts => "Roach Killing",
			Wish.CrawbugClearing => "Crow Feathers",
			Wish.AdvancedAlchemy => "Extractor Blue Worms",
			Wish.RiteOfThePollip => "Shell Flowers",
			Wish.AlchemistsAssistant => "Extractor Blue",
			Wish.HerosCall => "Garmond Black Threaded",
			Wish.Runtfeast => "Huntress Quest Runt",
			Wish.GreatTasteOfPharloom => "Great Gourmand",
			Wish.TheLostFleas => "Save the Fleas",
			Wish.EcstasyOfTheEnd => "Flea Games",
			Wish.TheWanderingMerchant => "Save City Merchant",
			Wish.FinalAudience => "Song Knight",
			Wish.PassingOfTheAge => "Mr Mushroom",
			Wish.PinmastersOil => "A Pinsmiths Tools",
			Wish.SilkAndSoul => "Soul Snare",
			Wish.MyMissingCourier => "Save Courier Short",
			Wish.MyMissingBrother => "Save Courier Tall",
			Wish.SongclaveSupplies => "Courier Delivery Songclave",
			Wish.BellhartsGlory => "Belltown House Mid",
			Wish.RestorationOfBellhart => "Belltown House Start",
			Wish.BuildingUpSongclave => "Songclave Donation 1",
			Wish.TheTerribleTyrant => "Skull King",
			Wish.TheLostMerchant => "Save City Merchant Bridge",
			Wish.SavageBeastfly => "Beastfly Hunt",
			Wish.TrailsEnd => "Shakra Final Quest",
			Wish.StrengtheningSongclave => "Songclave Donation 2",
			Wish.TheHiddenHunter => "Ant Trapper",
			Wish.PainAnguishAndMisery => "Tormented Trobbio",
			Wish.AnIconOfHope => "Building Materials (Statue)",
			Wish.ALifesavingBridge => "Building Materials (Bridge)",
			Wish.DarkHearts => "Destroy Thread Cores",
			Wish.BoneBottomRepairs => "Building Materials",
			Wish.FastestInPharloom => "Sprintmaster Race",
			Wish.LiquidLacquer => "Courier Delivery Mask Maker",
			Wish.FleatopiaSupplies => "Courier Delivery Fleatopia",
			Wish.BugsOfPharloom => "Journal",
			Wish.BalmForTheWounded => "Save Sherma",
			Wish.QueensEgg => "Courier Delivery Dustpens Slave",
			Wish.PilgrimsRestSupplies => "Courier Delivery Pilgrims Rest",
			Wish.BerryPicking => "Mossberry Collection 1",
			Wish.InfestationOperation => "Doctor Curse Cure",
			Wish.BoneBottomSupplies => "Courier Delivery Bonebottom",
			Wish.SurvivorsCampSupplies => "Courier Delivery Fixer",
			Wish.RiteOfRebirth => "Wood Witch Curse",
			Wish.TheWailingMother => "Broodmother Hunt",
			Wish.AVassalLost => "Steel Sentinel Pt2",
			Wish.FatalResolve => "Pinstress Battle",
			// ReSharper restore StringLiteralTypo
			_ => throw new InvalidCheckException<Wish>(wish),
		};
	}

	/// <summary>
	/// Gets the data of the given <see cref="Wish"/>
	/// </summary>
	private static QuestCompletionData.Completion? GetWishData(this PlayerData data, Wish wish)
	{
		var id = GetWishId(wish);

		return data.QuestCompletionData.GetData(id);
	}

	/// <summary>
	/// Checks if the given <see cref="Wish"/> was completed
	/// </summary>
	public static bool HasCompletedWish(this PlayerData data, Wish wish)
	{
		var wishData = data.GetWishData(wish);

		if (!wishData.HasValue)
			return false;

		return wishData.Value.IsCompleted;
	}
}
