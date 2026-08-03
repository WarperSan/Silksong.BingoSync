using BepInEx.Configuration;
using Silksong.BingoSync.Configurations;
using UnityEngine;
using PositionEntry = BepInEx.Configuration.ConfigEntry<Silksong.BingoSync.Configurations.AccessibilityConfig.ElementPosition>;

namespace Silksong.BingoSync.UI.Components;

/// <summary>
/// Component responsible to update a <see cref="RectTransform"/> using <see cref="AccessibilityConfig.BoardPosition"/>
/// </summary>
[RequireComponent(typeof(RectTransform))]
internal class AccessibilityBoardPosition : MonoBehaviour
{
	private RectTransform? _rectTransform;
	private PositionEntry? _config;

	/// <summary>
	/// Binds this component with the given <see cref="ConfigEntry{T}"/>
	/// </summary>
	public void Bind(PositionEntry config)
	{
		Unbind();
		_config = config;
		_config.SettingChanged += OnRawSettingChanged;

		OnSettingChanged(_config.Value);
	}

	/// <summary>
	/// Unbinds this component with all bound <see cref="ConfigEntry{T}"/>
	/// </summary>
	public void Unbind()
	{
		_config?.SettingChanged -= OnRawSettingChanged;
		_config = null;
	}

	private void OnRawSettingChanged(object sender, EventArgs e)
	{
		if (e is not SettingChangedEventArgs settings)
			return;

		if (settings.ChangedSetting is not PositionEntry config)
			return;

		OnSettingChanged(config.Value);
	}

	private void OnSettingChanged(AccessibilityConfig.ElementPosition position)
	{
		if (_rectTransform == null)
			return;

		switch (position)
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
				throw new ArgumentOutOfRangeException(nameof(position), position, null);
		}
	}

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
	}

	private void OnDestroy() => Unbind();
}
