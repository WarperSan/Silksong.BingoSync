using System.Reflection;
using BepInEx;
using BingoAPI.Conditions;
using Silksong.BingoSync.Conditions;
using Silksong.BingoSync.Configurations;
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
		Configuration.Load(Config);
		Patch.ApplyAll();

		AddConditions();

		var pluginFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
		var goalsFolder = Path.Combine(pluginFolder, "Goals");
		var pool = GoalLoader.LoadPoolFromFolder(goalsFolder);
		Log.Info($"Loaded '{pool.Count}' goals.");

		Controller = new Controller(pool);

		Log.Info($"{Id} v{Version} has loaded!");
	}

	private static void AddConditions()
	{
		// is- / are- : is_talking_to (Is the player currently talking to X character?)
		// has- / have- : has_talked_to (Has the player talked to X character?)

		// killed: Slay an entity forever
		// defeated: Slay an entity temporarily
		// obtained: Gain something as the result of a plan

		ConditionRegistry.TryAdd("has_killed_boss", data => new HasKilledBossCondition(data));
		ConditionRegistry.TryAdd("has_obtained_crest", data => new HasObtainedCrestCondition(data));
	}
}