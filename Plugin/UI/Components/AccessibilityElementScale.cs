using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.UI.Abstract;
using UnityEngine;

namespace Silksong.BingoSync.UI.Components;

/// <summary>
/// Component responsible to update a <see cref="RectTransform"/> using <see cref="AccessibilityConfig.ElementScale"/>
/// </summary>
[RequireComponent(typeof(RectTransform))]
internal sealed class AccessibilityElementScale
	: SettingUpdateNotifier<AccessibilityConfig.ElementScale>
{
	private RectTransform? _rectTransform;

	/// <inheritdoc/>
	protected override void OnSettingChanged(AccessibilityConfig.ElementScale value)
	{
		if (_rectTransform == null)
			return;

		_rectTransform.localScale = value switch
		{
			AccessibilityConfig.ElementScale.VerySmall => Vector2.one * 0.5f,
			AccessibilityConfig.ElementScale.Small => Vector2.one * 0.75f,
			AccessibilityConfig.ElementScale.Normal => Vector2.one,
			AccessibilityConfig.ElementScale.Large => Vector2.one * 1.25f,
			AccessibilityConfig.ElementScale.VeryLarge => Vector2.one * 1.5f,
			_ => throw new ArgumentOutOfRangeException(nameof(value), value, null),
		};
	}

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
	}
}
