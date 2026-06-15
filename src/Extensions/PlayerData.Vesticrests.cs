using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="Vesticrest"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	/// <summary>
	/// Checks if the given <see cref="Vesticrest"/> was obtained
	/// </summary>
	public static bool HasVesticrest(this PlayerData data, Vesticrest vesticrest) => vesticrest switch
	{
		Vesticrest.Basic    => data.UnlockedExtraYellowSlot,
		Vesticrest.Upgraded => data.UnlockedExtraBlueSlot,
		_                   => throw new InvalidCheckException<Vesticrest>(vesticrest),
	};
}