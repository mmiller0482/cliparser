namespace Cli.Args;


public class CliBoolOptionAttribute : CliOptionAttribute
{
    public CliBoolOptionAttribute(string shortName, string longName) : base(shortName, longName)
    {
    }
}