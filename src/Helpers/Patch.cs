namespace Silksong.BingoSync.Helpers;

/// <summary>
/// Class offering patching features
/// </summary>
internal static class Patch
{
	/// <summary>
	///     Applies every patch needed by this mod
	/// </summary>
	public static void ApplyAll()
	{
		var harmony = new HarmonyLib.Harmony(Plugin.Id);

		harmony.PatchAll(typeof(Patches.UIManager_Patches));
		harmony.PatchAll(typeof(Patches.PlayerData_Patches));
		harmony.PatchAll(typeof(Patches.ToolItemManager_Patches));
		harmony.PatchAll(typeof(Patches.HeroController_Patches));

		Log.Debug("All patches applied.");
	}
}