using BepInEx.Configuration;

namespace Silksong.BingoSync.Configurations;

/// <summary>
/// Class that holds every other configuration
/// </summary>
internal class Configuration
{
	public readonly BoardConfig Board;

	private Configuration(ConfigFile cfg)
	{
		Board = new BoardConfig(cfg);
	}

	/// <summary>
	/// Configuration loaded
	/// </summary>
	public static Configuration? Instance { get; private set; }

	/// <summary>
	/// Configuration loaded
	/// </summary>
	/// <exception cref="InvalidOperationException">
	/// Throws if no instance was loaded
	/// </exception>
	public static Configuration SafeInstance
	{
		get
		{
			if (Instance == null)
				throw new InvalidOperationException($"Tried to access '{nameof(Configuration)}' before it was loaded.");

			return Instance;
		}
	}

	/// <summary>
	/// Loads the configuration from the given configuration file
	/// </summary>
	public static void Load(ConfigFile cfg)
	{
		Instance = new Configuration(cfg);
	}
}