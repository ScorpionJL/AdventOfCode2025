using AOC25.Day1;
using Xunit;

namespace AOC25.Tests.Day1;

public class PuzzleTests
{
    [Fact]
    public void SampleFileProducesExpectedResults()
    {
        var input = PuzzleInput.Create(1, sample: true);

        var (part1, part2) = Puzzle.Solve(input);

        Assert.Equal(3, part1);
        Assert.Equal(6, part2);
    }

    [Fact]
    public void SampleInputProducesExpectedResults()
    {
        var input = new SampleInput();

        var (part1, part2) = Puzzle.Solve(input);

        Assert.Equal(4, part1);
        Assert.Equal(8, part2);
    }

    private class SampleInput : IPuzzleInput
    {
        public IEnumerable<string> ReadInput()
        {
            // sample groups
            yield return "L150";
            yield return "L50";
            yield return string.Empty;

            yield return "L150";
            yield return "R50";
            yield return string.Empty;

            yield return "R150";
            yield return "L50";
            yield return string.Empty;

            yield return "R150";
            yield return "R50";
        }
    }
}
