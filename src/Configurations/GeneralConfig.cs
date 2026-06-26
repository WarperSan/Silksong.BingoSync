using BepInEx.Configuration;

namespace Silksong.BingoSync.Configurations;

/// <summary>
/// Class that holds the configurations related to the general mod
/// </summary>
internal class GeneralConfig
{
	private const string SECTION = "General";

	public readonly ConfigEntry<bool> UseAdvancedTeams;

	public GeneralConfig(ConfigFile cfg)
	{
		UseAdvancedTeams = cfg.Bind(
			SECTION,
			"UseAdvancedTeams",
			false,
			"Defines if the advanced teams are enabled"
		);
	}
}