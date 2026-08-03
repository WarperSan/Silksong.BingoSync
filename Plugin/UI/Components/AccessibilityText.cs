using BepInEx.Configuration;
using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.UI.Constants;
using UnityEngine;
using UnityEngine.UI;
using FontEntry = BepInEx.Configuration.ConfigEntry<Silksong.BingoSync.Configurations.AccessibilityConfig.TextFont>;

namespace Silksong.BingoSync.UI.Components;

/// <summary>
/// Component responsible to manage accessibility features for <see cref="Text"/>
/// </summary>
[RequireComponent(typeof(Text))]
internal class AccessibilityText : MonoBehaviour
{
	private Text? _text;
	private FontEntry? _config;

	/// <summary>
	/// Binds this component with the given <see cref="ConfigEntry{T}"/>
	/// </summary>
	public void Bind(FontEntry config)
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

		if (settings.ChangedSetting is not FontEntry config)
			return;

		OnSettingChanged(config.Value);
	}

	private void OnSettingChanged(AccessibilityConfig.TextFont font)
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

	private void OnDestroy() => Unbind();
}
