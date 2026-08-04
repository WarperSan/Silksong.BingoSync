using BepInEx.Configuration;
using UnityEngine;

namespace Silksong.BingoSync.Configurations;

/// <summary>
/// Class that holds the configurations related to the join form
/// </summary>
internal class JoinConfig
{
	private const string SECTION = "Join";

	public readonly ConfigEntry<string> Nickname;
	public readonly ConfigEntry<string> Code;
	public readonly ConfigEntry<string> Password;
	public readonly ConfigEntry<KeyCode> ToggleUI;

	public JoinConfig(ConfigFile cfg)
	{
		Nickname = cfg.Bind(
			SECTION,
			"DefaultNickname",
			"",
			"Defines the default nickname in the join panel"
		);

		Code = cfg.Bind(SECTION, "DefaultCode", "", "Defines the default code in the join panel");

		Password = cfg.Bind(
			SECTION,
			"DefaultPassword",
			"",
			"Defines the default password in the join panel"
		);

		ToggleUI = cfg.Bind(
			SECTION,
			"ToggleJoinUI",
			KeyCode.H,
			"Defines the keybind to toggle the join panel"
		);
	}
}
