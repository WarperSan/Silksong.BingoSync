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
			_ => throw new InvalidCheckException<Flea>(flea),
		};
	}
}
