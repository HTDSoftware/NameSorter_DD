using NameSorter_DD.Core.Models;

namespace NameSorter_DD.Core.Services;

/// <summary>
/// Sorts a list of Person objects by surname and then given names.
/// </summary>
public class NameSorter
{
    public List<Person> Sort(IEnumerable<Person> people)
    {
        if (!people.Any())
            throw new ArgumentException("Input cannot be empty.", nameof(people));

        return people
            .OrderBy(p => p.Surname)
            .ThenBy(p => string.Join(" ", p.GivenNames))
            .ToList();
    }
}