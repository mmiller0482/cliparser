namespace Cli.Args;

[AttributeUsage(AttributeTargets.Property)]
public class CliOptionAttribute : Attribute
{
    public string ShortName { get; }
    public string LongName { get; }
    public bool Required { get; set; }

    public CliOptionAttribute(string shortName, string longName)
    {
        ShortName = shortName;
        LongName = longName;
    }
}