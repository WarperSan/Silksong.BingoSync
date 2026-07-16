using BingoAPI.Models;
using Silksong.BingoSync.UI.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Items;

/// <summary>
/// Component responsible to display a <see cref="BingoAPI.Models.Team"/>
/// </summary>
internal class TeamPickerButton : MonoBehaviour
{
	private Outline? _outline;
	private Action<Team>? _onClick;
	private Color _teamColor = Color.white;

	public Team Team { get; private set; }

	/// <summary>
	/// Shows this button as selected
	/// </summary>
	public void Select()
	{
		if (_outline != null)
			_outline.effectColor = Color.white;
	}

	/// <summary>
	/// Shows this button as unselected
	/// </summary>
	public void Unselect()
	{
		if (_outline != null)
			_outline.effectColor = _teamColor;
	}

	private void OnClick() => _onClick?.Invoke(Team);

	/// <summary>
	/// Creates a new instance of <see cref="TeamPickerButton"/>
	/// </summary>
	public static TeamPickerButton Create(Team team, Action<Team> onClick)
	{
		var gameObject = new GameObject(nameof(TeamPickerButton));
		gameObject.AddComponent<RectTransform>();

		var picker = gameObject.AddComponent<TeamPickerButton>();
		picker.Team = team;
		picker._onClick = onClick;

		var teamColor = team.GetColor();
		picker._teamColor = teamColor;

		var image = gameObject.AddComponent<Image>();
		var color = teamColor * 0.6f;
		color.a = 1f;
		image.color = color;

		var button = gameObject.AddComponent<Button>();
		button.targetGraphic = image;
		button.onClick.AddListener(picker.OnClick);

		var buttonColors = button.colors;

		buttonColors.disabledColor = new Color(0.3f, 0.3f, 0.3f, 1f);
		button.colors = buttonColors;

		picker._outline = button.gameObject.AddComponent<Outline>();

		var textGo = new GameObject(nameof(Text));
		textGo.transform.SetParent(gameObject.transform, false);

		var textRect = textGo.AddComponent<RectTransform>();
		textRect.anchorMin = Vector2.zero;
		textRect.anchorMax = Vector2.one;
		textRect.offsetMin = Vector2.zero;
		textRect.offsetMax = Vector2.zero;

		var label = textGo.AddComponent<Text>();
		label.font = Fonts.Normal;
		label.fontSize = 17;
		label.color = Color.white;
		label.alignment = TextAnchor.MiddleCenter;
		label.text = team.GetDisplayName();

		picker.Unselect();

		return picker;
	}
}
