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
	// TODO: Consider if it is better to associate Wish with Completion

	/// <summary>
	/// Gets the identifier of the given <see cref="Wish"/>
	/// </summary>
	private static string GetWishId(Wish wish) => wish switch
	{
		// ReSharper disable StringLiteralTypo
		/*Wish.TheLostFleas           => expr,
		Wish.PinmastersOil          => expr,
		Wish.MyMissingCourier       => expr,
		Wish.MyMissingBrother       => expr,
		Wish.BalmForTheWounded      => expr,
		Wish.TheWanderingMerchant   => expr,
		Wish.TheLostMerchant        => expr,
		Wish.RiteOfRebirth          => expr,
		Wish.InfestationOperation   => expr,
		Wish.TrailsEnd              => expr,
		Wish.FinalAudience          => expr,
		Wish.SilkAndSoul            => expr,
		Wish.FatalResolve           => expr,
		Wish.PainAnguishAndMisery   => expr,
		Wish.HerosCall              => expr,
		Wish.EcstasyOfTheEnd        => expr,
		Wish.BerryPicking           => expr,
		Wish.RiteOfThePollip        => expr,
		Wish.SilverBells            => expr,
		Wish.AlchemistsAssistant    => expr,
		Wish.GreatTasteOfPharloom   => expr,
		Wish.AdvancedAlchemy        => expr,
		Wish.GarbOfThePilgrims      => expr,
		Wish.FlexileSpines          => expr,
		Wish.VolatileFlintbeetles   => expr,
		Wish.CrawbugClearing        => expr,
		Wish.RoachGuts              => expr,
		Wish.FinePins               => expr,
		Wish.CloaksOfTheChoir       => expr,
		Wish.Broodfeast             => expr,
		Wish.Runtfeast              => expr,
		Wish.DarkHearts             => expr,
		Wish.TheTerribleTyrant      => expr,
		Wish.SavageBeastfly         => expr,
		Wish.TheWailingMother       => expr,
		Wish.TheHiddenHunter        => expr,
		Wish.BoneBottomRepairs      => expr,
		Wish.ALifesavingBridge      => expr,
		Wish.RestorationOfBellhart  => expr,
		Wish.AnIconOfHope           => expr,
		Wish.BellhartsGlory         => expr,
		Wish.BuildingUpSongclave    => expr,
		Wish.StrengtheningSongclave => expr,
		Wish.BoneBottomSupplies     => expr,
		Wish.PilgrimsRestSupplies   => expr,
		Wish.QueensEgg              => expr,
		Wish.SongclaveSupplies      => expr,
		Wish.FleatopiaSupplies      => expr,
		Wish.LiquidLacquer          => expr,
		Wish.SurvivorsCampSupplies  => expr,
		Wish.BugsOfPharloom         => expr,
		Wish.FastestInPharloom      => expr,
		Wish.PassingOfTheAge        => expr,
		Wish.AVassalLost            => expr,*/
		// ReSharper restore StringLiteralTypo
		_ => throw new InvalidCheckException<Wish>(wish),
	};

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