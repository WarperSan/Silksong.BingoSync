using BingoAPI.Models;
using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.UI.Items;
using UnityEngine;

namespace Silksong.BingoSync.UI.Objects;

/// <summary>
/// Color scheme used to generate <see cref="TeamPickerButton"/>
/// </summary>
internal sealed class TeamColorScheme
{
	public record TeamColor
	{
		/// <summary>
		/// Team for which this color is for
		/// </summary>
		public readonly Team Team;

		/// <summary>
		/// Display name of the color
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// Color to display
		/// </summary>
		public readonly Color Color;

		/// <summary>
		/// Initializes a new instance of the <see cref="TeamColor"/> class.
		/// </summary>
		public TeamColor(Team team, string name, Color color)
		{
			Team = team;
			Name = name;
			Color = color;
		}
	}

	private readonly Dictionary<Team, TeamColor> _colors;

	/// <summary>
	/// Teams to display as the default ones
	/// </summary>
	public readonly Team[] DefaultColors;

	/// <summary>
	/// Teams to display when using <see cref="GeneralConfig.UseAdvancedTeams"/>
	/// </summary>
	public readonly Team[] AdvancedColors;

	/// <summary>
	/// Initializes a new instance of the <see cref="TeamColorScheme"/> class.
	/// </summary>
	public TeamColorScheme(TeamColor[] colors, Team[] defaultColors, Team[] advancedColors)
	{
		_colors = new Dictionary<Team, TeamColor>();

		foreach (var color in colors)
			_colors[color.Team] = color;

		DefaultColors = defaultColors;
		AdvancedColors = advancedColors;
	}

	/// <summary>
	/// Finds the defined <see cref="TeamColor"/> for the given <see cref="Team"/>
	/// </summary>
	public TeamColor GetTeamColor(Team team) => _colors[team];
}