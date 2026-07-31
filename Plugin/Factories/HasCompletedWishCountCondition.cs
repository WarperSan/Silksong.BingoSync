using System.ComponentModel;
using BingoAPI.Conditions.Attributes;
using BingoAPI.Conditions.BuiltIn;
using BingoAPI.Conditions.Factories;
using BingoAPI.Conditions.Interfaces;
using Newtonsoft.Json;
using Silksong.BingoSync.Conditions;
using Silksong.BingoSync.Data;
using Silksong.BingoSync.Extensions;

namespace Silksong.BingoSync.Factories;

[ConditionFactory("has_completed_wish_count")]
internal sealed class HasCompletedWishCountCondition
	: ParameterizedConditionFactory<HasCompletedWishCountCondition.Parameters>
{
	public sealed class Parameters
	{
		[JsonProperty("amount")]
		[JsonRequired]
		[Description("Minimum number of conditions that must be met")]
		public uint Amount { get; init; }

		[JsonProperty("type")]
		[Description("Type of the wish to keep")]
		public WishType? Type { get; init; }
	}

	/// <summary>
	/// Creates a <see cref="ICondition"/> for the given <see cref="Wish"/>
	/// </summary>
	private static ICondition CreateCondition(Wish wish) =>
		new HasCompletedWishCondition { Wish = wish };

	/// <summary>
	/// Gets all the <see cref="Wish"/> that match the given <see cref="Parameters"/>
	/// </summary>
	private static IEnumerable<Wish> GetWishes(Parameters parameters)
	{
		foreach (Wish wish in Enum.GetValues(typeof(Wish)))
		{
			if (parameters.Type.HasValue)
			{
				var wishType = wish.GetWishType();

				if (parameters.Type.Value != wishType)
					continue;
			}

			yield return wish;
		}
	}

	/// <inheritdoc />
	protected override ICondition Generate(Parameters parameters)
	{
		var conditions = GetWishes(parameters).Select(CreateCondition).ToList();

		return new SomeCondition { Amount = parameters.Amount, Conditions = conditions };
	}
}
