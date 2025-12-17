namespace AOC25.Day3;

public static class Puzzle
{
    public static (long part1, long part2) Solve(IPuzzleInput puzzleInput)
    {
        var part1 = 0L;
        var part2 = 0L;

        part1 = puzzleInput.ReadInput()
            .Select(ProcessLine)
            .Sum();

        return (part1, part2);
    }

    public static int ProcessLine(string line)
    {
        var span = line.AsSpan();
        int value = int.Parse(span[^2..]);

        // loop through the span in reverse except last two chars and print the char to the console
        for (var i = span.Length - 3; i >= 0; i--)
        {
            int digit = span[i] - '0';

            var (first, second) = Math.DivRem(value, 10);
            value = digit >= first
                ? (digit * 10) + (first > second ? first : second)
                : value;
        }

        //Console.WriteLine(value);
        return value;
    }
}
