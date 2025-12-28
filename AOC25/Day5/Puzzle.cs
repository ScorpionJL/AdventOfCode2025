using System.Numerics;
using AOC25.Common;

namespace AOC25.Day5;

public static class Puzzle
{
    public static (long part1, long part2) Solve(IPuzzleInput puzzleInput)
    {
        var (ranges, ids) = puzzleInput.ParseInput();

        // find the count of ids that fall within any of the ranges
        long part1 = ids.Count(id => IsFreshIngredient(id, ranges));
        long part2 = ranges.MergeOverlappingRanges().Sum(range => range.RangeSize);

        return (part1, part2);
    }

    private static bool IsFreshIngredient(long ingredient, HashSet<NumericRange<long>> ranges) => 
        ranges.Any(range => range.IsInRange(ingredient));

    private static IEnumerable<NumericRange<long>> MergeOverlappingRanges(this HashSet<NumericRange<long>> ranges)
    {
        var sorted = ranges.ToSortedList();
        var current = sorted[0];
        foreach (var range in sorted.Skip(1))
        {
            if (range.Overlaps(current)) { current = ExtendRange(current, range); }
            else { yield return current; current = range; }
        }
        yield return current; // yield last working range

        static NumericRange<long> ExtendRange(NumericRange<long> current, NumericRange<long> range) =>
            new(Math.Min(current.Start, range.Start), Math.Max(current.End, range.End));
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

    extension(ReadOnlySpan<char> range)
    {
        private NumericRange<T> ParseRangeValues<T>() where T : IBinaryInteger<T>
        {
            var dash = range.Trim().IndexOf('-');
            return
                dash <= 0 ||
                !T.TryParse(range[..dash], null, out var first) ||
                !T.TryParse(range[(dash + 1)..], null, out var last)
                ? new(T.Zero, T.Zero) : new(first, last);
        }
    }

    private static List<T> ToSortedList<T>(this IEnumerable<T> source) => source.ToList().SortList();

    private static List<T> SortList<T>(this List<T> list) { list.Sort(); return list; }
}
