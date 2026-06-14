using BingoAPI.Goals;
using Newtonsoft.Json;

namespace Silksong.BingoSync.Helpers;

/// <summary>
/// Class helping with loading <see cref="Goal"/>
/// </summary>
internal class GoalLoader
{
	/// <summary>
	/// Loads a <see cref="GoalPool"/> from the given folder
	/// </summary>
	public static GoalPool LoadPoolFromFolder(string folder)
	{
		var pool = new GoalPool();

		if (!Directory.Exists(folder))
		{
			Log.Warning($"Folder '{folder}' does not exist.");
			return pool;
		}

		var files = Directory.GetFiles(
			folder,
			"*.json",
			SearchOption.AllDirectories
		);

		foreach (var file in files)
		{
			try
			{
				var goalSet = LoadSetFromFile(file);

				foreach (var goal in goalSet.Goals)
					pool.TryAdd(goal);
			}
			catch (Exception e)
			{
				Log.Error($"Error while loading '{file}': {e}");
			}
		}

		return pool;
	}

	/// <summary>
	/// Loads a <see cref="GoalSet"/> from the given file
	/// </summary>
	public static GoalSet LoadSetFromFile(string file)
	{
		var content = File.ReadAllText(file);
		var goalSet = JsonConvert.DeserializeObject<GoalSet>(content);

		if (goalSet == null)
			throw new InvalidOperationException($"Must parse a valid '{nameof(GoalSet)}'.");

		return goalSet;
	}
}