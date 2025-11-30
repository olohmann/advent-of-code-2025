using System.Reflection;

public static class SolverFactory
{
    public static ISolver Create(int day)
    {
        var typeName = $"Day{day:D2}";

        var type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == typeName);

        if (type == null)
            throw new Exception($"Solver for {typeName} not found");

        return (ISolver)Activator.CreateInstance(type)!;
    }
}
