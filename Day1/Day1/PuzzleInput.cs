namespace AOC25.Day1;

public interface IPuzzleInput
{
    IEnumerable<string> GetInput();
}

public class PuzzleInputSample : IPuzzleInput
{
    private static readonly string SAMPLE_INPUT = @"""
        L68
        L30
        R48
        L5
        R60
        L55
        L1
        L99
        R14
        L82
        """;

    public IEnumerable<string> GetInput()
    {
        return SAMPLE_INPUT.Split(["\r\n", "\r", "\n"], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }
}
