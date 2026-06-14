using Silksong.BingoSync.UI.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI;

/// <summary>
/// Component responsible to manage a 'pressed' input
/// </summary>
internal class Button : MonoBehaviour
{
	private Action? _onClick;
	private Text? _label;

	/// <summary>
	/// Sets the text on the button
	/// </summary>
	public void SetText(string text) => _label?.text = text;

	private void OnClick() => _onClick?.Invoke();

	/// <summary>
	/// Creates a new instance of <see cref="Button"/>
	/// </summary>
	public static Button Create(Action onClick)
	{
		var gameObject = new GameObject(nameof(Button));

		var rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMin = Vector2.zero;
		rectTransform.anchorMax = Vector2.one;
		rectTransform.sizeDelta = new Vector2(300f, 50f);

		var image = gameObject.AddComponent<Image>();

		image.color = new Color(
			0f,
			0f,
			0f,
			0.6f
		);

		var internalButton = gameObject.AddComponent<UnityEngine.UI.Button>();
		internalButton.targetGraphic = image;

		var textGameObject = new GameObject(nameof(Text));
		textGameObject.transform.SetParent(gameObject.transform, false);

		var textRect = textGameObject.AddComponent<RectTransform>();
		textRect.anchorMin = Vector2.zero;
		textRect.anchorMax = Vector2.one;
		textRect.offsetMin = Vector2.zero;
		textRect.offsetMax = Vector2.zero;

		var label = textGameObject.AddComponent<Text>();
		label.font = Fonts.Normal;
		label.fontSize = 18;
		label.color = Color.white;
		label.alignment = TextAnchor.MiddleCenter;

		var button = gameObject.AddComponent<Button>();
		button._onClick = onClick;
		button._label = label;
		internalButton.onClick.AddListener(button.OnClick);

		return button;
	}
}