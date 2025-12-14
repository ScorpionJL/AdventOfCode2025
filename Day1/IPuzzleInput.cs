namespace AOC25;

public interface IPuzzleInput
{
    IEnumerable<string> ReadInput();
}

public class FileInput : IPuzzleInput
{
    private readonly string _inputFilePath;

    public FileInput(string inputFilePath) => _inputFilePath = inputFilePath;

    public IEnumerable<string> ReadInput() => File.ReadLines(_inputFilePath);
}

public static class PuzzleInput
{
    public static IPuzzleInput Create(int day, bool sample = false) => 
        new FileInput($@"day{day}\input{(sample ? "-sample" : "")}.txt");
}
