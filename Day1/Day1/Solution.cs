namespace AOC25.Day1;

public class Solution
{
    public static int Part1(IPuzzleInput puzzleInput)
    {
        var result = 0;
        var dial = new Dial(50);

        foreach (var line in puzzleInput.GetInput())
        {
            if (line.StartsWith('R'))
            {
                if (int.TryParse(line[1..], out var parsedVal)) { dial.RotateRight(parsedVal); }
                LogRotation(dial, parsedVal);
                if (dial.Value == 0) { result++; }
            }
            else if (line.StartsWith('L'))
            {
                if (int.TryParse(line[1..], out var parsedVal)) {  dial.RotateLeft(parsedVal); }
                Console.WriteLine($"Dial changed by {-parsedVal}, new position: {dial.Value}");
                if (dial.Value == 0) { result++; }
            }
        }
        return result;

        static void LogRotation(Dial dial, int parsedVal)
        {
            Console.WriteLine($"Dial changed by {parsedVal}, new position: {dial.Value}");
        }
    }
}
