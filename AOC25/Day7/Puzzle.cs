namespace AOC25.Day7;

public static class Puzzle
{
    readonly record struct Coordinate(int Row, int Col);

    public static (long part1, long part2) Solve(IPuzzleInput puzzleInput)
    {
        var part1 = SolvePart1(puzzleInput);
        var part2 = SolvePart2(puzzleInput);
        return (part1, part2);
    }

    private static long SolvePart1(IPuzzleInput puzzleInput)
    {
        var grid = puzzleInput.ReadInputAsGrid();
        var rows = grid.Length;
        var cols = grid[0].Length;

        var start = grid[0].IndexOf('S');

        HashSet<Coordinate> beams = [new(0, start)];
        var splits = 0;
        for (var row = 0; row < rows - 1; row++)
        {
            HashSet<Coordinate> newBeams = [];
            foreach (var beam in beams)
            {
                var col = beam.Col;
                if (grid[row][col] == '^')
                {
                    splits++;
                    if (col > 0) { newBeams.Add(new(row + 1, col - 1)); }
                    if (col < cols - 1) { newBeams.Add(new(row + 1, col + 1)); }
                }
                else
                {
                    newBeams.Add(new(row + 1, col));
                }
            }
            beams = newBeams;
        }

        return splits;
    }

    private static long SolvePart2(IPuzzleInput puzzleInput)
    {
        return 0;
    }
}
