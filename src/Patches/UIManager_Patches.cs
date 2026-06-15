using HarmonyLib;
using Silksong.BingoSync.UI.Menus;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace Silksong.BingoSync.Patches;

[HarmonyPatch(typeof(UIManager))]
internal class UIManager_Patches
{
	[HarmonyPostfix]
	[HarmonyPatch(nameof(UIManager.Awake))]
	private static void Awake_Postfix(UIManager __instance)
	{
		var board = UI.UIManager.Board.Value;

		if (board != null)
		{
			board.transform.SetParent(__instance.UICanvas.transform, false);

			board.Subscribe(Plugin.Controller.Events);
			Plugin.Controller.OnCardUpdated += board.DisplayCard;
		}

		var connectionMenuContainer = new GameObject(nameof(ConnectionMenu) + "-Container");
		connectionMenuContainer.transform.SetParent(__instance.UICanvas.transform, false);

		var rectTransform = connectionMenuContainer.AddComponent<RectTransform>();
		rectTransform.anchorMin = new Vector2(0.75f, 0f);
		rectTransform.anchorMax = new Vector2(1f, 0.5f);
		rectTransform.offsetMin = new Vector2(-20f, 0f);
		rectTransform.offsetMax = new Vector2(0f, 20f);
		rectTransform.pivot = new Vector2(1f, 0f);

		var menu = ConnectionMenu.Create();
		menu.transform.SetParent(connectionMenuContainer.transform, false);
	}

	[HarmonyPostfix]
	[HarmonyPatch(nameof(UIManager.DisableScreens))]
	private static void Disable_Postfix()
	{
		var board = UI.UIManager.Board.Value;

		if (board == null)
			return;

		// Keep active
		board.gameObject.SetActive(true);
	}
}