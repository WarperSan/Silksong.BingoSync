using BepInEx;
using BingoAPI.Conditions;
using Silksong.BingoSync.Conditions;
using Silksong.BingoSync.Helpers;

namespace Silksong.BingoSync;

[BepInAutoPlugin(id: "dev.warpersan.silksong.bingosync")]
public partial class Plugin : BaseUnityPlugin
{
	private void Awake()
	{
		AddConditions();

		Patch.ApplyAll();
		Log.Info($"Plugin {Name} ({Id}) has loaded!");
	}

	private static void AddConditions()
	{
		ConditionRegistry.TryAdd("has_killed_boss", data => new HasKilledBossCondition(data));
	}
}