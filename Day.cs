using System;
using System.IO;

namespace AdventOfCode;

public abstract class Day : IDay
{
    protected const int PartOne = 1;
    protected const int PartTwo = 2;
    
    public int Number
    {
        get
        {
            var name = this.GetType().Name;
            return int.Parse(name[nameof(Day).Length..]);
        }
    }
    
    public abstract int SolvePartOne();
    
    public abstract int SolvePartTwo();

    public virtual ExecutionMode Mode => ExecutionMode.Default;
    
    protected abstract string GetTestInput(int? part = null);

    protected void TestOut(string message)
    {
        if (this.Mode == ExecutionMode.Test)
        {
            Console.WriteLine(message);
        }
    }
    
    protected string[] GetInputLines(int? part = null)
    {
        return this.Mode == ExecutionMode.Default
            ? GetInput(part, File.ReadAllLines)
            : GetTestInput().Split("\n", StringSplitOptions.TrimEntries);
    }

    protected string GetInput(int? part = null)
    {
        return this.Mode == ExecutionMode.Default
            ? GetInput(part, File.ReadAllText)
            : GetTestInput();
    }

    private T GetInput<T>(int? part, Func<string, T> factory)
    {
        var path = null == part ? $".\\data\\Day{this.Number}.txt" : $".\\data\\Day{this.Number}_{part}.txt";
        return factory(path);
    }
}