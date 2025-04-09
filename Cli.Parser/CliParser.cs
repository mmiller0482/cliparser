using Cli.Args;

namespace Cli.Parser;

using System;
using System.Collections.Generic;
using System.Reflection;

public class CliParser<T> where T : new()
{
    private readonly Dictionary<string, PropertyInfo> _optionMap = ExtractOptionMap();
    private readonly T _argModel = new T();
    
    public T Parse(string[] args) 
    {
        if (_optionMap.Count == 0)
        {
            // Log a message about no options; return empty Arguments class.
            return _argModel;
        }
        if (args.Length == 0)
        {
            throw new CliParserException($"Got invalid arguments for type {typeof(T).Name}");
        }
        
        // Iterate through args
        for (int i = 0; i < args.Length; i++)
        {
            if (_optionMap.TryGetValue(args[i], out var prop))
            {
                if (i + 1 < args.Length) // Ensure a value exists
                {
                    var value = args[i + 1];
                    prop.SetValue(_argModel, Convert.ChangeType(value, prop.PropertyType));
                }
            }
        }

        return _argModel;
    }
    
    private static Dictionary<string, PropertyInfo> ExtractOptionMap()
    {
        Dictionary<string, PropertyInfo> optionMap = [];
        PropertyInfo[] properties = typeof(T).GetProperties(bindingAttr: BindingFlags.Instance | BindingFlags.Public);
        
        foreach (PropertyInfo prop in properties)
        {
            var attr = prop.GetCustomAttribute<CliBoolOptionAttribute>();
            
            if (attr == null) continue;
            optionMap[attr.ShortName] = prop;
            optionMap[attr.LongName] = prop;
        }
        
        return optionMap; 
    }
}