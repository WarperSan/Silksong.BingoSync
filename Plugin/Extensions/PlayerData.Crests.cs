using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="Crest"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	// TODO: Consider if it is better to associate Crest with ToolCrest

	/// <summary>
	/// Gets the identifier of the given <see cref="Crest"/>
	/// </summary>
	private static string GetCrestId(Crest crest)
	{
		return crest switch
		{
			// ReSharper disable StringLiteralTypo
			Crest.Hunter => "Hunter",
			Crest.HunterEvolved => "Hunter_v2",
			Crest.HunterFullyEvolved => "Hunter_v3",
			Crest.Reaper => "Reaper",
			Crest.Wanderer => "Wanderer",
			Crest.Beast => "Warrior",
			Crest.Cursed => "Cursed",
			Crest.Witch => "Witch",
			Crest.Architect => "Toolmaster",
			Crest.Shaman => "Spell",
			Crest.Cloakless => "Cloakless",
			// ReSharper restore StringLiteralTypo
			_ => throw new InvalidCheckException<Crest>(crest),
		};
	}

	/// <summary>
	/// Gets the data of the given <see cref="Crest"/>
	/// </summary>
	private static ToolCrestsData.Data? GetCrestData(this PlayerData data, Crest crest)
	{
		var id = GetCrestId(crest);

		return data.ToolEquips.GetData(id);
	}

	/// <summary>
	/// Checks if the given <see cref="Crest"/> was obtained
	/// </summary>
	public static bool HasObtainedCrest(this PlayerData data, Crest crest)
	{
		var crestData = data.GetCrestData(crest);

		if (!crestData.HasValue)
			return false;

		return crestData.Value.IsUnlocked;
	}
}
