using NameSorter_DD.Core.Models;

namespace NameSorter_DD.Core.Services;

/// <summary>
/// Parses raw input lines into Person objects.
/// </summary>
public class NameParser
{
    public Person Parse(string rawLine)
    {
        // Check the input for null or empty strings
        if (string.IsNullOrWhiteSpace(rawLine))
            throw new ArgumentException("Input cannot be empty.");

        // Split the line into parts based on whitespace
        var parts = rawLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Check if the parts contain only valid characters
        if (parts.Length < 1 || parts.Length > 4)
            throw new FormatException("Each name must contain a surname and up to three given names.");

        // Surname is the last part
        string surname = parts.Last();

        // Given names are all parts except the last one
        List<string> givenNames = parts.Take(parts.Length - 1).ToList();

        return new Person(givenNames, surname);

    }
}
