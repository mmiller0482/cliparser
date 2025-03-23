using Cli.Args;

namespace CliParser;

public class SampleArgs
{
    [CliOption("-v", "--val", Required = true)]
    public string Val { get; set; }
    
    [CliOption("-a", "--another", Required = true)]
    public string Another { get; set; }


    public override string ToString() => $"SampleArgs: {Val}, {Another}";
}