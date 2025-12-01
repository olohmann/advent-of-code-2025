public class Day01 : SolverBase
{
    public enum Direction
    {
        Left,
        Right
    }

    // ... avoids the painful negative integer division that truncates to 0.
    private int FloorDiv(int x, int n)
    {
        return (x >= 0) ? (x / n) : ((x - n + 1) / n);
    }

    public (int, int) TurnTheDial(Direction direction, int currentPosition, int clicks)
    {
        int newPosition;
        int zeroFlips;
        switch (direction)
        {
            case Direction.Left:
                newPosition = ((currentPosition - clicks) % 100 + 100) % 100;
                zeroFlips = FloorDiv(currentPosition - 1, 100) - FloorDiv(currentPosition - clicks - 1, 100);
                Console.WriteLine($"L{clicks} - {newPosition} (Flips: {zeroFlips})");
                break;
            case Direction.Right:
                newPosition = (currentPosition + clicks) % 100;
                zeroFlips = (currentPosition + clicks) / 100 - currentPosition / 100;
                Console.WriteLine($"R{clicks} - {newPosition} (Flips: {zeroFlips})");
                break;
            default:
                throw new ArgumentException("Invalid direction");
        }

        return (newPosition, zeroFlips);
    }

    public override string Part1(string input)
    {
        var lines = Lines(input);
        int position = 50;
        int zeroFlips = 0;

        foreach (var line in lines)
        {
            var directionStr = line.Substring(0, 1);
            var direction = directionStr == "L" ? Direction.Left : Direction.Right;
            var clicks = int.Parse(line.Substring(1, line.Length - 1));
            (position, _) = TurnTheDial(direction, position, clicks);

            zeroFlips = position == 0 ? zeroFlips + 1 : zeroFlips;
        }

        return zeroFlips.ToString();
    }

    public override string Part2(string input)
    {
        var lines = Lines(input);
        int position = 50;
        int zeroCount = 0;
        int zeroFlips = 0;

        foreach (var line in lines)
        {
            var directionStr = line.Substring(0, 1);
            var direction = directionStr == "L" ? Direction.Left : Direction.Right;
            var clicks = int.Parse(line.Substring(1, line.Length - 1));
            (position, zeroFlips) = TurnTheDial(direction, position, clicks);

            zeroCount += zeroFlips;
        }

        return zeroCount.ToString();
    }
}
