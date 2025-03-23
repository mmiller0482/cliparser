using Cli.Parser;

namespace CliParser;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(HelpTextGenerator.Generate<SampleArgs>());
        
        SampleArgs myArgs = Parser.Parse<SampleArgs>(["-v", "Hello world"]);
        
        Console.WriteLine("GOT: ");
        Console.WriteLine(myArgs);
    }
}