using System;
using System.Linq;

namespace AdventOfCode;

public static class Program
{
    public static void Main()
    {
        var days = typeof(Program).Assembly.GetTypes()
            .Where(t => !t.IsAbstract && t.GetInterfaces().Contains(typeof(IDay)))
            .Select(t => (t, Day.GetNumber(t)))
            .Where(t => ExecutionContext.DayIsSelected(t.Item2))
            .OrderBy(t => t.Item2);

        foreach (var (type, number) in days)
        {
            var day = (IDay)Activator.CreateInstance(type) ?? throw new InvalidProgramException();
            Console.Write($"Day {number}");
            Console.WriteLine();
            Console.WriteLine($"Answer Part One: {day.SolvePartOne()}");
            Console.WriteLine($"Answer Part Two: {day.SolvePartTwo()}");
            Console.WriteLine();
        }
    }
}