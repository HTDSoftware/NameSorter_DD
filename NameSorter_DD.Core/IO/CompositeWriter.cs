using NameSorter_DD.Core.Models;

namespace NameSorter_DD.Core.IO;

/// <summary>
/// Allows writing to multiple output writers simultaneously (e.g., file + console).
/// </summary>
public class CompositeOutputWriter : IOutputWriter
{
    private readonly IEnumerable<IOutputWriter> _writers;

    public CompositeOutputWriter(IEnumerable<IOutputWriter> writers)
    {
        _writers = writers;
    }

    public Task WriteAsync(IEnumerable<Person> people)
    {
        foreach (var writer in _writers)
        {
            writer.WriteAsync(people);
        }

        return Task.CompletedTask;
    }
}
