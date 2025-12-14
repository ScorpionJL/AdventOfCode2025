using AOC25.Day1;

// 6122

//var input1 = new PuzzleInputSample();
//var input1 = new PuzzleInputTests();
var input1 = new PuzzleInput();
var solution = Puzzle.Solve(input1);
Console.WriteLine($"Part 1:  {solution.part1}");
Console.WriteLine($"Part 2:  {solution.part2}");


var dial = 50;
int hits = 0;
foreach (var line in input1.GetInput())
{
    var dir = line[0];
    var amount = int.Parse(line[1..]);
    for (var i = 0; i < amount; i++)
    {
        if (dir == 'L')
        {
            dial = (dial - 1 + 100) % 100;
        }
        else
        {
            dial = (dial + 1) % 100;
        }

        if (dial == 0) { hits += 1; }
    }
    //System.Diagnostics.Debug.WriteLine($"Direction: {dir}, Rotation: {amount}, New Dial: {dial}");
}
Console.WriteLine(hits);
