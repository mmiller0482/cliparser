using System.Reflection;
using Cli.Args;

namespace Cli.Parser;

/// <summary>
///     Parser object for transforming a string[] (command line args) into a class T representing the arguments.
/// </summary>
/// <typeparam name="T"></typeparam>
public class CliParser<T> where T : new()
{
    private readonly Dictionary<string, PropertyInfo> _argMap = ExtractArgMap();
    private readonly T _argModel = new();

    public T Parse(string[] args)
    {
        if (_argMap.Count == 0)
            // Log a message about no options; return empty Arguments class.
            return _argModel;
        if (args.Length == 0) throw new CliParserException($"Got invalid arguments for type {typeof(T).Name}");

        // Iterate through args
        for (var i = 0; i < args.Length; i++)
        {
            if (!_argMap.TryGetValue(args[i], out var prop)) continue;
            if (i + 1 >= args.Length) throw new CliParserException("Expected keyword arg, but got none at end");
            var value = args[i + 1];
            prop.SetValue(_argModel, Convert.ChangeType(value, prop.PropertyType));
        }

        return _argModel;
    }

    /// <summary>
    ///     Extracts Attributes from the Args model into a dictionary for internal parser processing.
    /// </summary>
    /// <returns>
    ///     Dictionary(string, PropertyInfo) -- mappings of argument Property name to the corresponding
    ///     PropertyInfo
    /// </returns>
    private static Dictionary<string, PropertyInfo> ExtractArgMap()
    {
        Dictionary<string, PropertyInfo> optionMap = [];
        var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

        foreach (var prop in properties)
        {
            var attr = prop.GetCustomAttribute<CliKeywordOptionAttribute>();

            if (attr == null) continue;
            optionMap[attr.ShortName] = prop;
            optionMap[attr.LongName] = prop;
        }

        return optionMap;
    }
}