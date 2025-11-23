using Cli.Args;

namespace Cli.Parser.Sample;

public class SampleArgs
{
    [CliKeywordOption(ShortName = "-v", LongName = "--val", Required = true)]
    public string Val { get; set; }

    [CliKeywordOption(ShortName = "-a", LongName = "--another", Required = true)]
    public string Another { get; set; }


    public override string ToString()
    {
        return $"SampleArgs: {Val}, {Another}";
    }
}