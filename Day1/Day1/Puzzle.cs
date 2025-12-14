using System.Numerics;

namespace AOC25.Day1;

public static class Puzzle
{
    public static (int part1, int part2) Solve(IPuzzleInput puzzleInput)
    {
        const int dialRange = 100;
        int dial = 50;

        int endZero = 0;
        int hitZero = 0;

        // foreach line in input
        foreach (var line in puzzleInput.GetInput())
        {
            if (line.Length < 2) { continue; }

            var direction = char.ToUpper(line[0]);
            if (direction != 'R' && direction != 'L') { continue; }

            int rotation = int.TryParse(line[1..], out var parsed) ? parsed : 0;
            if (rotation == 0) { continue; }


            var absoluteDial = (direction == 'L' && dial != 0)
                ? 100 - dial
                : dial;

            hitZero += (absoluteDial + rotation) / dialRange;

            dial = direction == 'R'
                ? (dial + rotation) % dialRange
                : (dial - rotation + dialRange) % dialRange;

            if (dial == 0) { endZero++; }
            Console.WriteLine($"Direction: {direction}, Rotation: {rotation}, New Dial: {dial}");
        }

        return (endZero, hitZero);
    }
}

file static class NumberExtensions
{
    extension<T>(T value) where T : INumber<T>
    {
        public T Modulo(T modulus) =>
            T.IsZero(modulus)
            ? throw new DivideByZeroException()
            : (value % modulus + modulus) % modulus;
    }
}
