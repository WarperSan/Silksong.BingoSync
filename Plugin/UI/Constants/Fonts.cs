using UnityEngine;

namespace Silksong.BingoSync.UI.Constants;

internal static class Fonts
{
	private static readonly Dictionary<string, Font> CachedFonts = new();

	/// <summary>
	/// Gets the <see cref="Font"/> with the given name
	/// </summary>
	private static Font? GetFont(string name)
	{
		if (CachedFonts.TryGetValue(name, out var font))
			return font;

		foreach (var f in Resources.FindObjectsOfTypeAll<Font>())
			CachedFonts[f.name] = f;

		return CachedFonts.GetValueOrDefault(name);
	}

	/// <summary>
	/// Gets the normal font
	/// </summary>
	public static Font? Normal => GetFont("TrajanPro-Regular");

	/// <summary>
	/// Gets the bold font
	/// </summary>
	public static Font? Bold => GetFont("TrajanPro-Bold");

	/// <summary>
	/// Gets the 'Arial' font
	/// </summary>
	public static Font? Arial => GetFont("ARIAL");

	/// <summary>
	/// Gets the default <see cref="Font"/>
	/// </summary>
	public static Font? Default => Font.GetDefault();
}
