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
	public readonly ConfigEntry<KeyCode> ToggleUI;

	public JoinConfig(ConfigFile cfg)
	{
		Nickname = cfg.Bind(
			SECTION,
			"DefaultNickname",
			"",
			"configuration.join.nickname.description"
		);
		ToggleUI = cfg.Bind(
			SECTION,
			"ToggleJoinUI",
			KeyCode.H,
			"configuration.join.toggle.description"
		);
	}
}