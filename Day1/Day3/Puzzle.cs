namespace AOC25.Day3;

public static class Puzzle
{
    public static (long part1, long part2) Solve(IPuzzleInput puzzleInput)
    {
        var result = puzzleInput.ReadInput()
            .Select(CalculateJoltages)
            .Aggregate(
                (low: 0L, high: 0L),
                (state, joltage) =>
                {
                    state.low += joltage.low;
                    state.high += joltage.high;
                    return state;
                });

        return (result.low, result.high);
    }

    private static (long low, long high) CalculateJoltages(string line)
    {
        var span = line.AsSpan();
        return (CalculateJoltage(span), CalculateHighJoltage(span));
    }

    private static long CalculateJoltage(ReadOnlySpan<char> span)
    {
        var value = long.Parse(span[^2..]);

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

    private static long CalculateHighJoltage(ReadOnlySpan<char> span)
    {
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
