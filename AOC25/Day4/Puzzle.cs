
namespace AOC25.Day4;

public static class Puzzle
{
    readonly record struct Coordinate(int row, int col);

    public static (long part1, long part2) Solve(IPuzzleInput puzzleInput)
    {
        var grid = puzzleInput.ReadInput().ToArray();
        var rows = grid.Length;
        var cols = grid[0].Length;

        var coords =
            Enumerable.Range(0, rows).SelectMany(row =>
            Enumerable.Range(0, cols), (row, col) => new Coordinate(row, col));

        int result = 0;
        foreach (var coord in coords)
        {
            if (coord.IsPaperRoll(grid))
            {
                var borders = PaperBorderCellCount(coord, grid, rows, cols);
                if (borders < 4)
                {
                    Console.WriteLine($"{coord} -- {borders}");
                    result++;
                }
            }
        }

        return (result, 0);
    }

    static Coordinate[] borderCells =
    [
        new(-1, -1), new(-1, +0), new(-1, +1),
        new(+0, -1),              new(+0, +1),
        new(+1, -1), new(+1, +0), new(+1, +1)
    ];

    private const char PaperRollSymble = '@';

    private static bool IsPaperRoll(this Coordinate position, string[] grid) => grid[position.row][position.col] == PaperRollSymble;

    private static int PaperBorderCellCount(this Coordinate position, string[] grid, int maxRows, int maxCols)
    {
        int result = 0;
        foreach (var cell in borderCells)
        {
            if (position.row + cell.row < 0) { continue; }
            if (position.row + cell.row >= maxRows) { continue; }
            if (position.col + cell.col < 0) { continue; }
            if (position.col + cell.col >= maxCols) { continue; }
            result += grid[position.row + cell.row][position.col + cell.col] == PaperRollSymble ? 1 : 0;
        }
        return result;
    }

}
