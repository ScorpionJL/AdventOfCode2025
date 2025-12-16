namespace AOC25.Day2;

public static class Puzzle
{
    private record struct NumericRange(long Start, long End);

    public static (long part1, long part2) Solve(IPuzzleInput puzzleInput)
    {
        var part1 = 0L;
        var part2 = 0L;

        var input = puzzleInput.LoadInput().AsSpan();
        foreach (var range in input.Split(','))
        {
            part1 += input[range]
                .ParseRangeValues()
                .ExpandRange()
                .Where(ValueIsInvalid)
                .Sum();
        }

        foreach (var range in input.Split(','))
        {
            part2 += input[range]
                .ParseRangeValues()
                .ExpandRange()
                .Where(ValueRepeats)
                .Sum();
        }

        // 28846518423, 31578210022
        return (part1, part2);
    }

    private static bool ValueRepeats(long num)
    {
        // get the number of digits in the value
        var digits = num.Digits;

        for (var sequenceLength = 1; sequenceLength < digits; sequenceLength++)
        {
            // must be able to split the number up evenly
            if (digits % sequenceLength != 0) { continue; } 

            if (CheckForSequence(num, sequenceLength))
            {
                Console.WriteLine($"**{num}");
                return true;
            }
        }

        return false;
    }

    private static bool CheckForSequence(long num, long sequenceLength)
    {
        var multiplier = (long)Math.Pow(10, sequenceLength);

        (num, var target) = Math.DivRem(num, multiplier);
        while (num > 0)
        {
            (num, var sequence) = Math.DivRem(num, multiplier);
            if (sequence != target) { return false; }
        }

        return true;
    }


    private static bool ValueIsInvalid(long num)
    {
        // get the number of digits in the value
        var digits = num.Digits;

        // must be an even number of digits to have a sequence repeated twice
        var (half, remainder) = Math.DivRem(digits, 2);
        if (remainder != 0) { return false; }

        // split the number into two equal parts
        var multiplier = (long)Math.Pow(10, half);
        var (firstHalf, secondHalf) = Math.DivRem(num, multiplier);

        // number is invalid if the both parts match
        return (firstHalf == secondHalf);
    }


    extension(ReadOnlySpan<char> range)
    {
        private NumericRange ParseRangeValues()
        {
            //Console.WriteLine(range);
            var dash = range.Trim().IndexOf('-');
            return
                dash <= 0 ||
                !long.TryParse(range[..dash], out long first) ||
                !long.TryParse(range[(dash + 1)..], out long last)
                ? new NumericRange(0, 0) : new NumericRange(first, last);
        }
    }

    extension(NumericRange source)
    {
        IEnumerable<long> ExpandRange()
        {
            for (long num = source.Start; num < source.End + 1; num++) { yield return num; }
        }
    }

    extension(long number)
    {
        long Digits => number == 0 ? 1 : (long)Math.Floor(Math.Log10(Math.Abs(number))) + 1;
    }
}
