using BepInEx.Configuration;
using UnityEngine;

namespace Silksong.BingoSync.UI.Abstract;

/// <summary>
/// Component used to notify this component about changes to the bound <see cref="ConfigEntry{T}"/>
/// </summary>
internal abstract class SettingUpdateNotifier<T> : MonoBehaviour
{
	private ConfigEntry<T>? _config;

	/// <summary>
	/// Binds this component with the given <see cref="ConfigEntry{T}"/>
	/// </summary>
	public void Bind(ConfigEntry<T> config)
	{
		Unbind();
		_config = config;
		_config.SettingChanged += OnRawSettingChanged;

		SettingChanged(_config.Value);
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

		if (settings.ChangedSetting is not ConfigEntry<T> config)
			return;

		SettingChanged(config.Value);
	}

	private void SettingChanged(T value) => OnSettingChanged(value);

	/// <summary>
	/// Called when the bound <see cref="ConfigEntry{T}"/> changes value
	/// </summary>
	protected abstract void OnSettingChanged(T value);

	protected virtual void OnDestroy() => Unbind();
}
