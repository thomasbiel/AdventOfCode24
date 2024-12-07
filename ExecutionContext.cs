using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode;

public static class ExecutionContext
{
    private const int UnparsedDay = 0;
    private const string DaysArgPrefix = "days=";
    
    private static IReadOnlySet<int> Days { get; }
    
    static ExecutionContext()
    {
        var args = Environment.GetCommandLineArgs();
        Mode = args.All(a => !StringComparer.OrdinalIgnoreCase.Equals(a.Trim('-', '/'), "debug"))
            ? ExecutionMode.Default
            : ExecutionMode.Debug;
        
        var arg = args.FirstOrDefault(a => a.StartsWith(DaysArgPrefix, StringComparison.OrdinalIgnoreCase));
        if (arg != null)
        {
            var value = arg[DaysArgPrefix.Length..];
            Days = value.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.TryParse(s, out var d) ? d : UnparsedDay)
                .Where(d => d != UnparsedDay)
                .ToHashSet();
        }
    }
    
    public static ExecutionMode Mode { get; }
    
    public static bool DayIsSelected(int day) => Days == null || Days.Count == 0 || Days.Contains(day);
}