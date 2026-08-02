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

[ConditionFactory("has_found_flea_count")]
internal sealed class HasFoundFleaCountCondition
	: ParameterizedConditionFactory<HasFoundFleaCountCondition.Parameters>
{
	public sealed class Parameters
	{
		[JsonProperty("amount")]
		[JsonRequired]
		[Description("Minimum number of conditions that must be met")]
		public uint Amount { get; init; }

		[JsonProperty("area")]
		[Description("Area of the fleas to keep")]
		public Area? Area { get; init; }

		[JsonProperty("include_unique")]
		[DefaultValue(true)]
		[Description("Defines if the unique fleas must be included")]
		public bool? IncludeUnique { get; init; }
	}

	/// <summary>
	/// Creates a <see cref="ICondition"/> for the given <see cref="Flea"/>
	/// </summary>
	private static ICondition CreateCondition(Flea flea) =>
		new HasFoundFleaCondition { Flea = flea };

	/// <summary>
	/// Gets all the <see cref="Flea"/> that match the given <see cref="Parameters"/>
	/// </summary>
	private static IEnumerable<Flea> GetFleas(Parameters parameters)
	{
		foreach (Flea flea in Enum.GetValues(typeof(Flea)))
		{
			if (parameters.Area.HasValue)
			{
				var fleaArea = flea.GetArea();

				if (parameters.Area.Value != fleaArea)
					continue;
			}

			if (parameters.IncludeUnique.HasValue)
			{
				var isUnique = flea.IsUnique();

				if (isUnique && !parameters.IncludeUnique.Value)
					continue;
			}

			yield return flea;
		}
	}

	/// <inheritdoc />
	protected override ICondition Generate(Parameters parameters)
	{
		var conditions = GetFleas(parameters).Select(CreateCondition).ToList();

		return new SomeCondition { Amount = parameters.Amount, Conditions = conditions };
	}
}
