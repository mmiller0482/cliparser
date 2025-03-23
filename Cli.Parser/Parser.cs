using Cli.Args;

namespace Cli.Parser;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class Parser
{
    public static T Parse<T>(string[] args) where T : new()
    {
        var obj = new T();
        var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        var optionMap = new Dictionary<string, PropertyInfo>();

        // Map short and long names to properties
        foreach (var prop in properties)
        {
            var attr = prop.GetCustomAttribute<CliOptionAttribute>();
            if (attr != null)
            {
                optionMap[attr.ShortName] = prop;
                optionMap[attr.LongName] = prop;
            }
        }

        // Iterate through args
        for (int i = 0; i < args.Length; i++)
        {
            if (optionMap.TryGetValue(args[i], out var prop))
            {
                if (i + 1 < args.Length) // Ensure a value exists
                {
                    var value = args[i + 1];
                    prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType));
                }
            }
        }

        return obj;
    }
}