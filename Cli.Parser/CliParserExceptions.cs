namespace Cli.Parser;

public class CliParserException(string? message) : Exception(message);

public class CliParserMissingValueException(string? message) : Exception(message);