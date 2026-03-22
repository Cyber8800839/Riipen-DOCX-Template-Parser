using TemplateParser.Core;

namespace TemplateParser.Tests;

public sealed class ParserTests
{
    [Fact]
    public void ParseDocxTemplate_ThrowsNotImplemented()
    {
        // TODO (Week 1-6): Replace this placeholder with real tests aligned to weekly goals.
        // Suggested first tests:
        // - [Week 1] paragraph extraction smoke tests
        // - [Week 2] heading-based hierarchy tests
        // - [Week 3] table/list/image node detection tests
        // - [Week 4] formatting heuristics tests for missing heading styles
        // - [Week 5] integration tests that run parser through the CLI flow
        // - [Week 6] refactor tests into readable groups and helper builders
        //
        // You may create test helpers/builders to reduce repetition (recommended by Week 6).
        var parser = new DocxParser();

        Assert.Throws<NotImplementedException>(() =>
            parser.ParseDocxTemplate("sample.docx", Guid.NewGuid()));
    }
}
