using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="Tool"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	// TODO: Consider if it is better to associate Tool with ToolItem

	/// <summary>
	/// Gets the identifier of the given <see cref="Tool"/>
	/// </summary>
	private static string GetToolId(Tool tool) => tool switch
	{
		// ReSharper disable StringLiteralTypo
		Tool.StraightPin       => "Straight Pin",
		Tool.ThreefoldPin      => "Tri Pin",
		Tool.StingShard        => "Sting Shard",
		Tool.Tacks             => "Tack",
		Tool.Longpin           => "Harpoon",
		Tool.Curveclaw         => "Curve Claws",
		Tool.Curvesickle       => "Curve Claws Upgraded",
		Tool.ThrowingRing      => "Shakra Ring",
		Tool.Pimpillo          => "Pimpilo",
		Tool.Conchcutter       => "Conch Drill",
		Tool.WeaverSilkshot    => "WebShot Weaver",
		Tool.ForgeSilkshot     => "WebShot Forge",
		Tool.ArchitectSilkshot => "WebShot Architect",
		Tool.DelversDrill      => "Screw Attack",
		Tool.CogworkWheel      => "Cogwork Saw",
		Tool.Cogfly            => "Cogwork Flier",
		Tool.RosaryCannon      => "Rosary Cannon",
		Tool.Voltvessels       => "Lightning Rod",
		Tool.Flintslate        => "Flintstone",
		Tool.SnareSetter       => "Silk Snare",
		Tool.FleaBrew          => "Flea Brew",
		Tool.PlasmiumPhial     => "Lifeblood Syringe",
		Tool.NeedlePhial       => "Extractor",
		Tool.DruidsEye         => "Mosscreep Tool 1",
		Tool.DruidsEyes        => "Mosscreep Tool 2",
		Tool.MagmaBell         => "Lava Charm",
		Tool.WardingBell       => "Bell Bind",
		Tool.PollipPouch       => "Poison Pouch",
		Tool.FracturedMask     => "Fractured Mask",
		Tool.Multibinder       => "Multibind",
		Tool.Weavelight        => "White Ring",
		Tool.SawtoothCirclet   => "Brolly Spike",
		Tool.InjectorBand      => "Quickbind",
		Tool.SpoolExtender     => "Spool Extender",
		Tool.ReserveBind       => "Reserve Bind",
		Tool.ClawMirror        => "Dazzle Bind",
		Tool.ClawMirrors       => "Dazzle Bind Upgraded",
		Tool.MemoryCrystal     => "Revenge Crystal",
		Tool.SnitchPick        => "Thief Claw",
		Tool.VoltFilament      => "Zap Imbuement",
		Tool.QuickSling        => "Quick Sling",
		Tool.WreathOfPurity    => "Maggot Charm",
		Tool.Longclaw          => "Longneedle",
		Tool.WispfireLantern   => "Wisp Lantern",
		Tool.EggOfFlealia      => "Flea Charm",
		Tool.PinBadge          => "Pinstress Tool",
		Tool.Compass           => "Compass",
		Tool.ShardPendant      => "Bone Necklace",
		Tool.MagnetiteBrooch   => "Rosary Magnet",
		Tool.WeightedBelt      => "Weighted Anklet",
		Tool.BarbedBracelet    => "Barbed Wire",
		Tool.DeadBugsPurse     => "Dead Mans Purse",
		Tool.ShellSatchel      => "Shell Satchel",
		Tool.MagnetiteDice     => "Magnetite Dice",
		Tool.Scuttlebrace      => "Scuttlebrace",
		Tool.AscendantsGrip    => "Wallcling",
		Tool.SpiderStrings     => "Musician Charm",
		Tool.SilkspeedAnklets  => "Sprintmaster",
		Tool.ThiefsMark        => "Thief Charm",
		// ReSharper restore StringLiteralTypo
		_ => throw new InvalidCheckException<Tool>(tool),
	};

	/// <summary>
	/// Gets the data of the given <see cref="Tool"/>
	/// </summary>
	private static ToolItemsData.Data? GetToolData(this PlayerData data, Tool tool)
	{
		var id = GetToolId(tool);

		return data.Tools.GetData(id);
	}

	/// <summary>
	/// Checks if the given <see cref="Tool"/> was obtained
	/// </summary>
	public static bool HasTool(this PlayerData data, Tool tool)
	{
		var toolData = data.GetToolData(tool);

		if (!toolData.HasValue)
			return false;

		return toolData.Value.IsUnlocked;
	}
}