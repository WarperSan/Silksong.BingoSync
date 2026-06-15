namespace Silksong.BingoSync.UI;

/// <summary>
/// Class responsible to manage all UI
/// </summary>
internal static class UIManager
{
	public static readonly Lazy<BingoBoard?> Board = new(() => BingoBoard.Create(null));
}