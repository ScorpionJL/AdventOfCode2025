using AOC25;
using Day1 = AOC25.Day1;
using Day2 = AOC25.Day2;
using Day3 = AOC25.Day3;
using Day4 = AOC25.Day4;
using Day5 = AOC25.Day5;
using Day6 = AOC25.Day6;
using Day7 = AOC25.Day7;


var day = int.TryParse(args.FirstOrDefault(), out var d) ? d : 7;
switch (day)
{
    case 1: SolveDay1(); break;
    case 2: SolveDay2(); break;
    case 3: SolveDay3(); break;
    case 4: SolveDay4(); break;
    case 5: SolveDay5(); break;
    case 6: SolveDay6(); break;
    case 7: SolveDay7(); break;
    default: break;
}


static void SolveDay1()
{
    IPuzzleInput input = PuzzleInput.Create(1);
    var (part1, part2) = Day1.Puzzle.Solve(input);
    Console.WriteLine($"""
    Part 1:  {part1}
    Part 2:  {part2}
    """);
}

static void SolveDay2()
{
    IPuzzleInput input = PuzzleInput.Create(2);
    var (part1, part2) = Day2.Puzzle.Solve(input);
    Console.WriteLine($"""
    Part 1:  {part1}
    Part 2:  {part2}
    """);
}

static void SolveDay3()
{
    IPuzzleInput input = PuzzleInput.Create(3);
    var (part1, part2) = Day3.Puzzle.Solve(input);
    Console.WriteLine($"""
    Part 1:  {part1}
    Part 2:  {part2}
    """);
}

static void SolveDay4()
{
    IPuzzleInput input = PuzzleInput.Create(4);
    var (part1, part2) = Day4.Puzzle.Solve(input);
    Console.WriteLine($"""
    Part 1:  {part1}
    Part 2:  {part2}
    """);
}

static void SolveDay5()
{
    IPuzzleInput input = PuzzleInput.Create(5);
    var (part1, part2) = Day5.Puzzle.Solve(input);
    Console.WriteLine($"""
    Part 1:  {part1}
    Part 2:  {part2}
    """);
}

static void SolveDay6()
{
    IPuzzleInput input = PuzzleInput.Create(6);
    var (part1, part2) = Day6.Puzzle.Solve(input);
    Console.WriteLine($"""
    Part 1:  {part1}
    Part 2:  {part2}
    """);
}

static void SolveDay7()
{
    IPuzzleInput input = PuzzleInput.Create(7);
    var (part1, part2) = Day7.Puzzle.Solve(input);
    Console.WriteLine($"""
    Part 1:  {part1}
    Part 2:  {part2}
    """);
}
