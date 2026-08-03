using Silksong.BingoSync.Configurations;
using Silksong.ModMenu.Elements;
using Silksong.ModMenu.Plugin;
using Silksong.ModMenu.Screens;
using UnityEngine;

namespace Silksong.BingoSync;

/// <summary>
/// Class that generates a <see cref="AbstractMenuScreen"/> from the given <see cref="Configuration"/>
/// </summary>
internal static class ConfigMenu
{
	/// <summary>
	/// Creates a menu
	/// </summary>
	public static AbstractMenuScreen Create(Configuration configuration)
	{
		var screens = new[]
		{
			CreateGeneralConfig(configuration.General),
			CreateJoinConfig(configuration.Join),
			CreateBoardConfig(configuration.Board),
			CreateAccessibilityConfig(configuration.Accessibility),
			CreateExperimentalConfig(configuration.Experimental),
		};

		PaginatedMenuScreenBuilder builder = new(Plugin.Name);

		foreach (var screen in screens)
		{
			var button = new TextButton(screen);

			builder.Add(button);
		}

		return builder.Build();
	}

	private static AbstractMenuScreen CreateGeneralConfig(GeneralConfig config)
	{
		PaginatedMenuScreenBuilder builder = new("General");

		if (
			ConfigEntryFactory.GenerateBoolElement(
				config.UseAdvancedTeams,
				out var advancedTeamsElement
			)
		)
			builder.Add(advancedTeamsElement);

		return builder.Build();
	}

	private static AbstractMenuScreen CreateJoinConfig(JoinConfig config)
	{
		PaginatedMenuScreenBuilder builder = new("Join");

		if (ConfigEntryFactory.GenerateStringElement(config.Nickname, out var nicknameElement))
			builder.Add(nicknameElement);

		if (ConfigEntryFactory.GenerateStringElement(config.Code, out var codeElement))
			builder.Add(codeElement);

		if (ConfigEntryFactory.GenerateStringElement(config.Password, out var passwordElement))
			builder.Add(passwordElement);

		if (ConfigEntryFactory.GenerateKeyCodeElement(config.ToggleUI, out var toggleUIElement))
			builder.Add(toggleUIElement);

		return builder.Build();
	}

	private static AbstractMenuScreen CreateBoardConfig(BoardConfig config)
	{
		PaginatedMenuScreenBuilder builder = new("Board");

		if (ConfigEntryFactory.GenerateKeyCodeElement(config.ToggleUI, out var toggleUIElement))
			builder.Add(toggleUIElement);

		return builder.Build();
	}

	private static AbstractMenuScreen CreateExperimentalConfig(ExperimentalConfig config)
	{
		PaginatedMenuScreenBuilder builder = new("Experimental");

		var warningLabel = new TextLabel(
			"Theses settings are experimental and can cause performance issues"
		);
		warningLabel.Text.color = Color.yellow;
		warningLabel.Text.fontSize = 30;
		builder.Add(warningLabel);

		if (
			ConfigEntryFactory.GenerateBoolElement(
				config.EvaluateOnHeroUpdate,
				out var evaluateOnHeroUpdateElement
			)
		)
			builder.Add(evaluateOnHeroUpdateElement);

		return builder.Build();
	}

	private static AbstractMenuScreen CreateAccessibilityConfig(AccessibilityConfig config)
	{
		PaginatedMenuScreenBuilder builder = new("Accessibility");

		if (
			ConfigEntryFactory.GenerateEnumChoiceElement(
				config.BoardCellFont,
				out var boardCellFontElement
			)
		)
			builder.Add(boardCellFontElement);

		if (
			ConfigEntryFactory.GenerateEnumChoiceElement(
				config.BoardPosition,
				out var boardPositionElement
			)
		)
			builder.Add(boardPositionElement);

		if (
			ConfigEntryFactory.GenerateEnumChoiceElement(
				config.BoardScale,
				out var boardScaleElement
			)
		)
			builder.Add(boardScaleElement);

		if (
			MenuElementGenerators
				.CreateIntSliderGenerator()
				.Invoke(config.BoardOpacity, out var boardOpacityElement)
		)
			builder.Add(boardOpacityElement);

		return builder.Build();
	}
}
