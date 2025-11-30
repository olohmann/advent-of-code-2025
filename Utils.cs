// Additional utility methods you can extend

public static class Utils
{
    // Direction helpers for grid navigation
    public static readonly (int dx, int dy)[] Directions4 = 
        [(0, 1), (1, 0), (0, -1), (-1, 0)]; // Right, Down, Left, Up
    
    public static readonly (int dx, int dy)[] Directions8 = 
        [(0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1)];
    
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
