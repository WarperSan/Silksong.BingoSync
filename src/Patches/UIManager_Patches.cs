using HarmonyLib;
using Silksong.BingoSync.UI;
using Silksong.BingoSync.UI.Menus;

// ReSharper disable InconsistentNaming

namespace Silksong.BingoSync.Patches;

[HarmonyPatch(typeof(UIManager))]
internal class UIManager_Patches
{
	private static BingoBoard? _board;

	[HarmonyPostfix]
	[HarmonyPatch(nameof(UIManager.Awake))]
	private static void Awake_Postfix(UIManager __instance)
	{
		_board = BingoBoard.Create(null);
		_board.transform.SetParent(__instance.UICanvas.transform, false);

		var menu = ConnectionMenu.Create();
		menu.transform.SetParent(__instance.UICanvas.transform, false);
	}

	[HarmonyPostfix]
	[HarmonyPatch(nameof(UIManager.DisableScreens))]
	private static void Disable_Postfix()
	{
		if (_board == null)
			return;

		// Keep active
		_board.gameObject.SetActive(true);
	}
}