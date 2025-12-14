namespace AOC25.Day1;

public static class Puzzle
{
    public static (int part1, int part2) Solve(IPuzzleInput puzzleInput)
    {
        const int dialRange = 100;

        var result = puzzleInput.ReadInput()
            .Select(ParseRotations)
            .Where(IsValidRotation)
            .Aggregate(
                (dial: 50, endZero: 0, hitZero: 0),
                (state, rotation) =>
                {
                    (var dial, var endZero, var hitZero) = (state.dial, state.endZero, state.hitZero);

                    // transform dial for left turns
                    dial = TransformDial(dial, rotation.direction);

                    // apply full rotation
                    dial += rotation.amount;

                    // count the times zero is reached (integer division)
                    hitZero += dial / dialRange;

                    // normalize dial back into range
                    dial %= dialRange;

                    // transform dial back for left turns
                    dial = TransformDial(dial, rotation.direction);

                    // count if we ended on zero
                    if (dial == 0) { endZero++; }

                    return (dial, endZero, hitZero);
                });

        return (result.endZero, result.hitZero);
    }

    private static (char direction, int amount) ParseRotations(string line)
    {
        var span = line.AsSpan();
        if (span.Length < 2) { return (' ', 0); }

        var direction = char.ToUpper(span[0]);
        var rotation = int.TryParse(span[1..], out var parsed) ? parsed : 0;
        return (direction, rotation);
    }

    private static bool IsValidRotation((char direction, int amount) rotation) =>
        (rotation.direction == 'R' || rotation.direction == 'L') && rotation.amount != 0;

    private static int TransformDial(int dial, char direction) => (direction == 'L' && dial != 0 && dial != 50) ? 100 - dial : dial;
}
