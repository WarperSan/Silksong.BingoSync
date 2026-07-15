using BingoAPI.Goals;
using BingoAPI.Models;
using Silksong.BingoSync.UI.Constants;
using Silksong.BingoSync.UI.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Silksong.BingoSync.UI.Items;

/// <summary>
/// Component responsible to display a given <see cref="Goal"/>
/// </summary>
internal class BingoCell : MonoBehaviour
{
	private Text? _text;
	private Dictionary<Team, Image>? _teamMarks;

	public void SetSquare(Goal goal, Team teams)
	{
		_text?.text = goal.Name;

		if (_teamMarks != null)
		{
			foreach ((var team, var image) in _teamMarks)
			{
				var hasTeam = teams.HasFlag(team);

				image.gameObject.SetActive(hasTeam);
			}
		}
	}

	/// <summary>
	/// Adds the given <see cref="Team"/> as a marked team
	/// </summary>
	public void AddTeam(Team team)
	{
		if (_teamMarks == null)
			return;

		if (!_teamMarks.TryGetValue(team, out var image))
			return;

		image.gameObject.SetActive(true);
	}

	/// <summary>
	/// Removes the given <see cref="Team"/> as a marked team
	/// </summary>
	public void RemoveTeam(Team team)
	{
		if (_teamMarks == null)
			return;

		if (!_teamMarks.TryGetValue(team, out var image))
			return;

		image.gameObject.SetActive(false);
	}

	/// <summary>
	/// Creates a new instance of <see cref="BingoCell"/>
	/// </summary>
	public static BingoCell Create(TeamColorScheme scheme)
	{
		var gameObject = new GameObject(nameof(BingoCell));
		gameObject.AddComponent<RectTransform>();

		var cell = gameObject.AddComponent<BingoCell>();

		var backgroundGo = new GameObject("Background");
		backgroundGo.transform.SetParent(gameObject.transform, false);

		var background = backgroundGo.AddComponent<Image>();

		background.color = new Color(
			0.1f,
			0.1f,
			0.1f,
			1f
		);

		var backgroundContainer = backgroundGo.AddComponent<VerticalLayoutGroup>();
		backgroundContainer.childAlignment = TextAnchor.MiddleCenter;

		Dictionary<Team, Image> backgroundImages = [];

		foreach (Team team in Enum.GetValues(typeof(Team)))
		{
			if (team == Team.None)
				continue;

			var teamColor = scheme.GetTeamColor(team);

			var backgroundImage = new GameObject(teamColor.Name);
			backgroundImage.transform.SetParent(backgroundContainer.transform, false);

			var image = backgroundImage.AddComponent<Image>();

			image.color = teamColor.Color;

			backgroundImages.Add(team, image);
		}

		var darkenerGo = new GameObject("Darkener");
		darkenerGo.transform.SetParent(gameObject.transform, false);

		var darkener = darkenerGo.AddComponent<Image>();

		darkener.color = new Color(
			0f,
			0f,
			0f,
			0.4f
		);

		var textGo = new GameObject("Text");
		textGo.transform.SetParent(gameObject.transform, false);

		var textRect = textGo.AddComponent<RectTransform>();
		textRect.anchorMin = Vector2.zero;
		textRect.anchorMax = Vector2.one;
		textRect.offsetMin = Vector2.one * 5f;
		textRect.offsetMax = -Vector2.one * 5f;

		var text = textGo.AddComponent<Text>();
		text.fontSize = 12;
		text.text = "OwO";
		text.alignment = TextAnchor.MiddleLeft;
		text.color = Color.white;
		text.font = Fonts.Normal;

		cell._text = text;
		cell._teamMarks = backgroundImages;

		return cell;
	}
}