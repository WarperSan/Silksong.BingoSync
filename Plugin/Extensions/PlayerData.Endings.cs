using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="Ending"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	/// <summary>
	/// Checks if the given <see cref="Ending"/> was completed
	/// </summary>
	public static bool HasCompletedEnding(this PlayerData data, Ending ending)
	{
		return ending switch
		{
			Ending.WeaverQueen => data.CompletedEndings.HasFlag(
				SaveSlotCompletionIcons.CompletionState.Act2Regular
			),
			Ending.SnaredSilk => data.CompletedEndings.HasFlag(
				SaveSlotCompletionIcons.CompletionState.Act2SoulSnare
			),
			Ending.TwistedChild => data.CompletedEndings.HasFlag(
				SaveSlotCompletionIcons.CompletionState.Act2Cursed
			),
			Ending.SisterOfTheVoid => data.CompletedEndings.HasFlag(
				SaveSlotCompletionIcons.CompletionState.Act3Ending
			),
			Ending.PassingOfTheAge => data.MushroomQuestCompleted,
			_                      => throw new InvalidCheckException<Ending>(ending),
		};
	}
}
