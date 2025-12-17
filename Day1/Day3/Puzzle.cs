namespace AOC25.Day3;

public static class Puzzle
{
    public static (long part1, long part2) Solve(IPuzzleInput puzzleInput)
    {
        var part1 = puzzleInput.ReadInput()
            .Select(CalculateJoltage)
            .Sum();

        var part2 = puzzleInput.ReadInput()
            .Select(CalculateHighJoltage)
            .Sum();

        return (part1, part2);
    }

    public static long CalculateJoltage(string line)
    {
        var span = line.AsSpan();
        long value = long.Parse(span[^2..]);

        // loop through the span in reverse except last two chars and print the char to the console
        for (var i = span.Length - 3; i >= 0; i--)
        {
            long digit = span[i] - '0';

            var (first, second) = Math.DivRem(value, 10);
            value = digit >= first
                ? (digit * 10) + (first > second ? first : second)
                : value;
        }

        //Console.WriteLine(value);
        return value;
    }

    public static long CalculateHighJoltage(string line)
    {
        var span = line.AsSpan();
        var joltage = span[^12..].ToArray();

        for (var i = span.Length - 13; i >= 0; i--)
        {
            var digit = span[i];
            for (var j = 0; j < joltage.Length; j++)
            {
                var currentDigit = joltage[j];
                if (digit < currentDigit) { break; }

                (digit, joltage[j]) = (joltage[j], digit);
            }
        }

        //Console.WriteLine(value);
        return long.Parse(joltage);
    }
}
