using System.Reflection;
using System.Text;
using Cli.Args;

namespace Cli.Parser;

public static class HelpTextGenerator
{
    public static string Generate<T>()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Usage:");

        var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

        foreach (var prop in properties)
        {
            var attr = prop.GetCustomAttribute<CliKeywordOptionAttribute>();
            if (attr == null) continue;

            sb.Append($"  {attr.ShortName}, {attr.LongName}");

            if (attr.Required) sb.Append(" (Required)");

            sb.AppendLine();
        }

        return sb.ToString();
    }
}