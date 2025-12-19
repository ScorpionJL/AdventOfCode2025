namespace AOC25.Day4;

using Grid = char[][];

public static class Puzzle
{
    readonly record struct Coordinate(int Row, int Col);

    public static (int part1, int part2) Solve(IPuzzleInput puzzleInput)
    {
        var part1 = 0;
        var part2 = 0;

        // read the input as a grid
        var grid = puzzleInput.ReadInput()
            .Select(line => line.ToCharArray())
            .ToArray();
        var rows = grid.Length;
        var cols = grid[0].Length;

        // use to enumerate over the grid coordinates
        var coords =
            Enumerable.Range(0, rows).SelectMany(row =>
            Enumerable.Range(0, cols), (row, col) => new Coordinate(row, col));

        // first pass gets the number of cells containing paper that can be moved
        var paperToRemove = grid.CanMovePaper(coords, rows, cols).ToList();
        part1 = paperToRemove.Count;

        // subsequent passes remove the paper and repeat the process
        while (paperToRemove.Count > 0)
        {
            part2 += paperToRemove.Count;
            grid.RemovePaper(paperToRemove);
            paperToRemove = [.. grid.CanMovePaper(coords, rows, cols)];
        }

        return (part1, part2);
    }


    private const char PAPER_ROLL_SYMBOL = '@';

    private static readonly Coordinate[] BorderCells =
    [
        new(-1, -1), new(-1, +0), new(-1, +1),
        new(+0, -1),              new(+0, +1),
        new(+1, -1), new(+1, +0), new(+1, +1)
    ];


    extension(Grid grid)
    {
        private bool IsPaperRoll(Coordinate pos) => grid[pos.Row][pos.Col] == PAPER_ROLL_SYMBOL;

        private IEnumerable<Coordinate> CanMovePaper(IEnumerable<Coordinate> coords, int maxRows, int maxCols) => coords
            .Where(grid.IsPaperRoll)
            .Where(coord => grid.PaperBorderCellCount(coord, maxRows, maxCols) < 4);

        private int PaperBorderCellCount(Coordinate origin, int maxRows, int maxCols) => BorderCells
            .Select(offset => origin.ApplyOffset(offset))
            .Where(coord => coord.IsValidCoordinate(maxRows, maxCols))
            .Where(grid.IsPaperRoll)
            .Count();

        private void RemovePaper(IEnumerable<Coordinate> coordinates)
        {
            foreach (var coord in coordinates) { grid[coord.Row][coord.Col] = '.'; }
        }
    }


    extension(Coordinate coord)
    {
        private bool IsValidCoordinate(int maxRows, int maxCols) =>
            coord.Row >= 0 && coord.Row < maxRows && coord.Col >= 0 && coord.Col < maxCols;

        private Coordinate ApplyOffset(Coordinate offset) =>
            new(coord.Row + offset.Row, coord.Col + offset.Col);
    }
}
