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
        var dial = new DialPosition(50);


        // foreach line in input
        foreach (var line in puzzleInput.GetInput())
        {
            // parse line to get rotation amount
            var rotation = RotationAmount(line);
            if (rotation == 0) { continue; }

            // if line is valid, rotate dial and new dial position
            dial = dial.RotateDial(rotation);
            LogRotation(dial, rotation);

            // if dial is at 0, increment zeros
            if (dial.Value == 0) { zeros++; }
        }

        // return number of times dial was at 0
        return zeros;
    }

    static void LogRotation(DialPosition dial, int parsedVal)
    {
        Console.WriteLine($"Dial changed by {parsedVal}, new position: {dial.Value}");
    }
}
