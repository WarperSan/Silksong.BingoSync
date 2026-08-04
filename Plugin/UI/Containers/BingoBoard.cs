using System.Diagnostics.CodeAnalysis;
using BingoAPI.Goals;
using BingoAPI.Models;
using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.Helpers;
using Silksong.BingoSync.UI.Components;
using Silksong.BingoSync.UI.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Containers;

public class BingoBoard : MonoBehaviour
{
	private RectTransform? _rectTransform;
	private GridLayoutGroup? _gridLayout;

	private void Awake() => Subscribe(Plugin.Controller);

	/// <summary>
	/// Displays the given <see cref="Card"/>
	/// </summary>
	private void DisplayCard(Card? card)
	{
		if (card == null)
			return;

		if (_gridLayout == null)
			return;

		_gridLayout.enabled = false;

		DisableAllCells();

		var count = card.Size * card.Size;
		_gridLayout.constraintCount = card.Size;

		for (var i = 0; i < count; i++)
		{
			var goal = card.GetGoalAt(i);
			var teams = card.GetTeamsAt(i);

			SetCell(i, goal, teams);
		}

		_gridLayout.enabled = true;
		LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
	}

	#region Cells

	private readonly List<BingoCell?> _cells = [];

	/// <summary>
	/// Creates a new instance of <see cref="BingoCell"/>
	/// </summary>
	internal BingoCell CreateCell()
	{
		var cell = BingoCell.Create();

		var parent = _gridLayout != null ? _gridLayout.transform : transform;
		cell.transform.SetParent(parent, false);

		return cell;
	}

	/// <summary>
	/// Attempts to get the <see cref="BingoCell"/> at the given index
	/// </summary>
	internal bool TryGetCell(int index, [NotNullWhen(true)] out BingoCell? cell)
	{
		if (index < 0 || index >= _cells.Count)
		{
			cell = null;
			return false;
		}

		cell = _cells[index];
		return cell != null;
	}

	/// <summary>
	/// Disables all created <see cref="BingoCell"/>
	/// </summary>
	private void DisableAllCells()
	{
		for (var i = _cells.Count - 1; i >= 0; i--)
		{
			var cell = _cells[i];

			// Clear entry
			if (cell == null)
			{
				_cells.RemoveAt(i);
				continue;
			}

			cell.gameObject.SetActive(false);
		}
	}

	/// <summary>
	/// Sets the information of the cell at the given index
	/// </summary>
	private void SetCell(int index, Goal goal, Team teams)
	{
		if (!TryGetCell(index, out var cell))
		{
			Log.Info("Creating at: " + index);
			cell = CreateCell();
			Log.Info("Created: " + index);

			if (_cells.Count <= index)
			{
				for (var i = _cells.Count; i < index; i++)
				{
					Log.Info("Adding null:" + i);
					_cells.Add(null);
				}

				_cells.Add(cell);
			}
			else
				_cells[index] = cell;
		}

		cell.SetSquare(goal, teams);
		cell.gameObject.SetActive(true);
	}

	#endregion

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

	private void OnSquareMarked(Player player, Square square, Team team)
	{
		if (!TryGetCell(square.Index, out var cell))
			return;

		cell.AddTeam(team);
	}

	private void OnSquareCleared(Player player, Square square, Team team)
	{
		if (!TryGetCell(square.Index, out var cell))
			return;

		cell.RemoveTeam(team);
	}

	#endregion

	/// <summary>
	/// Creates a new instance of <see cref="BingoBoard"/>
	/// </summary>
	public static BingoBoard Create()
	{
		var gameObject = new GameObject(nameof(BingoBoard));
		var board = gameObject.AddComponent<BingoBoard>();
		var rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMax = Vector2.one;
		rectTransform.anchorMin = Vector2.one;
		rectTransform.pivot = Vector2.one;
		board._rectTransform = rectTransform;

		var accessibilityPosition = gameObject.AddComponent<AccessibilityElementPosition>();
		accessibilityPosition.Bind(Configuration.SafeInstance.Accessibility.BoardPosition);

		var accessibilityScale = gameObject.AddComponent<AccessibilityElementScale>();
		accessibilityScale.Bind(Configuration.SafeInstance.Accessibility.BoardScale);

		var sizeFitter = gameObject.AddComponent<ContentSizeFitter>();
		sizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
		sizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

		var backgroundShadow = gameObject.AddComponent<Image>();

		backgroundShadow.color = Color.black;

		var grid = gameObject.AddComponent<GridLayoutGroup>();
		grid.cellSize = Vector2.one * 100f;
		grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
		grid.constraintCount = 5;
		grid.childAlignment = TextAnchor.UpperLeft;
		grid.spacing = Vector2.one * 5f;
		board._gridLayout = grid;

		var canvasGroup = gameObject.AddComponent<CanvasGroup>();
		canvasGroup.blocksRaycasts = false;

		var accessibilityOpacity = gameObject.AddComponent<AccessibilityOpacity>();
		accessibilityOpacity.Bind(Configuration.SafeInstance.Accessibility.BoardOpacity);

		return board;
	}
}
