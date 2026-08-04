using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.UI.Abstract;
using Silksong.BingoSync.UI.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Components;

/// <summary>
/// Component responsible to update a <see cref="Text"/> using <see cref="AccessibilityConfig.TextFont"/>
/// </summary>
[RequireComponent(typeof(Text))]
internal sealed class AccessibilityTextFont : SettingUpdateNotifier<AccessibilityConfig.TextFont>
{
	private Text? _text;

	/// <inheritdoc/>
	protected override void OnSettingChanged(AccessibilityConfig.TextFont value)
	{
		if (_text == null)
			return;

		_text.font = value switch
		{
			AccessibilityConfig.TextFont.Normal => Fonts.Normal,
			AccessibilityConfig.TextFont.Bold => Fonts.Bold,
			AccessibilityConfig.TextFont.Arial => Fonts.Arial,
			AccessibilityConfig.TextFont.Default => Fonts.Default,
			_ => throw new ArgumentOutOfRangeException(nameof(value), value, null),
		};
	}

	private void Awake()
	{
		_text = GetComponent<Text>();
	}
}
