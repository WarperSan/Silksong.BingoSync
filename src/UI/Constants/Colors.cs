using System.Diagnostics.CodeAnalysis;
using BingoAPI.Models;
using UnityEngine;

namespace Silksong.BingoSync.UI.Constants;

[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
internal static class Colors
{
	/// <summary>
	/// Gets the <see cref="Color"/> of this <see cref="Team"/>
	/// </summary>
	public static Color GetColor(this Team team) => team switch
	{
		Team.Orange => new Color(0.96f, 0.6f, 0.2f),
		Team.Red    => new Color(1f, 0.28f, 0.27f),
		Team.Blue   => new Color(0f, 0.71f, 1f),
		Team.Green  => new Color(0.22f, 0.75f, 0.47f),
		Team.Purple => new Color(0.51f, 0.17f, 0.75f),
		Team.Navy   => new Color(0.16f, 0.33f, 0.53f),
		Team.Teal   => new Color(0.71f, 0.71f, 0.71f),
		Team.Brown  => new Color(0.37f, 0.29f, 0.27f),
		Team.Pink   => new Color(0.93f, 0.52f, 0.67f),
		Team.Yellow => new Color(0.89f, 0.63f, 0f),
		Team.None   => Color.black,
		_           => throw new ArgumentOutOfRangeException(nameof(team), team, null),
	};

	/// <summary>
	/// Gets the display name of this <see cref="Team"/>
	/// </summary>
	public static string GetDisplayName(this Team team) => team switch
	{
		// ReSharper disable StringLiteralTypo
		Team.Red    => "Rosary",
		Team.Yellow => "Flintgem",
		Team.Green  => "Mossberry",
		Team.Blue   => "Plasmium",
		Team.Orange => "Flintstone",
		Team.Pink   => "Voltridian",
		Team.Navy   => "Magnetite",
		Team.Purple => "Pollip",
		Team.Brown  => "Pilgrim",
		Team.Teal   => "Growstone",
		// ReSharper restore StringLiteralTypo
		Team.None => "???",
		_         => throw new ArgumentOutOfRangeException(nameof(team), team, null),
	};
}