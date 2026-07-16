using System.Diagnostics.CodeAnalysis;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Exceptions;

namespace Silksong.BingoSync.Extensions;

/// <summary>
/// Extension methods of <see cref="PlayerData"/> concerning <see cref="Quill"/>
/// </summary>
[SuppressMessage("ReSharper", "ConvertToExtensionBlock")]
public static partial class PlayerDataExtensions
{
	/// <summary>
	/// Gets the state for the given <see cref="Needle"/>
	/// </summary>
	private static int GetQuillState(Quill quill)
	{
		return quill switch
		{
			Quill.White  => 1,
			Quill.Red    => 2,
			Quill.Purple => 3,
			_            => throw new InvalidCheckException<Quill>(quill),
		};
	}

	/// <summary>
	/// Checks if the given <see cref="Quill"/> was obtained
	/// </summary>
	public static bool HasObtainedQuill(this PlayerData data, Quill quill)
	{
		if (!data.hasQuill)
			return false;

		return data.QuillState == GetQuillState(quill);
	}
}
