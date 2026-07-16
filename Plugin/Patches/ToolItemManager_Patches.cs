// ReSharper disable InconsistentNaming

using HarmonyLib;

namespace Silksong.BingoSync.Patches;

[HarmonyPatch(typeof(ToolItemManager))]
internal class ToolItemManager_Patches
{
	[HarmonyPostfix]
	[HarmonyPatch(nameof(ToolItemManager.ReportCrestUnlocked))]
	private static void ReportCrestUnlocked_Postfix()
	{
		Plugin.Controller.Evaluate();
	}
}
