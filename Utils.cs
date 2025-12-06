// Additional utility methods you can extend

using System.Text;

public static class Utils
{
    // Direction helpers for grid navigation
    public static readonly (int dx, int dy)[] Directions4 = 
        [(0, 1), (1, 0), (0, -1), (-1, 0)]; // Right, Down, Left, Up
    
    public static readonly (int dx, int dy)[] Directions8 = 
        [(0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1)];

    public static T[][] CloneGrid<T>(T[][] original) where T : struct
    {
        var newGrid = new T[original.Length][];
        for (int i = 0; i < original.Length; i++)
        {
            newGrid[i] = (T[])original[i].Clone();
        }
        return newGrid;
    }

    public static T[] CloneArr<T>(T[] original) where T : struct
    {
        var newArr = new T[original.Length];
        for (int i = 0; i < original.Length; i++)
        {
            newArr[i] = original[i];
        }

        return newArr;
    }


    public static bool GridsEqual<T>(T[][] gridA, T[][] gridB) where T : struct
    {
        if (gridA.Length != gridB.Length) return false;

        for (int i = 0; i < gridA.Length; i++)
        {
            if (!gridA[i].SequenceEqual(gridB[i]))
            {
                return false;
            }
        }
        return true;
    }

    public static bool InBounds<T>(this T[][] grid, int x, int y) =>
        y >= 0 && y < grid.Length && x >= 0 && x < grid[y].Length;
    
    // Manhattan distance
    public static int ManhattanDistance((int x, int y) a, (int x, int y) b) =>
        Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
    
    // GCD and LCM
    public static long GCD(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    
    public static long LCM(long a, long b) => a / GCD(a, b) * b;
    
    // Print grid for debugging
    public static void PrintGrid<T>(T[][] grid)
    {
        foreach (var row in grid)
        {
            Console.WriteLine(string.Join("", row));
        }
        Console.WriteLine();
    }
    
    public static void PrintSequence<T>(IEnumerable<T> sequence, string title = "")
    {
        var strBuilder = new StringBuilder();
        for(var i = 0; i < sequence.Count() - 1; i++)
        {
            strBuilder.Append(sequence.ElementAt(i));
            strBuilder.Append("; ");
        }

        if (sequence.Count() > 0)
        {
            strBuilder.Append(sequence.ElementAt(sequence.Count() - 1));
        }

        Console.WriteLine("----");
        if (!string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine(title);
        }
        Console.WriteLine(strBuilder);
    }
    // Transpose grid
    public static T[][] Transpose<T>(T[][] grid)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;
        var result = new T[cols][];
        
        for (int i = 0; i < cols; i++)
        {
            result[i] = new T[rows];
            for (int j = 0; j < rows; j++)
                result[i][j] = grid[j][i];
        }
        
        return result;
    }
}
