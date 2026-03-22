using System.Text.Json;
using TemplateParser.Core;

const string usage = "Usage: dotnet run -- parse <filePath> <templateId>";

if (args.Length < 3)
{
    Console.Error.WriteLine(usage);
    return;
}

var command = args[0];
var filePath = args[1];
var templateIdArg = args[2];

if (!string.Equals(command, "parse", StringComparison.OrdinalIgnoreCase))
{
    Console.Error.WriteLine("Unsupported command. Only 'parse' is currently available.");
    Console.Error.WriteLine(usage);
    return;
}

if (!File.Exists(filePath))
{
    Console.Error.WriteLine($"File not found: {filePath}");
    return;
}

if (!Guid.TryParse(templateIdArg, out var templateId))
{
    Console.Error.WriteLine($"Invalid templateId GUID: {templateIdArg}");
    return;
}

var parser = new DocxParser();

try
{
    var result = parser.ParseDocxTemplate(filePath, templateId);

    var json = JsonSerializer.Serialize(result, new JsonSerializerOptions
    {
        WriteIndented = true
    });

    // TODO (Week 5): Wire parser output into a practical CLI workflow.
    // Suggested improvements:
    // - [Week 5] Add optional output path flag (example: --out ./expected/result.json)
    // - [Week 5] Add better error messages with actionable next steps
    // - [Week 5] Add integration test-friendly output options
    // - [Week 6] Add structured logging for debugging parse failures
    // - Keep CLI focused on input/output flow only
    // Important: actual DOCX parsing should stay in TemplateParser.Core, not here.
    if (args.Length >= 4 && string.Equals(args[3], "--out", StringComparison.OrdinalIgnoreCase))
    {
        var outputPath = "output.json";
        File.WriteAllText(outputPath, json);
        Console.WriteLine($"Wrote parser output to {outputPath}");
    }
    else
    {
        Console.WriteLine(json);
    }
}
catch (NotImplementedException)
{
    // TODO (Week 6): Replace this temporary message with robust error handling.
    // Example: map known parser exceptions to user-friendly console output and exit codes.
    Console.Error.WriteLine("Parser implementation is intentionally incomplete in this starter repository.");
}
