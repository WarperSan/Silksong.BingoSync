// ReSharper disable InconsistentNaming

using HarmonyLib;

namespace Silksong.BingoSync.Patches;

[HarmonyPatch(typeof(HeroController))]
internal class HeroController_Patches
{
	[HarmonyPrefix]
	[HarmonyPatch(nameof(HeroController.FixedUpdate))]
	private static void FixedUpdate_Prefix(HeroController __instance)
	{
		var config = Configurations.Configuration.Instance;

		if (config == null)
			return;

		if (!config.Experimental.EvaluateOnHeroUpdate.Value)
			return;

		Plugin.Controller.Evaluate();
	}
}