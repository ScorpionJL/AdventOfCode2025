namespace AOC25.Day6;

public static class Puzzle
{
    public static (long part1, long part2) Solve(IPuzzleInput puzzleInput)
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

        return (part1, 0);
    }

    private static long NoOp(long a, long b) => 0;
    private static long Add(long a, long b) => a + b;
    private static long Multiply(long a, long b) => a * b;
}
