namespace Cli.Args;

[AttributeUsage(AttributeTargets.Property)]
public class CliBoolOptionAttribute : CliOptionAttribute
{
    public CliBoolOptionAttribute(string shortName, string longName) : base(shortName, longName)
    {
    }
}