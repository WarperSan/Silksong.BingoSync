using BingoAPI.Models.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Containers;

/// <summary>
/// Component responsible to manage all inputs for joining
/// </summary>
internal class JoinForm : MonoBehaviour
{
	private CanvasGroup? _canvasGroup;
	private TextField? _roomCodeInput;
	private TextField? _nicknameInput;
	private TextField? _passwordInput;

	/// <summary>
	/// Sets the given settings in this form
	/// </summary>
	public void SetSettings(JoinRoomSettings settings)
	{
		if (_roomCodeInput != null)
			_roomCodeInput.Text = settings.Code;

		if (_nicknameInput != null)
			_nicknameInput.Text = settings.Nickname;

		if (_passwordInput != null)
			_passwordInput.Text = settings.Password;
	}

	/// <summary>
	/// Gets settings of this form
	/// </summary>
	public JoinRoomSettings GetSettings()
	{
		JoinRoomSettings settings = new();

		if (_roomCodeInput != null)
			settings.Code = _roomCodeInput.Text;

		if (_nicknameInput != null)
			settings.Nickname = _nicknameInput.Text;

		if (_passwordInput != null)
			settings.Password = _passwordInput.Text;

		return settings;
	}

	/// <summary>
	/// Enables all inputs
	/// </summary>
	public void EnableInputs()
	{
		if (_canvasGroup == null)
			return;

		_canvasGroup.interactable = true;
	}

	/// <summary>
	/// Disables all inputs
	/// </summary>
	public void DisableInputs()
	{
		if (_canvasGroup == null)
			return;

		_canvasGroup.interactable = false;
	}

	/// <summary>
	/// Creates a new instance of <see cref="JoinForm"/>
	/// </summary>
	public static JoinForm Create()
	{
		var gameObject = new GameObject(nameof(JoinForm));
		var form = gameObject.AddComponent<JoinForm>();

		var rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.pivot = new Vector2(0.5f, 0f);

		var contentSizer = gameObject.AddComponent<ContentSizeFitter>();
		contentSizer.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

		var layoutGroup = gameObject.AddComponent<VerticalLayoutGroup>();
		layoutGroup.childControlWidth = true;
		layoutGroup.childForceExpandWidth = true;
		layoutGroup.childControlHeight = false;
		layoutGroup.childForceExpandHeight = false;
		layoutGroup.spacing = 10f;

		form._canvasGroup = gameObject.AddComponent<CanvasGroup>();

		// Inputs
		var codeInput = TextField.Create("Room Code");
		codeInput.transform.SetParent(gameObject.transform, false);
		form._roomCodeInput = codeInput;

		var nicknameInput = TextField.Create("Nickname");
		nicknameInput.transform.SetParent(gameObject.transform, false);
		form._nicknameInput = nicknameInput;

		var passwordInput = TextField.Create("Password", InputField.ContentType.Password);
		passwordInput.transform.SetParent(gameObject.transform, false);
		form._passwordInput = passwordInput;

		return form;
	}
}