#!/bin/bash
DAY=$(printf "%02d" $1)

cat > Days/Day$DAY.cs << SOLVER
public class Day$DAY : SolverBase
{
    public override string Part1(string input)
    {
        var lines = Lines(input);
        
        // TODO: Implement part 1
        
        return "0";
    }
    
    public override string Part2(string input)
    {
        var lines = Lines(input);
        
        // TODO: Implement part 2
        
        return "0";
    }
}
SOLVER

touch Inputs/day$DAY.txt

echo "Created Day $DAY solver and input file"
echo "Run with: dotnet run $1"
