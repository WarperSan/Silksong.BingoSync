// ReSharper disable InconsistentNaming

using HarmonyLib;
using Newtonsoft.Json;
using Silksong.BingoSync.Helpers;
using Path = Silksong.BingoSync.Helpers.Path;

namespace Silksong.BingoSync.Patches;

[HarmonyPatch(typeof(GameManager))]
internal class GameManager_Patches
{
	private static bool hasInitialized = false;

	[HarmonyPostfix]
	[HarmonyPatch(nameof(GameManager.Start))]
	private static void Start_Postfix(GameManager __instance)
	{
		if (hasInitialized)
			return;

		var goalsFolder = Path.GetAbsolutePath("Goals/");
		var pool = GoalLoader.LoadPoolFromFolder(goalsFolder);

		var content = new List<dynamic>();

		foreach (var goal in pool)
		{
			content.Add(new { name = goal.Name });
		}

		Log.Info(JsonConvert.SerializeObject(content));

		Plugin.Controller.Pool = pool;
		Log.Info($"Loaded '{pool.Count}' goals.");
		hasInitialized = true;
	}
}
