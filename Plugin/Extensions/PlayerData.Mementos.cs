using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning mementos
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	// TODO: Consider if it is better to associate Memento with CollectableItemMemento

	/// <summary>
	/// Gets the identifier of the given <see cref="Memento"/>
	/// </summary>
	private static string GetMementoId(Memento memento)
	{
		return memento switch
		{
			// ReSharper disable StringLiteralTypo
			Memento.Sprintmaster => "Sprintmaster Memento",
			Memento.Guardian => "Memento Seth",
			Memento.Hero => "Memento Garmond",
			Memento.Hunter => "Hunter Memento",
			Memento.Grey => "Grey Memento",
			Memento.Surface => "Memento Surface",
			Memento.Craw => "Crowman Memento",
			Memento.EncrustedHeart => "Coral Heart",
			Memento.PollenHeart => "Flower Heart",
			Memento.HunterHeart => "Hunter Heart",
			Memento.ConjoinedHeart => "Clover Heart",
			// ReSharper restore StringLiteralTypo
			_ => throw new InvalidCheckException<Memento>(memento),
		};
	}

	/// <summary>
	/// Gets the data of the given <see cref="Memento"/>
	/// </summary>
	private static CollectableMementosData.Data? GetMementoData(
		this PlayerData data,
		Memento memento
	)
	{
		var id = GetMementoId(memento);

		return data.MementosDeposited.GetData(id);
	}

	/// <summary>
	/// Checks if the given <see cref="Memento"/> was obtained
	/// </summary>
	public static bool HasObtainedMemento(this PlayerData data, Memento memento)
	{
		return memento switch
		{
			Memento.Sprintmaster => data.CollectedMementoSprintmaster,
			Memento.Guardian => data.FleaGamesMementoGiven,
			Memento.Hero => throw new NotImplementedException(),
			Memento.Hunter => data.nuuMementoAwarded,
			Memento.Grey => data.CollectedMementoGrey,
			Memento.Surface => throw new NotImplementedException(),
			Memento.Craw => data.PickedUpCrowMemento,
			Memento.EncrustedHeart => data.CollectedHeartCoral,
			Memento.PollenHeart => data.CollectedHeartFlower,
			Memento.HunterHeart => data.CollectedHeartHunter,
			Memento.ConjoinedHeart => data.CollectedHeartClover,
			_ => throw new InvalidCheckException<Memento>(memento),
		};
	}

	/// <summary>
	/// Checks if the given <see cref="Memento"/> was deposited
	/// </summary>
	public static bool HasDepositedMemento(this PlayerData data, Memento memento)
	{
		var mementoData = data.GetMementoData(memento);

		if (!mementoData.HasValue)
			return false;

		return mementoData.Value.IsDeposited;
	}
}
