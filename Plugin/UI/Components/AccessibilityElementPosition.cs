using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.UI.Abstract;
using UnityEngine;

namespace Silksong.BingoSync.UI.Components;

/// <summary>
/// Component responsible to update a <see cref="RectTransform"/> using <see cref="AccessibilityConfig.ElementPosition"/>
/// </summary>
[RequireComponent(typeof(RectTransform))]
internal sealed class AccessibilityElementPosition
	: SettingUpdateNotifier<AccessibilityConfig.ElementPosition>
{
	private RectTransform? _rectTransform;

	/// <inheritdoc/>
	protected override void OnSettingChanged(AccessibilityConfig.ElementPosition value)
	{
		if (_rectTransform == null)
			return;

		switch (value)
		{
			case AccessibilityConfig.ElementPosition.TopLeft:
				_rectTransform.anchorMax = new Vector2(0, 1);
				_rectTransform.anchorMin = new Vector2(0, 1);
				_rectTransform.pivot = new Vector2(0, 1);
				break;
			case AccessibilityConfig.ElementPosition.TopRight:
				_rectTransform.anchorMax = Vector2.one;
				_rectTransform.anchorMin = Vector2.one;
				_rectTransform.pivot = Vector2.one;
				break;
			case AccessibilityConfig.ElementPosition.BottomLeft:
				_rectTransform.anchorMax = Vector2.zero;
				_rectTransform.anchorMin = Vector2.zero;
				_rectTransform.pivot = Vector2.zero;
				break;
			case AccessibilityConfig.ElementPosition.BottomRight:
				_rectTransform.anchorMax = new Vector2(1, 0);
				_rectTransform.anchorMin = new Vector2(1, 0);
				_rectTransform.pivot = new Vector2(1, 0);
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(value), value, null);
		}
	}

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
	}
}
