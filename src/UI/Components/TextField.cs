using Silksong.BingoSync.UI.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Components;

/// <summary>
/// Component responsible to manage <see cref="string"/> input
/// </summary>
internal class TextField : MonoBehaviour
{
	private InputField? _inputField;

	/// <summary>
	/// Input stored in this field
	/// </summary>
	public string Text
	{
		get
		{
			if (_inputField == null)
				return string.Empty;

			return _inputField.text;
		}
		set
		{
			if (_inputField == null)
				return;

			_inputField.text = value;
		}
	}

	/// <summary>
	/// Creates a new instance of <see cref="TextField"/>
	/// </summary>
	public static TextField Create(
		string                 placeholder = "",
		InputField.ContentType type        = InputField.ContentType.Standard
	)
	{
		var gameObject = new GameObject(nameof(TextField));

		var field = gameObject.AddComponent<TextField>();

		var rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMin = new Vector2(0, 0.5f);
		rectTransform.anchorMax = new Vector2(1, 0.5f);
		rectTransform.sizeDelta = new Vector2(300f, 40f);

		var image = gameObject.AddComponent<Image>();

		image.color = new Color(
			0f,
			0f,
			0f,
			0.6f
		);

		// Text component
		var textGameObject = new GameObject("Text");
		textGameObject.transform.SetParent(gameObject.transform, false);

		var textRect = textGameObject.AddComponent<RectTransform>();
		textRect.anchorMin = Vector2.zero;
		textRect.anchorMax = Vector2.one;
		textRect.offsetMin = new Vector2(10f, 5f);
		textRect.offsetMax = new Vector2(-10f, 5f);

		var text = textGameObject.AddComponent<Text>();
		text.font = Fonts.Normal;
		text.fontSize = 18;
		text.color = Color.white;
		text.alignment = TextAnchor.MiddleLeft;
		text.supportRichText = false;

		// Placeholder component
		var placeholderGameObject = new GameObject("Placeholder");
		placeholderGameObject.transform.SetParent(gameObject.transform, false);

		var placeholderRect = placeholderGameObject.AddComponent<RectTransform>();
		placeholderRect.anchorMin = Vector2.zero;
		placeholderRect.anchorMax = Vector2.one;
		placeholderRect.offsetMin = new Vector2(10f, 0f);
		placeholderRect.offsetMax = new Vector2(-10f, 0f);

		var placeholderText = placeholderGameObject.AddComponent<Text>();
		placeholderText.font = text.font;
		placeholderText.fontSize = text.fontSize;

		placeholderText.color = new Color(
			1f,
			1f,
			1f,
			0.5f
		);
		placeholderText.alignment = TextAnchor.MiddleLeft;
		placeholderText.text = placeholder;
		placeholderText.fontStyle = FontStyle.Italic;

		var inputField = gameObject.AddComponent<InputField>();
		inputField.textComponent = text;
		inputField.placeholder = placeholderText;
		inputField.targetGraphic = image;
		inputField.contentType = type;
		field._inputField = inputField;

		return field;
	}
}