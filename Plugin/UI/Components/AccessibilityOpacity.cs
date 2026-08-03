using Silksong.BingoSync.UI.Abstract;
using UnityEngine;

namespace Silksong.BingoSync.UI.Components;

/// <summary>
/// Component responsible to update a <see cref="CanvasGroup"/> using a <see cref="int"/>
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
internal class AccessibilityOpacity : SettingUpdateNotifier<int>
{
	private CanvasGroup? _canvasGroup;

	/// <inheritdoc />
	protected override void OnSettingChanged(int value)
	{
		if (_canvasGroup == null)
			return;

		_canvasGroup.alpha = Mathf.Clamp(value / 100f, 0f, 1f);
	}

	private void Awake()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
	}
}
