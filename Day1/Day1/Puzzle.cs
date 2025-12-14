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
        foreach (var line in puzzleInput.ReadInput())
        {
            if (line.Length < 2) { continue; }

            var direction = char.ToUpper(line[0]);
            if (direction != 'R' && direction != 'L') { continue; }

            int rotation = int.TryParse(line[1..], out var parsed) ? parsed : 0;
            if (rotation == 0) { continue; }

            // transform dial for left turns
            if (direction is 'L' && dial is not 0 or 50) { dial = 100 - dial; }

            // apply full rotation
            dial += rotation;

            // count the times zero is passed
            hitZero += dial / dialRange;

            // normalize dial back into range
            dial = dial % dialRange;

            // transform dial back for left turns
            if (direction is 'L' && dial is not 0 or 50) { dial = 100 - dial; }

            // check if we ended on zero
            if (dial == 0) { endZero++; }

            //Console.WriteLine($"Direction: {direction}, Rotation: {rotation}, New Dial: {dial}");
        }

        return (endZero, hitZero);
    }
}
