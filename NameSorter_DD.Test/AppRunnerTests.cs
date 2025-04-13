using NameSorter_DD.Console;

namespace NameSorter_DD.Test;

public class AppRunnerTests
{
    [Fact]
    public void Run_ShouldSortNamesAndWriteToFile()
    {
        // Arrange
        var inputFile = "input-e2e.txt";
        var outputFile = "sorted-names-list.txt";
        File.WriteAllLines(inputFile, new[]
        {
            "John Smith",
            "Charlie Brown",
            "Anna Brown"
        });

        var app = new AppRunner();

        // Redirect console output
        using var sw = new StringWriter();
        System.Console.SetOut(sw);

        // Act
        var exitCode = app.Run(new[] { inputFile });

        // Assert
        Assert.Equal(0, exitCode);
        Assert.True(File.Exists(outputFile));

        var output = File.ReadAllLines(outputFile);
        Assert.Equal(new[]
        {
            "Anna Brown",
            "Charlie Brown",
            "John Smith"
        }, output);

        // Cleanup
        File.Delete(inputFile);
        File.Delete(outputFile);
    }

    [Fact]
    public void Run_ShouldReturnErrorCode_WhenFileMissing()
    {
        // Arrange
        var app = new AppRunner();

        using var sw = new StringWriter();
        System.Console.SetOut(sw);

        // Act
        // Act
        var exitCode = app.Run(new[] { "nonexistent.txt" });
 
        // Assert
        Assert.Equal(1, exitCode);
        Assert.Contains("Input file does not exist.", sw.ToString());
    }
}
