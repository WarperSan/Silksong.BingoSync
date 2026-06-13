using BingoAPI.Models;
using UnityEngine;

namespace Silksong.BingoSync.UI.Constants;

internal static class Colors
{
	public static Color GetColor(this Team team) => team switch
	{
		Team.Orange => new Color(1.000f, 0.612f, 0.070f),
		Team.Red    => new Color(1.000f, 0.286f, 0.267f),
		Team.Blue   => new Color(0.251f, 0.612f, 1.000f),
		Team.Green  => new Color(0.192f, 0.847f, 0.078f),
		Team.Purple => new Color(0.510f, 0.176f, 0.749f),
		Team.Navy   => new Color(0.051f, 0.282f, 0.710f),
		Team.Teal   => new Color(0.255f, 0.588f, 0.584f),
		Team.Brown  => new Color(0.671f, 0.361f, 0.137f),
		Team.Pink   => new Color(0.929f, 0.525f, 0.667f),
		Team.Yellow => new Color(0.847f, 0.816f, 0.078f),
		_           => Color.black,
	};
}