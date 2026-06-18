using BingoAPI.Models.Settings;
using HarmonyLib;
using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.UI.Containers;
using Silksong.BingoSync.UI.Menus;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable InconsistentNaming

namespace Silksong.BingoSync.Patches;

[HarmonyPatch(typeof(UIManager))]
internal class UIManager_Patches
{
	private static Canvas? _bingoCanvas;

	[HarmonyPostfix]
	[HarmonyPatch(nameof(UIManager.Awake))]
	private static void Awake_Postfix(UIManager __instance)
	{
		if (_bingoCanvas != null)
			return;

		var gameObject = new GameObject(nameof(BingoSync) + "." + nameof(Canvas));
		UnityEngine.Object.DontDestroyOnLoad(gameObject);

		var canvas = gameObject.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;

		var scaler = gameObject.AddComponent<CanvasScaler>();
		scaler.referenceResolution = __instance.canvasScaler.referenceResolution;
		scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;

		gameObject.AddComponent<GraphicRaycaster>();

		_bingoCanvas = canvas;

		CreateConnectionMenu(gameObject.transform);

		var boardContainer = BoardContainer.Create();
		boardContainer.transform.SetParent(gameObject.transform, false);
	}

	private static void CreateConnectionMenu(Transform parent)
	{
		var container = new GameObject(nameof(ConnectionMenu) + "-Container");
		container.transform.SetParent(parent, false);

		var rectTransform = container.AddComponent<RectTransform>();
		rectTransform.anchorMin = new Vector2(0.75f, 0f);
		rectTransform.anchorMax = new Vector2(1f, 0.5f);
		rectTransform.offsetMin = new Vector2(-20f, 0f);
		rectTransform.offsetMax = new Vector2(0f, 20f);
		rectTransform.pivot = new Vector2(1f, 0f);

		var joinSettings = new JoinRoomSettings
		{
			Code = "6MuWtbUFQE-P70lS6-5BhQ",
			Nickname = Configuration.Instance?.Join.Nickname.Value ?? "",
			Password = "abc",
		};

		var menu = ConnectionMenu.Create(joinSettings);
		menu.transform.SetParent(container.transform, false);

		Canvas.ForceUpdateCanvases();
		LayoutRebuilder.ForceRebuildLayoutImmediate(menu.GetComponent<RectTransform>());
	}
}