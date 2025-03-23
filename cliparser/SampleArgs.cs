using Cli.Args;

namespace CliParser;

public class SampleArgs
{
    [CliOption("-v", "--val", Required = true)]
    public string Val { get; set; }
}