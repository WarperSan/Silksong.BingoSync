using BepInEx;

namespace Silksong.BingoSync;

[BepInAutoPlugin(id: "dev.warpersan.silksong.bingosync")]
public partial class Plugin : BaseUnityPlugin
{
	private void Awake()
	{
		// Put your initialization logic here
		Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
	}
}