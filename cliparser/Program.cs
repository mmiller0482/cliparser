using Cli.Parser;

namespace CliParser;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(HelpTextGenerator.Generate<SampleArgs>());
    }
}