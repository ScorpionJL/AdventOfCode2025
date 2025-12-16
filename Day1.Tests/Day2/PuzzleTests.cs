using AOC25.Day2;
using Xunit;

namespace AOC25.Tests.Day2;

public class PuzzleTests
{
    [Fact]
    public void SampleFileProducesExpectedResults()
    {
        var input = PuzzleInput.Create(2, sample: true);

        var (part1, part2) = Puzzle.Solve(input);

        Assert.Equal(1227775554, part1);
        Assert.Equal(4174379265, part2);
    }
}
