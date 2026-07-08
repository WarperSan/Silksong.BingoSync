using System.Reflection;
using BingoAPI.Conditions;
using NJsonSchema;
using SchemaGenerator;
using SchemaGenerator.Helpers;
using Silksong.BingoSync;

var output = args.Length > 0 ? args[0] : "../schema.json";

var conditionsSchema = new JsonSchema();

var context = new SchemaContext();
context.AddSchema<ICondition>(conditionsSchema);

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

		if (!ConditionHelper.TryCreateFromType(type, context, out var builder))
			continue;

		conditionsSchema.OneOf.Add(builder.Build());
	}
}

var goalSchema = new JsonSchema
{
	Type = JsonObjectType.Object,
	Properties =
	{
		["name"] = new JsonSchemaProperty
		{
			Type = JsonObjectType.String,
			Description = "Text to display for this goal",
			IsRequired = true,
		},
		["condition"] = new JsonSchemaProperty
		{
			Type = JsonObjectType.Object,
			Description = "Condition to meet to complete this goal",
			Reference = conditionsSchema,
			IsRequired = true,
		},
	},
};

var goalSetSchema = new JsonSchema
{
	Title = "Goals",
	Description = "Set of goals available",
	Type = JsonObjectType.Object,
	Properties =
	{
		["name"] = new JsonSchemaProperty
		{
			Type = JsonObjectType.String,
			Description = "Name of the goal",
		},
		["description"] = new JsonSchemaProperty
		{
			Type = JsonObjectType.String,
			Description = "Description of the set",
		},
		["goals"] = new JsonSchemaProperty
		{
			Type = JsonObjectType.Array,
			Description = "List of goals added by this set",
			Item = goalSchema,
			MinItems = 1,
			UniqueItems = true,
			IsRequired = true,
		},
	},
	Definitions =
	{
		["conditions"] = conditionsSchema,
	},
};

var directory = Path.GetDirectoryName(output);

if (directory != null)
	Directory.CreateDirectory(directory);

File.WriteAllText(output, goalSetSchema.ToJson());