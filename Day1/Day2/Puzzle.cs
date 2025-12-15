namespace AOC25.Day2;

using System;
using AOC25;

public static class Puzzle
{
    public static (int part1, int part2) Solve(IPuzzleInput puzzleInput)
    {
        ArgumentNullException.ThrowIfNull(puzzleInput);

        foreach (var line in puzzleInput.ReadInput())
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            ReadOnlySpan<char> s = line.AsSpan();
            int len = s.Length;
            int i = 0;

            while (i < len)
            {
                // parse start id
                int start = 0;
                bool hasDigits = false;
                while (i < len)
                {
                    char c = s[i];
                    if (c >= '0' && c <= '9')
                    {
                        start = start * 10 + (c - '0');
                        hasDigits = true;
                        i++;
                        continue;
                    }

                    if (c == '-')
                    {
                        i++; // consume '-'
                        break;
                    }

                    // skip unexpected characters
                    i++;
                }

                if (!hasDigits)
                    break;

                // parse end id
                int end = 0;
                bool hasEndDigits = false;
                while (i < len)
                {
                    char c = s[i];
                    if (c >= '0' && c <= '9')
                    {
                        end = end * 10 + (c - '0');
                        hasEndDigits = true;
                        i++;
                        continue;
                    }

                    if (c == ',')
                    {
                        i++; // consume ',' and move to next range
                        break;
                    }

                    // skip unexpected characters
                    i++;
                }

                if (!hasEndDigits)
                    break;

                // enumerate and print ids in range (inclusive). Handles descending ranges too.
                if (start <= end)
                {
                    for (int v = start; v <= end; v++)
                    {
                        Console.WriteLine(v);
                    }
                }
                else
                {
                    for (int v = start; v >= end; v--)
                    {
                        Console.WriteLine(v);
                    }
                }
            }
        }

        return (0, 0);
    }
}
