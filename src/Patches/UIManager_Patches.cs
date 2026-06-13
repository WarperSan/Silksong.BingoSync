using HarmonyLib;
using Silksong.BingoSync.UI;

// ReSharper disable InconsistentNaming

namespace Silksong.BingoSync.Patches;

[HarmonyPatch(typeof(UIManager))]
internal class UIManager_Patches
{
	[HarmonyPostfix]
	[HarmonyPatch(nameof(UIManager.Awake))]
	private static void Awake_Postfix(UIManager __instance)
	{
		var board = BingoBoard.Create(null);
		//DontDestroyOnLoad(board);
		board.transform.SetParent(__instance.UICanvas.transform, false);
	}
}