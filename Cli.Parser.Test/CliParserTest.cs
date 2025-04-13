using Cli.Args;
using Cli.Parser;
namespace Cli.Parser.Test;

using Xunit;

public class CliParserTest
{
    [Fact]
    public void Parse_Empty_EmptyClass()
    {
        // This base case should never happen in practice, but putting here for corner case testing.
        // Arrange
        string[] cliArgs = [];

        // Act
        SampleEmptyArgs args = new CliParser<SampleEmptyArgs>().Parse(cliArgs);
        
        // Assert
        Assert.NotNull(args);
    }

    [Fact]
    public void Parse_Empty_PopulatedClass_ThrowsException()
    {
        // Arrange
        string[] cliArgs = [];

        // Act & Assert
        Assert.Throws<CliParserException>(() => new CliParser<SampleArgs>().Parse(cliArgs));
    }
    
    [Fact]
    public void Parse_ShouldSetProperties_WhenValidArgsArePassed()
    {
        // Arrange
        string[] args = [ "-n", "Alice", "--age", "30" ];

        // Act
        var result = new CliParser<SampleArgs>().Parse(args);

        // Assert
        Assert.Equal("Alice", result.Name);
        Assert.Equal(30, result.Age);
    }
    
    [Fact]
    public void Parse_Throws_WhenLastArgumentIsNull()
    {
        // Arrange
        string[] args = [ "-n", "Alice", "--age" ];

        // Act & Assert
        Assert.Throws<CliParserException>(() => new CliParser<SampleArgs>().Parse(args));
    }
    
    private class SampleEmptyArgs
    {
    }
    
    private class SampleArgs
    {
        [CliOption("-n", "--name", Required = true)]
        public string Name { get; set; }
    
        [CliOption("-a", "--age")]
        public int Age { get; set; }
    }
}
