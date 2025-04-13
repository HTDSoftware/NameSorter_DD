namespace NameSorter_DD.Core.Models;

public class Person
{
    public List<string> GivenNames { get; }
    public string Surname { get; }

    public Person(List<string> givenNames, string surname)
    {
        if (string.IsNullOrWhiteSpace(surname))
        {
            throw new ArgumentException("Surname cannot be null or empty.", nameof(surname));
        }

        if (givenNames == null)
        {
            throw new ArgumentException("Given names cannot be null.", nameof(givenNames));
        }

        if (givenNames.Count < 1)
        {
            throw new ArgumentException("Must be at least one given name.", nameof(givenNames));
        }

        GivenNames = givenNames;
        Surname = surname;
    }

    public override string ToString()
    {
        return $"{string.Join(" ", GivenNames)} {Surname}";
    }
}
