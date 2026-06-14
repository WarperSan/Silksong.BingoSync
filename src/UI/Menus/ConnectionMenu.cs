using BingoAPI.Models;
using BingoAPI.Models.Settings;
using Silksong.BingoSync.Helpers;
using Silksong.BingoSync.UI.Constants;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Menus;

internal class ConnectionMenu : MonoBehaviour
{
	private enum State
	{
		Offline,
		Connecting,
		Online,
		Disconnecting,
	}

	private State _state = State.Offline;

	private Button? _actionButton;

	private void OnActionClicked()
	{
		// TODO: Add functionality to cancel these states
		if (_state is State.Connecting or State.Disconnecting)
		{
			Log.Warning($"State '{_state}' has no action assigned.");
			return;
		}

		if (_state == State.Offline)
			_ = JoinRoom();
		else if (_state == State.Online)
			_ = LeaveRoom();
	}

	private async Task JoinRoom()
	{
		if (_state != State.Offline)
			throw new InvalidOperationException();

		var controller = Plugin.Controller;

		if (controller == null)
			throw new NullReferenceException();

		DisableInputs();

		var settings = GetSettings();

		try
		{
			_state = State.Connecting;

			var succeeded = await controller.Join(settings);

			if (!succeeded)
			{
				_state = State.Offline;
				Log.Error($"Failed to join the room '{settings.Code}'.");
				EnableInputs();
				return;
			}

			_state = State.Online;
		}
		catch (Exception e)
		{
			_state = State.Offline;
			Log.Error($"Error while joining the room '{settings.Code}': {e}");
			EnableInputs();
		}
	}

	private async Task LeaveRoom()
	{
		if (_state != State.Online)
			throw new InvalidOperationException();

		var controller = Plugin.Controller;

		if (controller == null)
			throw new NullReferenceException();

		try
		{
			_state = State.Disconnecting;

			var succeeded = await controller.Exit();

			if (!succeeded)
			{
				_state = State.Online;
				Log.Error("Failed to exit the room.");
				return;
			}

			_state = State.Offline;
			EnableInputs();
		}
		catch (Exception e)
		{
			_state = State.Online;
			Log.Error($"Error while joining the room: {e}");
		}
	}

	#region Inputs

	private CanvasGroup? _inputsGroup;
	private TextField? _roomCodeInput;
	private TextField? _nicknameInput;
	private TextField? _passwordInput;

	private JoinRoomSettings GetSettings()
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

	private void EnableInputs()  => _inputsGroup?.interactable = true;
	private void DisableInputs() => _inputsGroup?.interactable = false;

	#endregion

	private void Start()
	{
		if (_roomCodeInput != null)
			_roomCodeInput.Text = "6MuWtbUFQE-P70lS6-5BhQ";

		if (_nicknameInput != null)
			_nicknameInput.Text = "Silksong_Bingo";

		if (_passwordInput != null)
			_passwordInput.Text = "abc";
	}

	private void Update()
	{
		switch (_state)
		{
			case State.Offline:
				_actionButton?.SetText("Join");
				break;
			case State.Connecting:
				_actionButton?.SetText("Connecting...");
				break;
			case State.Online:
				_actionButton?.SetText("Leave");
				break;
			case State.Disconnecting:
				_actionButton?.SetText("Disconnecting...");
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	/// <summary>
	/// Creates a new instance of <see cref="ConnectionMenu"/>
	/// </summary>
	public static ConnectionMenu Create()
	{
		var gameObject = new GameObject(nameof(ConnectionMenu));
		var menu = gameObject.AddComponent<ConnectionMenu>();

		var rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMin = Vector2.zero;
		rectTransform.anchorMax = Vector2.one;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;

		var mainLayoutGroup = gameObject.AddComponent<VerticalLayoutGroup>();
		mainLayoutGroup.spacing = 10f;
		mainLayoutGroup.childAlignment = TextAnchor.LowerCenter;
		mainLayoutGroup.childControlWidth = true;
		mainLayoutGroup.childForceExpandWidth = true;
		mainLayoutGroup.childControlHeight = false;
		mainLayoutGroup.childForceExpandHeight = false;

		// Input Container
		var inputsGameObject = new GameObject("Inputs");
		inputsGameObject.transform.SetParent(mainLayoutGroup.transform, false);

		var inputsRect = inputsGameObject.AddComponent<RectTransform>();
		inputsRect.pivot = new Vector2(0.5f, 0f);

		var inputContentSizer = inputsGameObject.AddComponent<ContentSizeFitter>();
		inputContentSizer.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

		var inputContainer = inputsGameObject.AddComponent<VerticalLayoutGroup>();
		inputContainer.childControlWidth = true;
		inputContainer.childForceExpandWidth = true;
		inputContainer.childControlHeight = false;
		inputContainer.childForceExpandHeight = false;
		inputContainer.spacing = 10f;

		menu._inputsGroup = inputsGameObject.AddComponent<CanvasGroup>();

		// Inputs
		var codeInput = TextField.Create("Room Code");
		codeInput.transform.SetParent(inputsGameObject.transform, false);
		menu._roomCodeInput = codeInput;

		var nicknameInput = TextField.Create("Nickname");
		nicknameInput.transform.SetParent(inputsGameObject.transform, false);
		menu._nicknameInput = nicknameInput;

		var passwordInput = TextField.Create("Password", InputField.ContentType.Password);
		passwordInput.transform.SetParent(inputsGameObject.transform, false);
		menu._passwordInput = passwordInput;

		// Action Button
		var actionButton = Button.Create(menu.OnActionClicked);
		actionButton.transform.SetParent(gameObject.transform, false);
		actionButton.SetText("Join");
		menu._actionButton = actionButton;

		return menu;
	}
}