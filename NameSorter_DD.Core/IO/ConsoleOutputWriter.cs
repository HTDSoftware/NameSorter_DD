using NameSorter_DD.Core.Models;

namespace NameSorter_DD.Core.IO;

/// <summary>
/// Writes sorted names to the console.
/// </summary>
public class ConsoleOutputWriter : IOutputWriter
{
    public Task WriteAsync(IEnumerable<Person> people)
    {
        if (people == null)
            throw new ArgumentNullException(nameof(people), "People cannot be null.");

        if (!people.Any())
            throw new ArgumentException("People cannot be empty.", nameof(people));

        // Write each person's name to the console
        foreach (var person in people)
        {
            Console.WriteLine(person.ToString());
        }

        return Task.CompletedTask;
    }
}