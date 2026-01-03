namespace AOC25.Day6;

public static class Puzzle
{
    public static (long part1, long part2) Solve(IPuzzleInput puzzleInput)
    {
        var part1 = SolvePart1(puzzleInput);
        var part2 = SolvePart2(puzzleInput);
        return (part1, part2);
    }


    private static long SolvePart1(IPuzzleInput puzzleInput)
    {
        const StringSplitOptions TrimAndRemoveEmptyEntries =
            StringSplitOptions.RemoveEmptyEntries |
            StringSplitOptions.TrimEntries;

        var lines = puzzleInput.ReadInput()
            .Select(static line => line.Split(' ', TrimAndRemoveEmptyEntries))
            .ToArray();
        var cols = lines[^1].Length;

        long result = 0;
        for (int col = 0; col < cols; col++) { result += lines.ComputeColumnTotal(col); }

        return result;
    }

    private static long ComputeColumnTotal(this string[][] lines, int col)
    {
        char operation = lines[^1][col][0];

        long result = 0;

        foreach (var row in lines[..^1])
        {
            long value = long.Parse(row[col]);
            result = operation switch
            {
                _ when result == 0 => value,
                '+' => result + value,
                '*' => result * value,
                _ => result
            };
        }

        return result;
    }

    private static long SolvePart2(IPuzzleInput puzzleInput)
    {
        var grid = puzzleInput.ReadInput()
            .Select(line => line.ToCharArray())
            .ToArray();
        var cols = grid[0].Length;

        long grandTotal = 0;
        for (int col = 0; col < cols; col++)
        {
            char operation = grid.GetOperation(col);
            long total = 0;
            foreach (var number in grid.GetColumnNumbers(col))
            {
                if (number == 0) { continue; }
                total = operation switch
                {
                    _ when total == 0 => number,
                    '+' => total + number,
                    '*' => total * number,
                    _ => total
                };
                col++;
            }

            grandTotal += total;
        }

        return grandTotal;
    }

    static bool IsOperation(this char symbol) => symbol is '+' or '*';

    extension(char[][] grid)
    {
        private char GetOperation(int col) => grid[^1][col];

        private IEnumerable<long> GetColumnNumbers(int startingCol)
        {
            var cols = grid[^1].Length;
            for (var col = startingCol; col < cols; col++)
            {
                if (col > startingCol && grid.GetOperation(col).IsOperation()) { yield break; }
                yield return grid.GetColumnNumber(col);
            }
        }

        private long GetColumnNumber(int col) => grid[..^1]
            .Select(row => row[col])
            .Where(char.IsDigit)
            .Aggregate(0L, (acc, ch) => (acc * 10) + (ch - '0'));
    }
}
