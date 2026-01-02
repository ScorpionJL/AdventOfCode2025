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

        var lines = puzzleInput.ReadInput().Select(static line => line.Split(' ', TrimAndRemoveEmptyEntries)).ToArray();

        var rows = lines.Length;
        var cols = lines[^1].Length;

        long part1 = 0;
        for (int col = 0; col < cols; col++)
        {
            Func<long, long, long> operation = lines[^1][col] switch
            {
                "+" => Add,
                "*" => Multiply,
                _ => NoOp
            };

            part1 += lines[..^1]
                .Select(row => long.Parse(row[col]))
                .Aggregate((total, value) => operation(total, value));
        }

        return part1;
    }

    private static long SolvePart2(IPuzzleInput puzzleInput)
    {
        long part2 = 0;

        // read the input as a grid of chars
        var grid = puzzleInput.ReadInput()
            .Select(line => line.ToCharArray())
            .ToArray();

        var rows = grid.Length;
        var cols = grid[0].Length;

        char currentSymbol = '+';
        long result = 0;
        for (int col = 0; col < cols; col++)
        {
            char symbol = grid[^1][col];
            if (symbol == '+' || symbol == '*')
            {
                part2 += result;
                currentSymbol = symbol;
                result = (symbol == '+') ? 0 : 1;
            }

            long colValue = grid.GetColumnValue(col);
            if (colValue == 0) { continue; }

            switch (currentSymbol)
            {
                case '+': result += colValue; break;
                case '*': result *= colValue; break;
            }
        }
        part2 += result;

        return part2;
    }

    private static long GetColumnValue(this char[][] grid, int col)
    {
        long value = 0;
        foreach (var row in grid[..^1])
        {
            if (char.IsDigit(row[col]))
            {
                value = (value * 10) + (row[col] - '0');
            }
        }
        return value;
    }


    private static long NoOp(long a, long b) => 0;
    private static long Add(long a, long b) => a + b;
    private static long Multiply(long a, long b) => a * b;
}
