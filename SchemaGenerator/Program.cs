using SchemaGenerator.Builders;

var builder = new GoalSetSchemaBuilder();

var schema = builder.Build();

File.WriteAllText("../schema.json", schema.ToJson());