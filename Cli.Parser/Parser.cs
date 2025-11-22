using Cli.Args;

namespace Cli.Parser;

using System;
using System.Collections.Generic;
using System.Reflection;

public static class Parser
{

    private static Dictionary<string, PropertyInfo> ExtractOptionMap<T>()
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
    public static T Parse<T>(string[] args) where T : new()
    {
        var obj = new T();
        Dictionary<string, PropertyInfo> optionMap = ExtractOptionMap<T>();

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