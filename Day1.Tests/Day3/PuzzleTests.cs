using AOC25.Day3;
using Xunit;

namespace AOC25.Tests.Day3;

public class PuzzleTests
{
    [Fact]
    public void SampleFileProducesExpectedResults()
    {
        var input = PuzzleInput.Create(3, sample: true);

        var (part1, part2) = Puzzle.Solve(input);

        Assert.Equal(357, part1);
        Assert.Equal(0, part2);
    }
}
