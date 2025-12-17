#pragma warning disable CS8321 // Local function is declared but never used

using AOC25;
using Day1 = AOC25.Day1;
using Day2 = AOC25.Day2;
using Day3 = AOC25.Day3;

//SolveDay1();
//SolveDay2();
SolveDay3();

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
