using UnityEngine;

namespace Silksong.BingoSync.UI.Constants;

internal static class Fonts
{
	private static readonly Lazy<(Font? Bold, Font? Normal)> TrajanFonts = new(() =>
	{
		Font? bold = null, normal = null;

		foreach (var f in Resources.FindObjectsOfTypeAll<Font>())
		{
			if (f == null)
				continue;

			switch (f.name)
			{
				case "TrajanPro-Bold":
					bold = f;
					break;
				case "TrajanPro-Regular":
					normal = f;
					break;
			}
		}
		return (bold, normal);
	});

	/// <summary>
	/// Accesses to the normal font
	/// </summary>
	public static Font? Normal => TrajanFonts.Value.Normal;

	/// <summary>
	/// Accesses to the bold font
	/// </summary>
	public static Font? Bold => TrajanFonts.Value.Bold;
}