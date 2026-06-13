using BepInEx;
using Silksong.BingoSync.Helpers;

namespace Silksong.BingoSync;

[BepInAutoPlugin(id: "dev.warpersan.silksong.bingosync")]
public partial class Plugin : BaseUnityPlugin
{
	private void Awake()
	{
		Patch.ApplyAll();
		Log.Info($"Plugin {Name} ({Id}) has loaded!");
	}
}