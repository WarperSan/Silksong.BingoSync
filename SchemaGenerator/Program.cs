using System.Reflection;
using SchemaGenerator.Builders;
using SchemaGenerator.Helpers;
using Silksong.BingoSync;

var builder = new GoalSetSchemaBuilder();

foreach (var assembly in AssemblyHelper.GetReferencedAssemblies(typeof(Plugin)))
{
	IEnumerable<Type?> types;

	try
	{
		types = assembly.GetTypes();
	}
	catch (ReflectionTypeLoadException ex)
	{
		types = ex.Types;
	}

	foreach (var type in types)
	{
		if (type == null)
			continue;

		if (!ConditionHelper.TryCreateFromType(type, out var conditionBuilder))
			continue;

		builder.AddCondition(conditionBuilder);
	}
}

var schema = builder.Build();

File.WriteAllText("../schema.json", schema.ToJson());