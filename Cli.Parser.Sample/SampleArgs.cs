using Cli.Args;

namespace Cli.Parser.Sample;

public class SampleArgs
{
    [CliBoolOption("-v", "--val", Required = true)]
    public string Val { get; set; }
    
    [CliBoolOption("-a", "--another", Required = true)]
    public string Another { get; set; }


    public override string ToString() => $"SampleArgs: {Val}, {Another}";
}