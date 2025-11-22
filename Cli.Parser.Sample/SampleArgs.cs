using Cli.Args;

namespace Cli.Parser.Sample;

public class SampleArgs
{
    [CliBoolOptionAtribute("-v", "--val", Required = true)]
    public string Val { get; set; }
    
    [CliBoolOptionAtribute("-a", "--another", Required = true)]
    public string Another { get; set; }


    public override string ToString() => $"SampleArgs: {Val}, {Another}";
}