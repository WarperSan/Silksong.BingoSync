using System.Text.Json;
using SchemaGenerator.Builders;

var builder = new GoalSetSchemaBuilder();

var schema = builder.Build();

var json = JsonSerializer.Serialize(schema,
	#pragma warning disable CA1869
	new JsonSerializerOptions
		#pragma warning restore CA1869
		{
			WriteIndented = true,
		});

File.WriteAllText("../schema.json", json);