namespace AOC25.Day1;

public class Solution
{
    public static int Part1(IPuzzleInput puzzleInput)
    {
        var dial = new Dial(50);

        var results = puzzleInput
            .GetInput()
            .Where(line => line.Length >= 2)
            .Select(line =>
            {
                var direction = line.ToUpper()[0];
                int? rotation = int.TryParse(line[1..], out var parsed) ? parsed : null;
                return (direction, rotation);
            });

            // Apply rotations; skip when parse failed (rotation is null)
            foreach (var (direction, rotation) in instructions)
            {
                if (rotation is null) continue;

                if (direction == 'R')
                {
                    dial.RotateRight(rotation.Value);
                    LogRotation(dial, rotation.Value);
                }
                else if (direction == 'L')
                {
                    dial.RotateLeft(rotation.Value);
                    LogRotation(dial, -rotation.Value);
                }
            };

            .Select(line =>
            {
            var x = (line.direction, line.rotation) switch
            {
                (_, is null }) => 0,
                    ('R', _) => dial.RotateRight(line.direction),
                    ('L', _) => dial.RotateLeft(line.direction),
                };
                return dial;
            });

        // switch expression
        // when rotate is null then skip
        // when direction is 'R' then rotate right
        // when direciton is 'L' then rotate left
        // else skip
        



            //.Select(line =>
            //{
            //    if (line.Length < 2) { return 0; }
            //    if (int.TryParse(line[1..], out var parsedVal))
            //    {

        //        if (line[0] == 'R')
        //        {
        //            dial.RotateRight(parsedVal);
        //            LogRotation(dial, parsedVal);
        //        }
        //        else if (line[0] == 'L')
        //        {
        //            dial.RotateLeft(parsedVal);
        //            LogRotation(dial, -parsedVal);
        //        }
        //    }
        //    return dial.Value == 0 ? 1 : 0;
        //})
        //.Sum();

        return 0;
    }

    static void LogRotation(Dial dial, int parsedVal)
{
    Console.WriteLine($"Dial changed by {parsedVal}, new position: {dial.Value}");
}
}
