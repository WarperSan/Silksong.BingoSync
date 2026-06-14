using System.Reflection;
using BepInEx;
using BingoAPI.Conditions;
using BingoAPI.Goals;
using Silksong.BingoSync.Conditions;
using Silksong.BingoSync.Helpers;

namespace Silksong.BingoSync;

[BepInAutoPlugin(id: "dev.warpersan.silksong.bingosync")]
public partial class Plugin : BaseUnityPlugin
{
	/// <summary>
	/// Loaded instance of <see cref="Silksong.BingoSync.Controller"/>
	/// </summary>
	public static Controller? Controller { get; private set; }

	private void Awake()
	{
		AddConditions();
		var pool = LoadPool();
		Controller = new Controller(pool);

		Patch.ApplyAll();
		Log.Info($"Plugin {Name} ({Id}) has loaded!");
	}

	private static void AddConditions()
	{
		ConditionRegistry.TryAdd("has_killed_boss", data => new HasKilledBossCondition(data));
	}

	private static GoalPool LoadPool()
	{
		Log.Info($"Loading goal pool: " + Assembly.GetExecutingAssembly().Location);
		return new GoalPool();
	}
}