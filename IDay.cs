namespace AdventOfCode;

public interface IDay
{
    int Number { get; }
    
    ExecutionMode Mode { get; }
    
    int SolvePartOne();
    
    int SolvePartTwo();
}