using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="SilkSkill"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	// TODO: Consider if it is better to associate SilkSkill with ToolItemSkill

	/// <summary>
	/// Gets the identifier of the given <see cref="SilkSkill"/>
	/// </summary>
	private static string GetSilkSkillId(SilkSkill skill) => skill switch
	{
		SilkSkill.Silkspear   => "Silk Spear",
		SilkSkill.ThreadStorm => "Thread Sphere",
		SilkSkill.CrossStitch => "Parry",
		SilkSkill.Sharpdart   => "Silk Charge",
		SilkSkill.RuneRage    => "Silk Bomb",
		SilkSkill.PaleNails   => "Silk Boss Needle",
		_                     => throw new InvalidCheckException<SilkSkill>(skill),
	};

	/// <summary>
	/// Gets the data of the given <see cref="SilkSkill"/>
	/// </summary>
	private static ToolItemsData.Data? GetSilkSkillData(this PlayerData data, SilkSkill skill)
	{
		var id = GetSilkSkillId(skill);

		return data.Tools.GetData(id);
	}

	/// <summary>
	/// Checks if the given <see cref="SilkSkill"/> was obtained
	/// </summary>
	public static bool HasSilkSkill(this PlayerData data, SilkSkill skill)
	{
		var skillData = data.GetSilkSkillData(skill);

		if (!skillData.HasValue)
			return false;

		return skillData.Value.IsUnlocked;
	}
}