using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="AncestralArt"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	/// <summary>
	/// Checks if the given <see cref="AncestralArt"/> was obtained
	/// </summary>
	public static bool HasObtainedAncestralArt(this PlayerData data, AncestralArt art)
	{
		return art switch
		{
			AncestralArt.SwiftStep => data.hasDash,
			AncestralArt.ClingGrip => data.hasWalljump,
			AncestralArt.Needolin  => data.hasNeedolin,
			AncestralArt.Clawline  => data.hasHarpoonDash,
			AncestralArt.SilkSoar  => data.hasSuperJump,
			AncestralArt.Sylphsong => data.HasSeenEvaHeal, // TODO: Check if this is the actual field
			_                      => throw new InvalidCheckException<AncestralArt>(art),
		};
	}
}
