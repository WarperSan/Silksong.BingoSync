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
	/// Checks if the given <see cref="Quill"/> was obtained
	/// </summary>
	public static bool HasQuill(this PlayerData data, Quill quill)
	{
		if (!data.hasQuill)
			return false;

		return quill switch
		{
			Quill.White  => data.QuillState == 1,
			Quill.Red    => data.QuillState == 2,
			Quill.Purple => data.QuillState == 3,
			_            => throw new InvalidCheckException<Quill>(quill),
		};
	}
}