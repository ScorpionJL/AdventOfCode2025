namespace AOC25.Day1;

public class PuzzleInputTests : IPuzzleInput
{    public IEnumerable<string> ReadInput()
    {
        string input = """
            L150
            L50

            L150
            R50

            R150
            L50

            R150
            R50
            """;
        return input.Split(Environment.NewLine);
    }
}
