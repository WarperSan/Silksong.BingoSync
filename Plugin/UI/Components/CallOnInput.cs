using BepInEx.Configuration;
using UnityEngine;

namespace Silksong.BingoSync.UI.Components;

/// <summary>
/// Component responsible to call a callback when an input is activated
/// </summary>
internal class CallOnInput : MonoBehaviour
{
	private Func<KeyCode>? _key;
	private Action? _onInput;

	/// <summary>
	/// Sets the component to listen to the given entry
	/// </summary>
	public void SetInput(ConfigEntry<KeyCode> entry, Action? onInput)
	{
		_key = () => entry.Value;
		_onInput = onInput;
	}

	private void Update()
	{
		if (_key == null)
			return;

		var key = _key.Invoke();

		if (Input.GetKeyDown(key))
			_onInput?.Invoke();
	}
}
