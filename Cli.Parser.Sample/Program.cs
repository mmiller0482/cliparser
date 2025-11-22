namespace Cli.Parser.Sample;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(HelpTextGenerator.Generate<SampleArgs>());
        
        SampleArgs myArgs = Parser.Parse<SampleArgs>(["-v", "Hello world", "-a", "someAnother"]);
        
        Console.WriteLine("GOT: ");
        Console.WriteLine(myArgs);
    }
}