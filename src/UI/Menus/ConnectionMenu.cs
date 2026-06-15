using BingoAPI.Models.Settings;
using Silksong.BingoSync.Helpers;
using Silksong.BingoSync.UI.Containers;
using UnityEngine;
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
	private JoinForm? _joinForm;

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
			throw new NullReferenceException($"No '{nameof(Controller)}' assigned.");

		if (_joinForm == null)
			throw new NullReferenceException($"No '{nameof(JoinForm)}' assigned.");

		_joinForm.DisableInputs();

		var settings = _joinForm.GetSettings();

		try
		{
			_state = State.Connecting;

			var succeeded = await controller.Join(settings);

			if (!succeeded)
			{
				_state = State.Offline;
				Log.Error($"Failed to join the room '{settings.Code}'.");
				_joinForm.EnableInputs();
				return;
			}

			_state = State.Online;
		}
		catch (Exception e)
		{
			_state = State.Offline;
			Log.Error($"Error while joining the room '{settings.Code}': {e}");
			_joinForm.EnableInputs();
		}
	}

	private async Task LeaveRoom()
	{
		if (_state != State.Online)
			throw new InvalidOperationException();

		var controller = Plugin.Controller;

		if (controller == null)
			throw new NullReferenceException($"No '{nameof(Controller)}' assigned.");

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
			_joinForm?.EnableInputs();
		}
		catch (Exception e)
		{
			_state = State.Online;
			Log.Error($"Error while joining the room: {e}");
		}
	}

	private void Start()
	{
		var settings = new JoinRoomSettings
		{
			Code = "6MuWtbUFQE-P70lS6-5BhQ",
			Nickname = "Silksong_Bingo",
			Password = "abc",
		};

		if (_joinForm != null)
			_joinForm.SetSettings(settings);
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
		var joinForm = JoinForm.Create();
		joinForm.transform.SetParent(mainLayoutGroup.transform, false);
		menu._joinForm = joinForm;

		// Action Button
		var actionButton = Button.Create(menu.OnActionClicked);
		actionButton.transform.SetParent(gameObject.transform, false);
		actionButton.SetText("Join");
		menu._actionButton = actionButton;

		return menu;
	}
}