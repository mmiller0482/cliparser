namespace Cli.Args;

[AttributeUsage(AttributeTargets.Property)]
public class CliKeywordOptionAttribute : CliOptionAttribute
{
    /// <summary>
    ///     Specifies whether the argument is required.
    ///     Default -- false.
    /// </summary>
    public bool Required { get; init; }
}