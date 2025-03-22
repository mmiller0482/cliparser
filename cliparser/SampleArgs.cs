using Cli.Args;

namespace CliParser;

public class SampleArgs
{
    [CliOption("-v", "--val", Required = true)]
    private string Val { get; set; }
}