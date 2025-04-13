using NameSorter_DD.Core.Models;
using NameSorter_DD.Core.Services;

namespace NameSorter_DD.Test;

public class NameSorterTests
{
    [Fact]
    public void Sort_ShouldOrderBySurnameThenGivenNames()
    {
        // Arrange
        var unsorted = new List<Person>
        {
            new Person(new List<string>{ "John" }, "Smith"),
            new Person(new List < string > { "Charlie" }, "Brown"),
            new Person(new List < string > { "Adam" }, "Smith"),
            new Person(new List < string > { "Anna" }, "Brown")
        };

        var sorter = new NameSorter();

        // Act
        var sorted = sorter.Sort(unsorted);

        // Assert
        var expected = new[]
        {
            "Anna Brown",
            "Charlie Brown",
            "Adam Smith",
            "John Smith"
        };

        var actual = sorted.Select(p => p.ToString()).ToArray();
        Assert.Equal(expected, actual);
    }

    // We are using this because we have to use memberdata to test complex types
    // Like objects, class instances etc ...
    public static IEnumerable<object[]> InvalidPeopleData =>
        new List<object[]>
        {
            new object[] { new List<Person>(), typeof(ArgumentException) }
        };

    [Theory]
    [MemberData(nameof(InvalidPeopleData))]
    public void Sort_ShouldThrow_WhenInputIsNullOrEmpty(List<Person> people, Type expectedException)
    {
        // Arrange
        var sorter = new NameSorter();

        // Act & Assert
        var ex = Record.Exception(() => sorter.Sort(people));
        Assert.NotNull(ex);
        Assert.IsType(expectedException, ex);
    }

    [Fact]
    public void Sort_ShouldHandleSingleElementList()
    {
        // Arrange
        var single = new List<Person>
        {
            new Person(new List < string > { "Jane" }, "Doe")
        };

        var sorter = new NameSorter();

        // Act
        var sorted = sorter.Sort(single);

        // Assert
        Assert.Single(sorted);
        Assert.Equal("Jane Doe", sorted.First().ToString());
    }
}


