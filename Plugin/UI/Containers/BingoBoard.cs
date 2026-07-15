using BingoAPI.Models;
using Silksong.BingoSync.UI.Items;
using Silksong.BingoSync.UI.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Containers;

internal class BingoBoard : MonoBehaviour
{
	private BingoCell[]? _cells;

	private void Awake() => Subscribe(Plugin.Controller);

	/// <summary>
	/// Displays the given <see cref="Card"/>
	/// </summary>
	private void DisplayCard(Card? card)
	{
		if (card == null)
			return;

		if (_cells == null)
			return;

		for (var i = 0; i < _cells.Length; i++)
		{
			var goal = card.GetGoalAt(i);
			var teams = card.GetTeamsAt(i);

			_cells[i].SetSquare(goal, teams);
		}
	}

	#region Events

	/// <summary>
	/// Subscribes this board to the given <see cref="Controller"/>
	/// </summary>
	private void Subscribe(Controller controller)
	{
		controller.OnCardUpdated += DisplayCard;

		var dispatcher = controller.Events;

		dispatcher.OnSelfSquareMarked += OnSquareMarked;
		dispatcher.OnOtherSquareMarked += OnSquareMarked;
		dispatcher.OnSelfSquareCleared += OnSquareCleared;
		dispatcher.OnOtherSquareCleared += OnSquareCleared;
	}

	private void OnSquareMarked(Player player, Square square, Team team) => _cells?[square.Slot.Index].AddTeam(team);

	private void OnSquareCleared(Player player, Square square, Team team) => _cells?[square.Slot.Index].RemoveTeam(team);

	#endregion

	/// <summary>
	/// Creates a new instance of <see cref="BingoBoard"/>
	/// </summary>
	public static BingoBoard Create(TeamColorScheme scheme)
	{
		var gameObject = new GameObject(nameof(BingoBoard));
		var rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMax = Vector2.one;
		rectTransform.anchorMin = Vector2.one;
		rectTransform.pivot = Vector2.one;

		var sizeFitter = gameObject.AddComponent<ContentSizeFitter>();
		sizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
		sizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

		var backgroundShadow = gameObject.AddComponent<Image>();

		backgroundShadow.color = Color.black;

		var board = gameObject.AddComponent<BingoBoard>();
		var grid = gameObject.AddComponent<GridLayoutGroup>();
		grid.cellSize = Vector2.one * 100f;
		grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
		grid.constraintCount = 5;
		grid.childAlignment = TextAnchor.UpperLeft;
		grid.spacing = Vector2.one * 5f;

		var cells = new BingoCell[25];

		for (var i = 0; i < cells.Length; i++)
		{
			var cell = BingoCell.Create(scheme);

			cell.transform.SetParent(grid.transform, false);

			cells[i] = cell;
		}

		board._cells = cells;

		var canvasGroup = gameObject.AddComponent<CanvasGroup>();
		canvasGroup.blocksRaycasts = false;

		return board;
	}
}