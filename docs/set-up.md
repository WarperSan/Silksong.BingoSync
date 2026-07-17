# How to Set up?

To work on this project, you will need to clone the following repositories:
- [Silksong.BingoSync](https://github.com/WarperSan/Silksong.BingoSync)
- [BingoAPI](https://github.com/WarperSan/BingoAPI)

Then, you will want to copy `env.props.template` to `env.props`. This allows to set environment variables for things like library and copying.

Depending on your setup, the steps will be a little bit different. You can either set `<Profile>` and `<ModManagerFolder>` if you use a mod manager like r2modman or Gale, or directly set `<PluginsFolder>` to the `plugins/` folder.

You will also need to set `<UseLocalBingoAPI>` to `true`, and set `<LocalBingoAPI>` to the path to your local BingoAPI's `.csproj` file.

This should make the project all set-up. To test the mod, you will need to build it. The project will automatically copy the mod and `BingoAPI` to the correct destination.

