using BepInEx.Configuration;

namespace Silksong.BingoSync.Configurations;

/// <summary>
/// Class that holds the configurations related to accessibility features
/// </summary>
internal class AccessibilityConfig
{
	private const string SECTION = "Accessibility";

	public enum TextFont
	{
		Normal,
		Bold,
		Arial,
		Default,
	}

	public readonly ConfigEntry<TextFont> BoardCellFont;

	public AccessibilityConfig(ConfigFile cfg)
	{
		BoardCellFont = cfg.Bind(
			SECTION,
			"BoardCellFont",
			TextFont.Normal,
			"Defines what font to use for the board cells"
		);
	}
}
