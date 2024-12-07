using System;
using System.Linq;

namespace AdventOfCode;

public static class Program
{
    private const int UnparsedDay = 0;
    private const string DaysArgPrefix = "days=";

    public static void Main(string[] args)
    {
        var selected = Array.Empty<int>(); 
        if (args != null)
        {
            ExecutionContext.Mode = args.All(a => !StringComparer.OrdinalIgnoreCase.Equals(a.Trim('-', '/'), "debug"))
                ? ExecutionMode.Default
                : ExecutionMode.Debug;

            var arg = args.FirstOrDefault(a => a.StartsWith(DaysArgPrefix, StringComparison.OrdinalIgnoreCase));
            if (arg != null)
            {
                var value = arg[DaysArgPrefix.Length..];
                selected = value.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.TryParse(s, out var d) ? d : UnparsedDay)
                    .Where(d => d != UnparsedDay)
                    .ToArray();
            }
        }
        
        var days = typeof(Program).Assembly.GetTypes()
            .Where(t => !t.IsAbstract && t.GetInterfaces().Contains(typeof(IDay)))
            .Select(t => (IDay)Activator.CreateInstance(t) ?? throw new InvalidProgramException())
            .Where(day => selected.Length == 0 || selected.Contains(day.Number))
            .OrderBy(day => day.Number);

        foreach (var day in days)
        {
            Console.Write($"Day {day.Number}");
            Console.WriteLine();
            Console.WriteLine($"Answer Part One: {day.SolvePartOne()}");
            Console.WriteLine($"Answer Part Two: {day.SolvePartTwo()}");
            Console.WriteLine();
        }
    }
}