namespace AOC25.Day4;

public static class Puzzle
{
    readonly record struct Coordinate(int row, int col);

    public static (long part1, long part2) Solve(IPuzzleInput puzzleInput)
    {
        var grid = puzzleInput.ReadInput()
            .Select(line => line.ToCharArray())
            .ToArray();
        var rows = grid.Length;
        var cols = grid[0].Length;

        var coords =
            Enumerable.Range(0, rows).SelectMany(row =>
            Enumerable.Range(0, cols), (row, col) => new Coordinate(row, col));

        var part1 = 0;
        var part2 = 0;

        List<Coordinate> movedPaper = [];
        foreach (var coord in CanMovePaper(coords, grid, rows, cols)) { movedPaper.Add(coord); }

        part1 = movedPaper.Count;
        while (movedPaper.Count > 0)
        {
            part2 += movedPaper.Count;

            MovePaper(movedPaper, grid);
            movedPaper.Clear();

            foreach (var coord in CanMovePaper(coords, grid, rows, cols)) { movedPaper.Add(coord); }
        }

        return (part1, part2);
    }

    private const char PaperRollSymble = '@';

    private static readonly Coordinate[] borderCells =
    [
        new(-1, -1), new(-1, +0), new(-1, +1),
        new(+0, -1),              new(+0, +1),
        new(+1, -1), new(+1, +0), new(+1, +1)
    ];

    private static bool IsPaperRoll(this Coordinate position, char[][] grid) => grid[position.row][position.col] == PaperRollSymble;

    private static int PaperBorderCellCount(this Coordinate position, char[][] grid, int maxRows, int maxCols)
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

    private static IEnumerable<Coordinate> CanMovePaper(IEnumerable<Coordinate> coords, char[][] grid, int maxRows, int maxCols)
    {
        foreach (var coord in coords)
        {
            if (coord.IsPaperRoll(grid))
            {
                var borders = PaperBorderCellCount(coord, grid, maxRows, maxCols);
                if (borders < 4) { yield return coord; }
            }
        }
    }

    private static void MovePaper(List<Coordinate> movedPaper, char[][] grid)
    {
        foreach (var coord in movedPaper) { grid[coord.row][coord.col] = '.'; }
    }
}
