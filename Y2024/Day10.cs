using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Utilities;

namespace AdventOfCode.Y2024;

[Year(2024)]
public class Day10 : Day<object>
{
    private sealed record Point(int Column, int Row);

    private sealed record Turn(Point point, Direction Direction);
    
    private class Map
    {
        private readonly Dictionary<Point, int> map = new();

        public Map(string[] lines)
        {
            for (var row = 0; row < lines.Length; row++)
            {
                var line = lines[row];
                for (var column = 0; column < line.Length; column++)
                {
                    var c = line[column];
                    map[new Point(column, row)] = c - '0';
                }
            }
        }
        
        public IEnumerable<Point> Trailheads => GetMapPoints(0);

        public IEnumerable<Point> Peaks => GetMapPoints(9);

        public IEnumerable<int> GetTrailheadScore(Point trailhead)
        {
            var visited = new HashSet<Turn>();
            foreach (var start in this.Trailheads)
            {
                
            }
            
            yield break;
        }
        
        private IEnumerable<Point> GetMapPoints(int height)
        {
            return this.map.Where(e => e.Value == height).Select(e => e.Key);
        }
    }

    private readonly Map map;

    public Day10()
    {
        this.map = new Map(this.GetInputLines());
    }
    
    public override object SolvePartOne()
    {
        return 0;
    }

    public override object SolvePartTwo()
    {
        return 0;
    }

    protected override string GetTestInput(int? part = null)
    {
        return """
               89010123
               78121874
               87430965
               96549874
               45678903
               32019012
               01329801
               10456732
               """;
    }
}