# How to Add a new Condition?

## Defining the condition

Firstly, you will need to define what the condition will do. It is recommended to first come up with a description that
is human-readable.

Secondly, you will need to find the appropriate action for your description. The action is the keyword used to identify
the condition. Actions must be unique between all the conditions.

> [!NOTE]
> This mod uses a [glossary](glossary.md) for actions, which puts a definition on certain words. This is to make the
> whole mod uniform.

Thirdly, you will need to define the parameters for the condition. Theses can vary between conditions, but they are
often simply the targetted subject.

> [!NOTE]
> Not all parameters have to be required, but at least one required parameter is recommended.

If you have followed all the steps, you will end up with something like this:

Action: `has_completed_ending`

Parameters:
- `ending`: Name of the ending to complete (Required)

Description: Checks if the player has completed a given ending.

## Creating the condition

> [!IMPORTANT]
> It is recommended to name the condition the same as the action itself, with the `Condition` suffix. For example,
`has_obtained_map` will use the class `HasObtainedMapCondition`.

Once you have your definition, you will need to create a class for it. Conditions are stored inside
`Plugin/Conditions/`.

You can use the following template:

```csharp
/// <summary>
/// TODO: Describe what the condition checks
/// </summary>
[Condition("your_action_here")]
internal sealed class MyNewCondition : ICondition
{
	/// <inheritdoc />
	public bool IsMet() => throw new NotImplementedException();
}
```

Firstly, you will need to add a summary to your class. This helps understanding what the condition does.

Secondly, you will need to put your action. You simply need to replace `your_action_here` by the action you want to use.

Thirdly, you will need to add your parameters. Parameters are provided using properties and the atttribute `[JsonProperty]`. For example, if the condition requires the parameter `ending`, the condition will have this:
```csharp
// Name of the property inside the "params" object
[JsonProperty("ending")]
// Add this if the property is required
[JsonRequired]
// Short description of the parameter
[Description("Name of the ending to complete")]
public required Ending Ending { get; init; }
```

## What if my Condition requires a new Type?

> [!NOTE]
> Reasoning about the data splitting can be found [here](data-splitting.md).

It is possible that your condition will require a new type to be added. Adding a new type is fairly easy.

Firstly, you will need to create a new file in `Plugin/Data/`. The name should be the same as the name of the data (`Crest.cs` for crests, `Boss.cs` for bosses, etc).

Secondly, you will need to create an enum for your data, where each value is potential value of your data.

The enum values must be in **Pascal case**, while the data values (string set in `EnumMember.Value`) is in **Snake case**.

> [!IMPORTANT]
> Since parameters are loading via JSON, it is important that the enum has the attribute `[JsonConverter(typeof(StringEnumConverter))]`, and each value has the attribute `[EnumMember]`.

## Checking a condition

Once you have your condition set up, the most important part is to link the condition to the game's data. It is preferred to create or use extension methods of `PlayerData`. This allows to define at a single place the check, and allow any future potential condition to reuse it. On top of that, the method `IsMet()` will likely be only `IsMet() => PlayerData.instance.MyMethod()`.

All extension methods about one subject are stored in the same file. Any method concerning mementos (`HasObtainedMemento`, `HasDepositedMemento`) are stored inside `PlayerData.Mementos`.

To add a new extension method for an existing subject, you can simply modify the appropriate file in `Plugin/Extensions/`.

To add a new extension method for a new subject, you can copy any existing file in `Plugin/Extensions/`, and change the file name to `PlayerData.[Subject]s`. For example, if the method is checking if a wish is completed, the name of the class would be `PlayerData.Wishes`.