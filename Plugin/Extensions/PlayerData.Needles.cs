using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="Needle"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	/// <summary>
	/// Gets the index of the upgrade for the given <see cref="Needle"/>
	/// </summary>
	private static int GetNeedleUpgradeIndex(Needle needle)
	{
		return needle switch
		{
			Needle.Needle          => 0,
			Needle.SharpenedNeedle => 1,
			Needle.ShiningNeedle   => 2,
			Needle.HivesteelNeedle => 3,
			Needle.PaleSteelNeedle => 4,
			_                      => throw new InvalidCheckException<Needle>(needle),
		};
	}

	/// <summary>
	/// Checks if the given <see cref="Needle"/> was obtained
	/// </summary>
	public static bool HasObtainedNeedle(this PlayerData data, Needle needle)
	{
		var upgradeIndex = GetNeedleUpgradeIndex(needle);

		return data.nailUpgrades >= upgradeIndex;
	}
}
