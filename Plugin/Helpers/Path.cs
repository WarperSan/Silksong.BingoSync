using System.Reflection;

namespace Silksong.BingoSync.Helpers;

/// <summary>
/// Class helping with IO operations
/// </summary>
internal static class Path
{
	/// <summary>
	/// Gets the absolute path of folder containing the plugin
	/// </summary>
	public static string GetPluginFolder()
	{
		var location = Assembly.GetExecutingAssembly().Location;
		var directory = System.IO.Path.GetDirectoryName(location);

		return directory ?? string.Empty;
	}

	/// <summary>
	/// Gets the absolute path of the given relative path
	/// </summary>
	/// <remarks>
	/// The relative path will start from <see cref="GetPluginFolder"/>
	/// </remarks>
	public static string GetAbsolutePath(string relativePath)
	{
		var folder = GetPluginFolder();

		return System.IO.Path.Combine(folder, relativePath);
	}
}
