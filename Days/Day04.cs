public class Day04 : SolverBase
{
    private bool IsPaperRollAccessible(char[][] grid, int x, int y)
    {
        var countPaperRolls = 0;
        foreach (var direction in Utils.Directions8)
        {
            if (Utils.InBounds(grid, x + direction.dx, y + direction.dy))
            {
                if (grid[x + direction.dx][y + direction.dy] == '@')
                {
                    countPaperRolls++;
                }
            }
        }

        if (countPaperRolls < 4)
        {
            return true;
        }

        return false;
    }

    private (char[][],int) NextWarehouseState(char[][] input)
    {
        var output = Utils.CloneGrid(input);
        var removedPaperRolls = 0;

        for (var x = 0; x < input.Length; x++)
        {
            for (var y = 0; y < input[x].Length; y++)
            {
                if (input[x][y] != '@')
                    continue;

                if (IsPaperRollAccessible(input, x, y)) 
                {
                    output[x][y] = '.';
                    removedPaperRolls++;
                }
            }

        }

        return (output, removedPaperRolls);
    }

    public override string Part1(string input)
    {
        var locations = new List<(int, int)>();
        var grid = CharGrid(input);
        var solvedGrid = CharGrid(input);

        for (var x = 0; x < grid.Length; x++)
        {
            for (var y = 0; y < grid[x].Length; y++)
            {
                if (grid[x][y] != '@') 
                    continue;

                var countPaperRolls = 0;
                foreach(var direction in Utils.Directions8)
                {
                    if (Utils.InBounds(grid, x + direction.dx, y + direction.dy))
                    {
                        if (grid[x + direction.dx][y + direction.dy] == '@')
                        {
                            countPaperRolls++;
                        }
                    }
                }

                if (countPaperRolls < 4)
                {
                    locations.Add((x, y));
                    solvedGrid[x][y] = 'X';
                }
            }
        }

        Utils.PrintGrid(grid);
        Console.WriteLine("--------");
        Utils.PrintGrid(solvedGrid);
        
        return $"{locations.Count}";
    }
    
    public override string Part2(string input)
    {
        var grid = CharGrid(input);

        var finalState = false;
        char[][] nextState;
        var removedPaperRolls = 0;
        var totalRemovedPaperRolls = 0;
        while(!finalState)
        {
            (nextState, removedPaperRolls) = NextWarehouseState(grid);
            totalRemovedPaperRolls += removedPaperRolls;
            if (Utils.GridsEqual(grid, nextState))
            {
                grid = nextState;
                finalState = true;
            }
            else
            {
                grid = nextState;
            }
        }
        
        Utils.PrintGrid(grid);
        return $"{totalRemovedPaperRolls}";
    }
}
