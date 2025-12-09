namespace AOC25.Day1;

public class Solution
{
    private static int RotationAmount(string line)
    {
        if (line.Length < 2) { return 0; }
        var direction = char.ToUpper(line[0]);
        int rotation = int.TryParse(line[1..], out var parsed) ? parsed : 0;
        return (direction, rotation) switch
        {
            ('R', _) => rotation,
            ('L', _) => -rotation,
            _ => 0,
        };
    }

    public static int Part1(IPuzzleInput puzzleInput)
    {
        int zeros = 0;
        var dial = new Dial(50);

        var rotations = puzzleInput.GetInput().Select(RotationAmount);
        foreach (var rotation in rotations)
        {
            dial.Rotate(rotation);
            LogRotation(dial, rotation);
            if (dial.Value == 0) { zeros++; }
        }

        return zeros;
    }

    static void LogRotation(Dial dial, int parsedVal)
    {
        Console.WriteLine($"Dial changed by {parsedVal}, new position: {dial.Value}");
    }
}
