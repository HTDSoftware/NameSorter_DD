using Microsoft.Extensions.Logging;
using NameSorter_DD.Core.IO;
using NameSorter_DD.Core.Models;
using NameSorter_DD.Core.Services;
using NSubstitute;

namespace NameSorter_DD.Test;

public class NameProcessorTests
{
    [Fact]
    public void Process_ShouldWriteSortedOutput_WhenFileIsValid()
    {
        // Arrange
        var testInputPath = "test-input.txt";
        File.WriteAllLines(testInputPath, new[] { "John Smith", "Jane Doe" });

        var outputWriter = Substitute.For<IOutputWriter>();
        var logger = Substitute.For<ILogger<NameProcessor>>();

        var processor = new NameProcessor(new NameParser(), new NameSorter(), outputWriter, logger);

        // Act
        processor.Process(testInputPath);

        // Assert
        outputWriter.Received(1).WriteAsync(Arg.Is<IEnumerable<Person>>(people =>
            people.First().Surname == "Doe" &&
            people.Last().Surname == "Smith"
        ));

        // Cleanup
        File.Delete(testInputPath);
    }

    [Fact]
    public void Process_ShouldThrowFileNotFound_WhenFileMissing()
    {
        // Arrange
        var outputWriter = Substitute.For<IOutputWriter>();
        var logger = Substitute.For<ILogger<NameProcessor>>();
        var processor = new NameProcessor(new NameParser(), new NameSorter(), outputWriter, logger);

        var missingPath = "does-not-exist.txt";

        // Act & Assert
        var ex = Assert.Throws<FileNotFoundException>(() => processor.Process(missingPath));
        Assert.Contains("Input file does not exist.", ex.Message);
    }

    [Fact]
    public void Process_ShouldLogError_WhenParsingFails()
    {
        // Arrange
        var testInputPath = "test-bad-input.txt";
        File.WriteAllLines(testInputPath, new[] { "Too Many Names In This Line" });

        var outputWriter = Substitute.For<IOutputWriter>();
        var logger = Substitute.For<ILogger<NameProcessor>>();
        var processor = new NameProcessor(new NameParser(), new NameSorter(), outputWriter, logger);

        // Act & Assert
        var ex = Assert.Throws<FormatException>(() => processor.Process(testInputPath));
        logger.Received().Log(
            LogLevel.Error,
            Arg.Any<EventId>(),
            Arg.Any<object>(),
            ex,
            Arg.Any<Func<object, Exception?, string>>()
        );

        // Cleanup
        File.Delete(testInputPath);
    }
}
