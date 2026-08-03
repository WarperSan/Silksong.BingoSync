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

	public enum ElementPosition
	{
		TopLeft,
		TopRight,
		BottomLeft,
		BottomRight,
	}

	public readonly ConfigEntry<ElementPosition> BoardPosition;

	public enum ElementScale
	{
		Compact,
		Normal,
		Medium,
		Large,
		ExtraLarge,
	}

	public readonly ConfigEntry<ElementScale> BoardScale;

	public AccessibilityConfig(ConfigFile cfg)
	{
		BoardCellFont = cfg.Bind(
			SECTION,
			"BoardCellFont",
			TextFont.Normal,
			"Defines what font to use for the board cells"
		);

		BoardPosition = cfg.Bind(
			SECTION,
			"BoardPosition",
			ElementPosition.TopRight,
			"Defines where the board is located on the screen"
		);

		BoardScale = cfg.Bind(
			SECTION,
			"BoardScale",
			ElementScale.Normal,
			"Defines the scale of the board"
		);
	}
}
