using System.Numerics;

namespace AOC25.Common;

public record struct NumericRange<T>(T Start, T End) : IComparable<NumericRange<T>>
    where T : IBinaryInteger<T>
{
    public int CompareTo(NumericRange<T> other)
    {
        var compare = Start.CompareTo(other.Start);
        return compare == 0 ? End.CompareTo(other.End) : compare;
    }
}

internal static class NumericRangeExtensions
{
    extension<T>(NumericRange<T> range) where T : IBinaryInteger<T>
    {
        public T RangeSize => range.End - range.Start + T.One;

        public bool Overlaps(NumericRange<T> other) => range.Start <= other.End && other.Start <= range.End;

        public bool IsInRange(T value) => range.Start <= value && value <= range.End;
    }
}