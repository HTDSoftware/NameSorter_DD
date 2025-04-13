// IOutputWriter.cs
using NameSorter_DD.Core.Models;

namespace NameSorter_DD.Core.IO;

// This interface allows for different implementations, such as
// writing to a text file, Console or any other format.
// The WriteAsync method takes a collection of Person objects
// and a file path as parameters. The implementation should
// handle the actual writing of the data. The method is
// asynchronous to allow for non-blocking operations, which is
// important for I/O-bound tasks.

public interface IOutputWriter
{
    Task WriteAsync(IEnumerable<Person> people);
}