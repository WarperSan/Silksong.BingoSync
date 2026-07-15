using BepInEx.Configuration;
using UnityEngine;

namespace Silksong.BingoSync.Configurations;

/// <summary>
/// Class that holds the configurations related to the board itself
/// </summary>
internal class BoardConfig
{
	private const string SECTION = "Board";

	public readonly ConfigEntry<KeyCode> ToggleUI;

	public BoardConfig(ConfigFile cfg)
	{
		ToggleUI = cfg.Bind(
			SECTION,
			"ToggleBoard",
			KeyCode.B,
			"Defines the keybind to toggle the board"
		);
	}
}