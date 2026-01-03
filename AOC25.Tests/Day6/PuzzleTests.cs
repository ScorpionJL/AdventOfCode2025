using AOC25.Day6;
using Xunit;

namespace AOC25.Tests.Day6;

public class PuzzleTests
{
    [Fact]
    public void SampleFileProducesExpectedResults()
    {
        var input = PuzzleInput.Create(6, sample: true);

        var (part1, part2) = Puzzle.Solve(input);

        Assert.Equal(4277556, part1);
        Assert.Equal(3263827, part2);
    }
}
