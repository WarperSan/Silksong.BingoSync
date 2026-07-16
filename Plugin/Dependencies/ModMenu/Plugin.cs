using Silksong.BingoSync.Configurations;
using Silksong.ModMenu.Plugin;
using Silksong.ModMenu.Screens;

namespace Silksong.BingoSync;

public partial class Plugin : IModMenuCustomMenu
{
	/// <inheritdoc />
	public AbstractMenuScreen BuildCustomMenu() => ConfigMenu.Create(Configuration.SafeInstance);
}
