using NameSorter_DD.Core.Models;

namespace NameSorter_DD.Core.IO;

/// <summary>
/// Writes sorted names to a specified file.
/// </summary>
public class FileOutputWriter : IOutputWriter
{
    private readonly string _filePath;

    public FileOutputWriter(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

        if (File.Exists(filePath))
            File.Delete(filePath);

        _filePath = filePath;
    }

    public async Task WriteAsync(IEnumerable<Person> people)
    {
        if (people == null)
            throw new ArgumentNullException(nameof(people), "People cannot be null.");

        if (!people.Any())
            throw new ArgumentException("People cannot be empty.", nameof(people));

        var lines = people.Select(p => p.ToString());
        await File.WriteAllLinesAsync(_filePath, lines);
    }
}
