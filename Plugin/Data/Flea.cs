using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Silksong.BingoSync.Data;

/// <summary>
/// List of every flea the player can free
/// </summary>
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
[JsonConverter(typeof(StringEnumConverter))]
public enum Flea { }
