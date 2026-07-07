using SchemaGenerator.Builders;
using SchemaGenerator.Helpers;
using Silksong.BingoSync.Data;

var builder = new GoalSetSchemaBuilder()
              .AddCondition(
	              new ConditionSchemaBuilder()
		              .Action("has_completed_ending")
		              .RequiredParameter(
			              "ending",
			              ParameterHelper.CreateFromEnum<Ending>()
		              )
              )
              .AddCondition(
	              new ConditionSchemaBuilder()
		              .Action("has_killed_boss")
		              .RequiredParameter(
			              "boss",
			              ParameterHelper.CreateFromEnum<Boss>()
		              )
              );

var schema = builder.Build();

File.WriteAllText("../schema.json", schema.ToJson());