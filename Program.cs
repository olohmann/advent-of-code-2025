using System.Diagnostics;

var day = args.Length > 0 ? int.Parse(args[0]) : DateTime.Now.Day;
var solver = SolverFactory.Create(day);

var input = File.ReadAllText($"Inputs/day{day:D2}.txt");

var sw = Stopwatch.StartNew();
var part1 = solver.Part1(input);
var time1 = sw.ElapsedMilliseconds;

sw.Restart();
var part2 = solver.Part2(input);
var time2 = sw.ElapsedMilliseconds;

Console.WriteLine($"Day {day}");
Console.WriteLine($"Part 1: {part1} ({time1}ms)");
Console.WriteLine($"Part 2: {part2} ({time2}ms)");
