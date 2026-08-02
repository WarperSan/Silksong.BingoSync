using BingoAPI.Conditions.Attributes;
using BingoAPI.Conditions.Interfaces;

namespace Silksong.BingoSync.Conditions;

/// <summary>
/// Checks nothing
/// </summary>
/// <remarks>
/// This condition is used as a placeholder to allow not-implemented goals to still work
/// </remarks>
[Condition("manual")]
internal sealed class ManualCondition : ICondition
{
	/// <inheritdoc />
	public bool IsMet() => false;
}
