using Microsoft.Extensions.Logging;
using NameSorter_DD.Core.IO;
using NameSorter_DD.Core.Models;

namespace NameSorter_DD.Core.Services;

/// <summary>
/// Coordinates parsing, sorting, and writing of names.
/// </summary>
public class NameProcessor
{
    private readonly NameParser _parser;
    private readonly NameSorter _sorter;
    private readonly IOutputWriter _outputWriter;
    private readonly ILogger<NameProcessor> _logger;

    public NameProcessor(NameParser parser, NameSorter sorter, IOutputWriter outputWriter, ILogger<NameProcessor> logger)
    {
        _parser = parser;
        _sorter = sorter;
        _outputWriter = outputWriter;
        _logger = logger;
    }

    public void Process(string inputFilePath)
    {
        try
        {
            // Validate the Input file
            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException("Input file does not exist.", inputFilePath);
            }

            _logger.LogInformation("Reading input from {InputFilePath}", inputFilePath);

            // Read all lines from the input file, parse them into Person objects,
            // sort them, and write the sorted list to the output.
            var rawLines = File.ReadAllLines(inputFilePath);

            // Check if the file is empty
            if (rawLines.Length == 0)
            {
                throw new ArgumentException("Input file is empty.", nameof(inputFilePath));
            }

            // Initialise the People List as Ienumerable
            var people = new List<Person>();

            // Loop through each line and parse the line into
            // a Person object and add it to the People List
            foreach (string line in rawLines)
            {
                var person = _parser.Parse(line);
                people.Add(new Person(person.GivenNames, person.Surname));
            }

            var sortedPeople = _sorter.Sort(people);

            _logger.LogInformation("Read, Parsed and Sorted lines from {InputFilePath}", inputFilePath);

            // This will be the CompositeOutputWriter which will write to both Console and File
            _outputWriter.WriteAsync(sortedPeople);

            _logger.LogInformation("Processing completed. {Count} names sorted.", sortedPeople.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing names.");
            throw;
        }
    }
}
