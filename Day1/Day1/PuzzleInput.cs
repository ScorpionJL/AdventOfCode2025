namespace AOC25.Day1;

public interface IPuzzleInput
{
    IEnumerable<string> GetInput();
}

public class FileInput : IPuzzleInput
{
    private readonly string _inputFilePath;

    public FileInput(string inputFilePath) => _inputFilePath = inputFilePath;

    public IEnumerable<string> GetInput() => File.ReadLines(_inputFilePath);
}

public class PuzzleInputSample : FileInput
{
    public PuzzleInputSample() : base(@"day1\input-sample.txt") { }
}

public class PuzzleInput : FileInput
{
    public PuzzleInput() : base(@"day1\input.txt") { }
}

public class PuzzleInputTests : IPuzzleInput
{    public IEnumerable<string> GetInput()
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
