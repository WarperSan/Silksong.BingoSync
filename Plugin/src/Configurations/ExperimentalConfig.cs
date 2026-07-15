using BepInEx.Configuration;

namespace Silksong.BingoSync.Configurations;

/// <summary>
/// Class that holds the configurations related to experimental content
/// </summary>
internal class ExperimentalConfig
{
	private const string SECTION = "Experimental";

	public readonly ConfigEntry<bool> EvaluateOnHeroUpdate;

	public ExperimentalConfig(ConfigFile cfg)
	{
		EvaluateOnHeroUpdate = cfg.Bind(
			SECTION,
			"evaluateOnHeroUpdate",
			false,
			"Defines if the goals should be checked on each frame the player is loaded"
		);
	}
}