# Data Splitting

This mod uses custom data to resolve parameters and conditions. This is meant to lift some of the weight of the goals, making them easier to use and write.

## Problem

While designing this mod, [Hollow Knight Bingo](https://github.com/pedroteosousa/HollowKnight.BingoSync) was used as a reference. In the mod, goals need to know and correctly use raw data.

For example, to check if `False Champion` was killed, the goal needs to check the variable itself:
```json
{
    "type": "Bool",
    "variableName": "falseKnightDreamDefeated",
    "expectedValue": true
}
```

This allows a lot of flexibility. Since the goals define what and how they check, the mod only needs to apply these rules.

However, this implementation makes every implementation detail bleed into the goals. Each goal need to know what variable to check. Internal variable names can be difficult to understand, which makes the overall goal harder to make and maintain.

## Solution

To solve this dependency, this mod uses intermediate data and special conditions.

Using the same example as the one preceding, the condition ends up being this:
```json
{
    "action": "has_killed_boss",
    "params": {
        "boss": "failed_champion"
    }
}
```

They allow to move the responsibility from the players to the developers.

Instead of knowing that `Failed Champion` is actually named `False Knight Dream`, players can simply use the real name. The developers will then need to link the value to the internal name. 

### Issues

Although this solves the issue with variables, this method brings other issues entirely.

For starter, a data structure (usually an enum) needs to be created and populate for each object type. For some, this isn't that difficult, being limited to a handful of entries. However, when talking about heavy objects (such as bosses, tools and wishes), the enumeration can easily have 50 entries.

A second issue is the lack of flexibility. If new content was added (from DLCs or mods), this solution cannot easily add them. Each new entry needs to be linked manually, which makes the overall development slower.