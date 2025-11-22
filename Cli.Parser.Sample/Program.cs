namespace Cli.Parser.Sample;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(HelpTextGenerator.Generate<SampleArgs>());

        var parser = new CliParser<SampleArgs>();
        SampleArgs myArgs = parser.Parse(["-v", "Hello world", "-a", "someAnother"]);
        
        Console.WriteLine("GOT: ");
        Console.WriteLine(myArgs);
    }
}