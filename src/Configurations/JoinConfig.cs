using BepInEx.Configuration;

namespace Silksong.BingoSync.Configurations;

/// <summary>
/// Class that holds the configurations related to the join form
/// </summary>
internal class JoinConfig
{
	private const string SECTION = "Join";

	public readonly ConfigEntry<string> Nickname;

	public JoinConfig(ConfigFile cfg)
	{
		Nickname = cfg.Bind(
			SECTION,
			"DefaultNickname",
			"",
			"configuration.join.nickname.description"
		);
	}
}