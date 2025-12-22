using System.Numerics;

namespace AOC25.Day5;

public static class Puzzle
{
    private record struct NumericRange<T>(T Start, T End) where T : INumber<T>;


    public static (long part1, long part2) Solve(IPuzzleInput puzzleInput)
    {
        var (ranges, ids) = puzzleInput.ParseInput();

        // find the count of ids that fall within any of the ranges
        long part1 = ids.AsParallel().Count(id => ranges.Any(range => range.Start <= id && id <= range.End));
        long part2 = 0;
        return (part1, part2);
    }


    private static (HashSet<NumericRange<long>> ranges, HashSet<long> ids) ParseInput(this IPuzzleInput input)
    {
        using var enumerator = input.ReadInput().GetEnumerator();

        var ranges = enumerator.ForEachRange()
            .Where(range => !range.Equals(new(0, 0)))
            .ToHashSet();

        var ids = enumerator.ForEachId().ToHashSet();

        return (ranges, ids);
    }

    extension(IEnumerator<string> enumerator)
    {
        private IEnumerable<NumericRange<long>> ForEachRange()
        {
            while (enumerator.MoveNext())
            {
                var line = enumerator.Current;
                if (string.IsNullOrEmpty(line)) { yield break; }

                yield return line.AsSpan().ParseRangeValues<long>();
            }
        }

        private IEnumerable<long> ForEachId()
        {
            while (enumerator.MoveNext())
            {
                var line = enumerator.Current;
                if (long.TryParse(line.AsSpan(), out var id)) { yield return id; }
            }
        }
    }

    private static NumericRange<T> ParseRangeValues<T>(this ReadOnlySpan<char> range) where T : INumber<T>
    {
        var dash = range.Trim().IndexOf('-');
        return
            dash <= 0 ||
            !T.TryParse(range[..dash], null, out var first) ||
            !T.TryParse(range[(dash + 1)..], null, out var last)
            ? new(T.Zero, T.Zero) : new(first, last);
    }
}
