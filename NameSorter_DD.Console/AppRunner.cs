using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NameSorter_DD.Core.IO;
using NameSorter_DD.Core.Services;

namespace NameSorter_DD.Console;

// AppRunner has been created so we are
// able to perform End2End Automated Tests
public class AppRunner
{
    public int Run(string[] args)
    {
        if (args.Length < 1)
        {
            System.Console.WriteLine("Usage: namesorter_dd ./<filename>");
            return 1;
        }

        var inputFile = args[0];
        var outputFile = "sorted-names-list.txt";

        // Create and configure the DI container including the services
        var services = new ServiceCollection()
            
            // Logging Service
            .AddLogging(b => b.SetMinimumLevel(LogLevel.Debug))

            // File and Console Output Writers
            .AddSingleton<IOutputWriter>(new CompositeOutputWriter(new IOutputWriter[]
            {
                new ConsoleOutputWriter(),
                new FileOutputWriter(outputFile)
            }))

            // Name Parser
            .AddSingleton<NameParser>()

            // Name Sorter
            .AddSingleton<NameSorter>()

            // Name Processor which incorporates the above
            .AddSingleton<NameProcessor>()

            .BuildServiceProvider();

        try
        {
            // Resolve and use NameProcessor directly
            var processor = services.GetRequiredService<NameProcessor>();
            processor.Process(inputFile);
            return 0;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Fatal error: {ex.Message}");
            return 1;
        }
    }
}
