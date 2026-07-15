using System.Diagnostics.CodeAnalysis;
using BingoAPI.Models;
using Silksong.BingoSync.Configurations;
using Silksong.BingoSync.UI.Objects;
using UnityEngine;

namespace Silksong.BingoSync.UI.Constants;

[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
[SuppressMessage("ReSharper", "StringLiteralTypo")]
[SuppressMessage("ReSharper", "IdentifierTypo")]
internal static class Colors
{
	#region Colors

	private static readonly TeamColorScheme.TeamColor[] MateriumColors =
	[
		new(Team.Red, "Rosary", new Color(1f, 0.28f, 0.27f)),
		new(Team.Blue, "Plasmium", new Color(0f, 0.71f, 1f)),
		new(Team.Green, "Mossberry", new Color(0.22f, 0.75f, 0.47f)),
		new(Team.Yellow, "Flintgem", new Color(0.89f, 0.63f, 0f)),
		new(Team.Purple, "Pollip", new Color(0.51f, 0.17f, 0.75f)),
		new(Team.Navy, "Magnetite", new Color(0.16f, 0.33f, 0.53f)),
		new(Team.Pink, "Voltridian", new Color(0.93f, 0.52f, 0.67f)),
		new(Team.Brown, "Pilgrim", new Color(0.37f, 0.29f, 0.27f)),
		new(Team.Orange, "Flintstone", new Color(0.96f, 0.6f, 0.2f)),
		new(Team.Teal, "Growstone", new Color(0.71f, 0.71f, 0.71f)),
	];

	private static readonly TeamColorScheme.TeamColor[] BingoSyncColors =
	[
		new(Team.Orange, "Orange", new Color(0.98f, 0.58f, 0.1f)),
		new(Team.Red, "Red", new Color(0.9f, 0.27f, 0.25f)),
		new(Team.Blue, "Blue", new Color(0.22f, 0.63f, 0.88f)),
		new(Team.Green, "Green", new Color(0f, 0.78f, 0.04f)),
		new(Team.Purple, "Purple", new Color(0.47f, 0.15f, 0.7f)),
		new(Team.Navy, "Navy", new Color(0f, 0.23f, 0.6f)),
		new(Team.Teal, "Teal", new Color(0.22f, 0.52f, 0.52f)),
		new(Team.Brown, "Brown", new Color(0.55f, 0.3f, 0.1f)),
		new(Team.Pink, "Pink", new Color(0.85f, 0.47f, 0.6f)),
		new(Team.Yellow, "Yellow", new Color(0.8f, 0.78f, 0.06f)),
	];

	#endregion

	#region Schemes

	/// <summary>
	/// Scheme of colors used for <see cref="GeneralConfig.ColorTheme.Materium"/>
	/// </summary>
	private static readonly TeamColorScheme MateriumScheme = new(
		MateriumColors,
		[
			Team.Red,
			Team.Blue,
			Team.Green,
			Team.Yellow,
		],
		[
			Team.Purple,
			Team.Navy,
			Team.Pink,
			Team.Brown,
		]
	);

	/// <summary>
	/// Scheme of colors for <see cref="GeneralConfig.ColorTheme.BingoSync"/>
	/// </summary>
	private static readonly TeamColorScheme BingoSyncScheme = new(
		BingoSyncColors,
		[
			Team.Orange,
			Team.Red,
			Team.Blue,
			Team.Green,
			//Team.Purple,
		],
		[
			Team.Purple,
			Team.Navy,
			Team.Teal,
			Team.Brown,
			//Team.Pink,
			//Team.Yellow,
		]
	);

	/// <summary>
	/// Gets the corresponding <see cref="TeamColorScheme"/> for the given <see cref="GeneralConfig.ColorTheme"/>
	/// </summary>
	public static TeamColorScheme GetSchemeForTheme(GeneralConfig.ColorTheme theme) => theme switch
	{
		GeneralConfig.ColorTheme.Materium  => MateriumScheme,
		GeneralConfig.ColorTheme.BingoSync => BingoSyncScheme,
		_                                  => throw new ArgumentOutOfRangeException(nameof(theme), theme, null),
	};

	#endregion
}