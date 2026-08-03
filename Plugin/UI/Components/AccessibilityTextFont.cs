using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.UI.Abstract;
using Silksong.BingoSync.UI.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Components;

/// <summary>
/// Component responsible to update a <see cref="Text"/> using <see cref="AccessibilityConfig.BoardCellFont"/>
/// </summary>
[RequireComponent(typeof(Text))]
internal class AccessibilityTextFont : SettingUpdateNotifier<AccessibilityConfig.TextFont>
{
	private Text? _text;

	/// <inheritdoc/>
	protected override void OnSettingChanged(AccessibilityConfig.TextFont font)
	{
		if (_text == null)
			return;

		_text.font = font switch
		{
			AccessibilityConfig.TextFont.Normal => Fonts.Normal,
			AccessibilityConfig.TextFont.Bold => Fonts.Bold,
			AccessibilityConfig.TextFont.Arial => Fonts.Arial,
			AccessibilityConfig.TextFont.Default => Fonts.Default,
			_ => throw new ArgumentOutOfRangeException(nameof(font), font, null),
		};
	}

	private void Awake()
	{
		_text = GetComponent<Text>();
	}
}
