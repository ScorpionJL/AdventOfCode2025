using AOC25.Day7;
using Xunit;

namespace AOC25.Tests.Day7;

public class PuzzleTests
{
    [Fact]
    public void SampleFileProducesExpectedResults()
    {
        var input = PuzzleInput.Create(7, sample: true);

        var (part1, part2) = Puzzle.Solve(input);

        Assert.Equal(0, part1);
        Assert.Equal(0, part2);
    }
}
