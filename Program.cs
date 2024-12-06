using System;
using System.Linq;

namespace AdventOfCode;

public static class Program
{
    public static void Main()
    {
        var days = typeof(Program).Assembly.GetTypes()
            .Where(t => !t.IsAbstract && t.GetInterfaces().Contains(typeof(IDay)))
            .Select(t => Activator.CreateInstance(t) as IDay)
            .OrderBy(day => day.Number);

        foreach (var day in days)
        {
            Console.Write($"Day {day.Number}");
            if (day.Mode == ExecutionMode.Test)
            {
                Console.Write(" (Test)");
            }
            Console.WriteLine();
            Console.WriteLine($"Answer Part One: {day.SolvePartOne()}");
            Console.WriteLine($"Answer Part Two: {day.SolvePartTwo()}");
            Console.WriteLine();
        }
    }
}