public class Day01 : SolverBase
{
    public enum Direction
    {
        Left,
        Right
    }

    public int TurnTheDial(Direction direction, int currentPosition, int clicks)
    {
        int result;
        switch (direction)
        {
            case Direction.Left:
                result = ((currentPosition - clicks) % 100 + 100) % 100;
                Console.WriteLine($"L{clicks} - {result}");
                break;
            case Direction.Right:
                result = (currentPosition + clicks) % 100;
                Console.WriteLine($"R{clicks} - {result}");
                break;
            default:
                throw new ArgumentException("Invalid direction");
        }

        return result;
    }

    public override string Part1(string input)
    {
        var lines = Lines(input);
        int position = 50;
        int zeroCount = 0;

        foreach (var line in lines)
        {
            var directionStr = line.Substring(0, 1);
            var direction = directionStr == "L" ? Direction.Left : Direction.Right;
            var clicks = int.Parse(line.Substring(1, line.Length - 1));
            position = TurnTheDial(direction, position, clicks);

            zeroCount = position == 0 ? zeroCount + 1 : zeroCount;
        }

        return zeroCount.ToString();
    }

    public override string Part2(string input)
    {
        var lines = Lines(input);

        // TODO: Implement part 2

        return "0";
    }
}
