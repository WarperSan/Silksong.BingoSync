using BingoAPI.Models;
using BingoAPI.Models.Settings;
using Silksong.BingoSync.Helpers;
using Silksong.BingoSync.UI.Containers;
using UnityEngine;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Menus;

internal class ConnectionMenu : MonoBehaviour
{
	#region State

	private enum State
	{
		Offline,
		Connecting,
		Online,
		Disconnecting,
	}

	private State _state = State.Offline;

	private void SetOnline(Controller controller)
	{
		_state = State.Online;
		_joinForm?.DisableInputs();

		if (_teamPicker != null)
		{
			_teamPicker?.EnableInputs();
			_teamPicker?.SetTeam(controller.Team);
		}
	}

	private void SetOffline()
	{
		_state = State.Offline;
		_joinForm?.EnableInputs();

		if (_teamPicker != null)
		{
			_teamPicker?.DisableInputs();
			_teamPicker?.SetTeam(Team.None);
		}
	}

	#endregion

	private Button? _actionButton;
	private JoinForm? _joinForm;
	private TeamPicker? _teamPicker;

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

	private void OnTeamSelected(Team team)
	{
		if (_state != State.Online)
		{
			Log.Warning("Cannot change team without being online.");
			return;
		}

		_ = ChangeTeam(team);
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

	#region Tasks

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
				SetOffline();
				Log.Error($"Failed to join the room '{settings.Code}'.");
				return;
			}

			SetOnline(controller);
		}
		catch (Exception e)
		{
			SetOffline();
			Log.Error($"Error while joining the room '{settings.Code}': {e}");
		}
	}

	private async Task LeaveRoom()
	{
		if (_state != State.Online)
			throw new InvalidOperationException();

		var controller = Plugin.Controller;

		if (controller == null)
			throw new NullReferenceException($"No '{nameof(Controller)}' assigned.");

		_teamPicker?.DisableInputs();

		try
		{
			_state = State.Disconnecting;

			var succeeded = await controller.Exit();

			if (!succeeded)
			{
				SetOnline(controller);
				Log.Error("Failed to exit the room.");
				return;
			}

			SetOffline();
		}
		catch (Exception e)
		{
			SetOnline(controller);
			Log.Error($"Error while joining the room: {e}");
		}
	}

	private async Task ChangeTeam(Team team)
	{
		if (_state != State.Online)
			throw new InvalidOperationException();

		var controller = Plugin.Controller;

		if (controller == null)
			throw new NullReferenceException($"No '{nameof(Controller)}' assigned.");

		if (_teamPicker == null)
			throw new NullReferenceException($"No '{nameof(TeamPicker)}' assigned.");

		_teamPicker.DisableInputs();

		try
		{
			var succeeded = await controller.SetTeam(team);

			if (!succeeded)
				Log.Error("Failed to change team.");
		}
		catch (Exception e)
		{
			Log.Error($"Error while joining the room: {e}");
		}

		_teamPicker.SetTeam(controller.Team);
		_teamPicker.EnableInputs();
	}

	#endregion

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

		// Team Picker
		var teamPicker = TeamPicker.Create(
			[
				Team.Orange,
				Team.Red,
				Team.Blue,
				Team.Green,
				Team.Purple,
				Team.Navy,
				Team.Teal,
				Team.Brown,
				Team.Pink,
				Team.Yellow,
			],
			menu.OnTeamSelected
		);
		teamPicker.transform.SetParent(mainLayoutGroup.transform, false);
		menu._teamPicker = teamPicker;

		// Action Button
		var actionButton = Button.Create(menu.OnActionClicked);
		actionButton.transform.SetParent(gameObject.transform, false);
		actionButton.SetText("Join");
		menu._actionButton = actionButton;

		menu.SetOffline();

		return menu;
	}
}