using BepInEx;
using BingoAPI.Conditions;
using Newtonsoft.Json;
using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.Helpers;
using Path = Silksong.BingoSync.Helpers.Path;

namespace Silksong.BingoSync;

[BepInAutoPlugin(id: "dev.warpersan.silksong.bingosync")]
[BepInDependency(ModMenu.ModMenuPlugin.Id)]
public partial class Plugin : BaseUnityPlugin
{
	/// <summary>
	/// Loaded instance of <see cref="Silksong.BingoSync.Controller"/>
	/// </summary>
	internal static readonly Controller Controller = new();

	private void Awake()
	{
		BingoAPI.Helpers.Log.Logger = Log.LogCore;

		Configuration.Load(Config);
		Patch.ApplyAll();

		Log.Info($"{Id} v{Version} has loaded!");
	}

	private void Start()
	{
		ConditionRegistry.AddAll();

		var goalsFolder = Path.GetAbsolutePath("Goals/");
		var pool = GoalLoader.LoadPoolFromFolder(goalsFolder);

		var content = new List<dynamic>();

		foreach (var goal in pool)
		{
			content.Add(new
			{
				name = goal.Name,
			});
		}

		Log.Info(JsonConvert.SerializeObject(content));

		Controller.Pool = pool;
		Log.Info($"Loaded '{pool.Count}' goals.");
	}
}