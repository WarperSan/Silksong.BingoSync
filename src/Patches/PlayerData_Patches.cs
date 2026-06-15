using HarmonyLib;

// ReSharper disable InconsistentNaming

namespace Silksong.BingoSync.Patches;

[HarmonyPatch(typeof(PlayerData))]
internal class PlayerData_Patches
{
	[HarmonyPostfix]
	[HarmonyPatch(nameof(PlayerData.SetBool))]
	private static void SetBool_Postfix()
	{
		Plugin.Controller?.Evaluate();
	}
}