using System.Diagnostics.CodeAnalysis;
using BingoAPI.Models;
using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.UI.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Containers;

/// <summary>
/// Component responsible to pick a <see cref="BingoAPI.Models.Team"/>
/// </summary>
internal class TeamPicker : MonoBehaviour
{
	private CanvasGroup? _canvasGroup;
	private Dictionary<Team, TeamPickerButton>? _buttons;
	private Action<Team>? _onTeamSelected;
	private Team _team;

	/// <summary>
	/// Sets the selected team to the given <see cref="Team"/>
	/// </summary>
	public void SetTeam(Team team)
	{
		if (TryGetButton(_team, out var previousButton))
			previousButton.Unselect();

		if (TryGetButton(team, out var currentButton))
			currentButton.Select();

		_team = team;
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
	/// Attempts to get the <see cref="TeamPickerButton"/> associated with the given <see cref="Team"/>
	/// </summary>
	private bool TryGetButton(Team team, [NotNullWhen(true)] out TeamPickerButton? button)
	{
		if (_buttons == null)
		{
			button = null;
			return false;
		}

		return _buttons.TryGetValue(team, out button);
	}

	private void OnTeamSelected(Team team) => _onTeamSelected?.Invoke(team);

	/// <summary>
	/// Creates a new instance of <see cref="TeamPicker"/>
	/// </summary>
	public static TeamPicker Create(Action<Team> onTeamSelected)
	{
		var gameObject = new GameObject(nameof(TeamPicker));
		var picker = gameObject.AddComponent<TeamPicker>();

		var rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.pivot = new Vector2(0.5f, 0f);

		var layoutGroup = gameObject.AddComponent<GridLayoutGroup>();
		layoutGroup.childAlignment = TextAnchor.MiddleCenter;
		layoutGroup.cellSize = new Vector2(125f, 50f);
		layoutGroup.spacing = Vector2.one * 10f;

		var contentFitter = gameObject.AddComponent<ContentSizeFitter>();
		contentFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

		picker._canvasGroup = gameObject.AddComponent<CanvasGroup>();

		var buttons = new Dictionary<Team, TeamPickerButton>();

		List<Team> teams = [Team.Red, Team.Blue, Team.Green, Team.Yellow];

		if (Configuration.SafeInstance.General.UseAdvancedTeams.Value)
		{
			teams.Add(Team.Purple);
			teams.Add(Team.Navy);
			teams.Add(Team.Pink);
			teams.Add(Team.Brown);
		}

		foreach (var team in teams)
		{
			var button = TeamPickerButton.Create(team, picker.OnTeamSelected);

			button.transform.SetParent(gameObject.transform, false);

			buttons[team] = button;
		}

		picker._buttons = buttons;
		picker._onTeamSelected = onTeamSelected;

		return picker;
	}
}
