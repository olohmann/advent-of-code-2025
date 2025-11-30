public interface ISolver
{
    string Part1(string input);
    string Part2(string input);
}

public abstract class SolverBase : ISolver
{
    public abstract string Part1(string input);
    public abstract string Part2(string input);
    
    // Helpers available to all solvers
    protected static string[] Lines(string input) => 
        input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
    
    protected static int[] Ints(string input) => 
        Lines(input).Select(int.Parse).ToArray();
    
    protected static long[] Longs(string input) => 
        Lines(input).Select(long.Parse).ToArray();
    
    protected static int[][] IntGrid(string input) =>
        Lines(input).Select(line => line.Select(c => c - '0').ToArray()).ToArray();
    
    protected static char[][] CharGrid(string input) =>
        Lines(input).Select(line => line.ToCharArray()).ToArray();
    
    protected static Dictionary<TKey, int> Count<TKey>(IEnumerable<TKey> items) where TKey : notnull
    {
        var counts = new Dictionary<TKey, int>();
        foreach (var item in items)
            counts[item] = counts.GetValueOrDefault(item) + 1;
        return counts;
    }
}
