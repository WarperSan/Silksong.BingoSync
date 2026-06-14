using BingoAPI.Models;
using Silksong.BingoSync.UI.Constants;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Menus;

internal class ConnectionMenu : MonoBehaviour
{
	private TextField? _roomCodeInput;
	private TextField? _nicknameInput;
	private TextField? _passwordInput;

	private CanvasGroup? _canvasGroup;

	private Dictionary<Team, TeamPickerButton>? _colorButtons;
	private Team _selectedColor = Team.Orange;

	#region Join Button

	private Text? _joinRoomButtonLabel;

	private static Text CreateJoinButton(Transform parent, UnityAction onClick)
	{
		var go = new GameObject("Join");
		go.transform.SetParent(parent, false);

		var rectTransform = go.AddComponent<RectTransform>();
		rectTransform.anchorMin = Vector2.zero;
		rectTransform.anchorMax = Vector2.one;
		rectTransform.sizeDelta = new Vector2(300f, 50f);

		var image = go.AddComponent<Image>();

		image.color = new Color(
			0f,
			0f,
			0f,
			0.6f
		);

		var button = go.AddComponent<Button>();
		button.targetGraphic = image;
		button.onClick.AddListener(onClick);

		var textGameObject = new GameObject("Text", typeof(RectTransform));
		textGameObject.transform.SetParent(go.transform, false);

		var textRect = textGameObject.GetComponent<RectTransform>();
		textRect.anchorMin = Vector2.zero;
		textRect.anchorMax = Vector2.one;
		textRect.offsetMin = Vector2.zero;
		textRect.offsetMax = Vector2.zero;

		var label = textGameObject.AddComponent<Text>();
		label.font = Fonts.Normal;
		label.fontSize = 18;
		label.color = Color.white;
		label.alignment = TextAnchor.MiddleCenter;

		return label;
	}

	#endregion

	/// <summary>
	/// Builds the connection menu UI from scratch under the given parent transform.
	/// </summary>
	public static ConnectionMenu Create()
	{
		var root = new GameObject(nameof(ConnectionMenu), typeof(RectTransform));

		var rootRect = root.GetComponent<RectTransform>();
		rootRect.anchorMin = new Vector2(0f, 0f);
		rootRect.anchorMax = new Vector2(1f, 0.5f);
		rootRect.pivot = new Vector2(1f, 0.5f);
		rootRect.anchoredPosition = new Vector2(-20f, 0f);

		var rootLayout = root.AddComponent<VerticalLayoutGroup>();
		rootLayout.spacing = 10f;
		rootLayout.childAlignment = TextAnchor.MiddleRight;
		rootLayout.childControlWidth = true;
		rootLayout.childForceExpandWidth = true;
		rootLayout.childControlHeight = false;
		rootLayout.childForceExpandHeight = false;

		var rootFitter = root.AddComponent<ContentSizeFitter>();
		rootFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
		rootFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

		var menu = root.AddComponent<ConnectionMenu>();

		// Text inputs
		var roomCodeInput = TextField.Create("Room Link");
		roomCodeInput.transform.SetParent(root.transform, false);
		menu._roomCodeInput = roomCodeInput;

		var nicknameInput = TextField.Create("Nickname Link");
		nicknameInput.transform.SetParent(root.transform, false);
		menu._nicknameInput = nicknameInput;

		var passwordInput = TextField.Create("Room Link", InputField.ContentType.Password);
		passwordInput.transform.SetParent(root.transform, false);
		menu._passwordInput = passwordInput;

		// Canvas Group
		menu._canvasGroup = root.AddComponent<CanvasGroup>();

		// Color buttons grid
		var colorGrid = new GameObject("ColorButtons", typeof(RectTransform));
		colorGrid.transform.SetParent(root.transform, false);

		var colorGridLayout = colorGrid.AddComponent<GridLayoutGroup>();
		colorGridLayout.cellSize = new Vector2(100f, 50f);
		colorGridLayout.spacing = new Vector2(10f, 10f);
		colorGridLayout.childAlignment = TextAnchor.MiddleRight;
		colorGridLayout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
		colorGridLayout.constraintCount = 2;

		var colorGridFitter = colorGrid.AddComponent<ContentSizeFitter>();
		colorGridFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
		colorGridFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

		menu._colorButtons = [];

		foreach (Team team in Enum.GetValues(typeof(Team)))
		{
			if (team == Team.None)
				continue;

			var picker = TeamPickerButton.Create(team, menu.OnTeamPicked);
			picker.transform.SetParent(colorGridFitter.transform, false);

			menu._colorButtons[team] = picker;
		}

		menu._joinRoomButtonLabel = CreateJoinButton(
			root.transform,
			async void () => await menu.JoinRoom()
		);

		return menu;
	}

	private void OnTeamPicked(Team team)
	{
		if (_colorButtons != null && _colorButtons.TryGetValue(_selectedColor, out var previousPicker))
			previousPicker.Unselect();

		_selectedColor = team;

		if (_colorButtons != null && _colorButtons.TryGetValue(_selectedColor, out var currentPicker))
			currentPicker.Select();
	}

	private void Awake()
	{
		if (_roomCodeInput != null)
			_roomCodeInput.Text = "6MuWtbUFQE-P70lS6-5BhQ";

		if (_nicknameInput != null)
			_nicknameInput.Text = "HK_BingoAP";

		if (_passwordInput != null)
			_passwordInput.Text = "abc";

		const Team TEAM = Team.Red;

		if (_colorButtons != null && _colorButtons.TryGetValue(TEAM, out var picker))
			picker.Select();

		_selectedColor = TEAM;
	}

	public void Update()
	{
		// ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
		switch (Controller.Instance?.State)
		{
			case ClientState.Connected:
				_joinRoomButtonLabel?.text = "Exit Room";
				_canvasGroup?.interactable = false;
				break;
			case ClientState.Loading:
				_joinRoomButtonLabel?.text = "Loading...";
				_canvasGroup?.interactable = false;
				break;
			default:
				_joinRoomButtonLabel?.text = "Join Room";
				_canvasGroup?.interactable = true;
				break;
		}
	}
	
	private async Task JoinRoom()
	{
		var controller = Controller.Instance;

		if (controller == null)
			return;

		if (controller.State == ClientState.Connected)
		{
			await controller.ExitRoom();
			Update();
			return;
		}

		await controller.JoinRoom(
			_roomCodeInput?.Text ?? "",
			_nicknameInput?.Text ?? "",
			_passwordInput?.Text ?? "",
			_selectedColor
		);

		Update();
	}
}