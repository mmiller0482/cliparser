namespace Cli.Args;


public class CliBoolOptionAtribute : Attribute
{
    // TODO: What are we going to do about 'subcommands' ? Future issue.
    /// <summary>
    /// The shorthand specifier for a keyword argument.
    /// Example. -h for help.
    /// </summary>
    public string ShortName { get; }
    
    /// <summary>
    /// The longhand specifier for a keyword argument.
    /// Example. --help for help
    /// </summary>
    public string LongName { get; }
    
    /// <summary>
    /// Specifies whether the argument is required.
    /// Default -- false.
    /// </summary>
    public bool Required { get; set; }

    public CliBoolOptionAtribute(string shortName, string longName)
    {
        ShortName = shortName;
        LongName = longName;
    }
}