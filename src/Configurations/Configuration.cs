using BepInEx.Configuration;

namespace Silksong.BingoSync.Configurations;

/// <summary>
/// Class that holds every other configuration
/// </summary>
internal class Configuration
{
	public readonly GeneralConfig General;
	public readonly BoardConfig Board;
	public readonly JoinConfig Join;
	public readonly ExperimentalConfig Experimental;

	private Configuration(ConfigFile cfg)
	{
		General = new GeneralConfig(cfg);
		Board = new BoardConfig(cfg);
		Join = new JoinConfig(cfg);
		Experimental = new ExperimentalConfig(cfg);
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