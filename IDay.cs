namespace AdventOfCode;

public interface IDay
{
    int Number { get; }
    
    int SolvePartOne();
    
    int SolvePartTwo();
}