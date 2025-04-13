using NameSorter_DD.Core.Services;

namespace NameSorter_DD.Test;

public class NameParserTests
{
    [Theory]
    [InlineData("John Smith", new[] { "John" }, "Smith")]
    [InlineData("Alice Mary Brown", new[] { "Alice", "Mary" }, "Brown")]
    public void Parse_ShouldReturnCorrectPerson(string input, string[] expectedGivenNames, string expectedSurname)
    {
        var parser = new NameParser();
        var person = parser.Parse(input);

        Assert.Equal(expectedSurname, person.Surname);
        Assert.Equal(expectedGivenNames, person.GivenNames);
    }

    [Theory]
    [InlineData("", typeof(ArgumentException))]
    [InlineData(" ", typeof(ArgumentException))]
    [InlineData("One Two Three Four Five", typeof(FormatException))]
    public void Parse_ShouldThrowSpecificException_WhenInputInvalid(string input, Type expectedException)
    {
        var parser = new NameParser();

        // Assert that the specific exception is thrown
        var exception = Assert.Throws(expectedException, () => parser.Parse(input));
        Assert.NotNull(exception);   
    }
}
