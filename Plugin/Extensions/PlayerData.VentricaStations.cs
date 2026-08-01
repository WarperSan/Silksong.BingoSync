using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="VentricaStation"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	/// <summary>
	/// Check if the given <see cref="VentricaStation"/> is unlocked
	/// </summary>
	public static bool HasUnlockedStation(this PlayerData data, VentricaStation station)
	{
		return station switch
		{
			VentricaStation.Memorium => data.UnlockedArboriumTube,
			VentricaStation.HighHalls => data.UnlockedHangTube,
			VentricaStation.FirstShrine => data.UnlockedEnclaveTube,
			VentricaStation.ChoralChambers => data.UnlockedSongTube,
			VentricaStation.GrandBellway => data.UnlockedCityBellwayTube,
			VentricaStation.Underworks => data.UnlockedUnderTube,
			_ => throw new InvalidCheckException<VentricaStation>(station),
		};
	}
}
