using AOC25.Day4;
using Xunit;

namespace AOC25.Tests.Day4;

public class PuzzleTests
{
    [Fact]
    public void SampleFileProducesExpectedResults()
    {
        var input = PuzzleInput.Create(4, sample: true);

        var (part1, part2) = Puzzle.Solve(input);

        Assert.Equal(13, part1);
        Assert.Equal(0, part2);
    }
}
