using BingoAPI.Events;
using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.UI.Components;
using UnityEngine;

namespace Silksong.BingoSync.UI.Containers;

/// <summary>
/// Component responsible to manage a <see cref="BingoBoard"/>
/// </summary>
internal class BoardContainer : MonoBehaviour
{
	private BingoBoard? _board;
	private CallOnInput? _toggleInput;

	private void Awake() => Subscribe(Plugin.Controller.Events);

	#region Visibility

	/// <summary>
	/// Toggles the visibility of the board
	/// </summary>
	private void ToggleVisibility()
	{
		if (_board == null)
			return;

		var isActive = _board.gameObject.activeInHierarchy;

		SetVisibility(!isActive);
	}

	/// <summary>
	/// Sets the visibility of the board
	/// </summary>
	private void SetVisibility(bool isVisible)
	{
		if (_board == null)
			return;

		_board.gameObject.SetActive(isVisible);
	}

	private void EnableVisibility()
	{
		if (_toggleInput != null)
			_toggleInput.enabled = true;

		SetVisibility(true);
	}

	private void DisableVisibility()
	{
		if (_toggleInput != null)
			_toggleInput.enabled = false;

		SetVisibility(false);
	}

	#endregion

	/// <summary>
	/// Subscribes this container to the given <see cref="EventDispatcher"/>
	/// </summary>
	private void Subscribe(EventDispatcher dispatcher)
	{
		dispatcher.OnSelfConnected += _ => EnableVisibility();
		dispatcher.OnSelfDisconnected += _ => DisableVisibility();
	}

	/// <summary>
	/// Creates a new instance of <see cref="BoardContainer"/>
	/// </summary>
	public static BoardContainer Create()
	{
		var gameObject = new GameObject(nameof(BoardContainer));
		var container = gameObject.AddComponent<BoardContainer>();

		var rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMin = Vector2.zero;
		rectTransform.anchorMax = Vector2.one;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;

		var input = gameObject.AddComponent<CallOnInput>();

		input.SetInput(Configuration.SafeInstance.Board.ToggleUI, container.ToggleVisibility);
		container._toggleInput = input;

		var board = BingoBoard.Create();
		board.transform.SetParent(rectTransform, false);
		container._board = board;

		container.DisableVisibility();

		return container;
	}
}
