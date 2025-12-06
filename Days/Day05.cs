using System.Data.Common;

public class Day05 : SolverBase
{
    private bool IdInRange(long id, (long, long) range)
    {
        return id >= range.Item1 && id <= range.Item2;
    }

    public override string Part1(string input)
    {
        var lines = Lines(input);
        var ingredientIdRanges = new List<(long, long)>();
        var availableIngredientIds = new List<long>();
        foreach(var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            if (line.Contains('-'))
            {
                var values = line.Split('-').Select(_ => long.Parse(_)).ToArray();
                ingredientIdRanges.Add((values[0], values[1]));
                continue;
            }
        
            availableIngredientIds.Add(long.Parse(line));
        }
        
        //Utils.PrintSequence(ingredientIdRanges, "Ingredient ID Ranges");
        //Utils.PrintSequence(availableIngredientIds, "Available Ingredient IDs");


        var freshIngredients = new List<long>();
        foreach(var id in availableIngredientIds)
        {
            if (ingredientIdRanges.Any(_ => IdInRange(id, _)))
            {
                freshIngredients.Add(id);
            }
        }

        //Utils.PrintSequence(freshIngredients, "Fresh Ingredients");
        
        return $"{freshIngredients.Count}";
    }

    public override string Part2(string input)
    {
        var lines = Lines(input);
        var ingredientIdRanges = new List<(long Start, long End)>();
        var availableIngredientIds = new List<long>();
        foreach(var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            if (line.Contains('-'))
            {
                var values = line.Split('-').Select(_ => long.Parse(_)).ToArray();
                ingredientIdRanges.Add((values[0], values[1]));
                continue;
            }
        
            availableIngredientIds.Add(long.Parse(line));
        }

        var sortedRanges = ingredientIdRanges.OrderBy(_ => _.Start).ToArray();
        var merged = new List<(long Start, long End)>() { sortedRanges[0] };

        foreach(var (start, end) in sortedRanges.Skip(1))
        {
            var last = merged[^1];
            if (start <= last.End + 1)
            {
                merged[^1] = (last.Start, Math.Max(last.End, end));
            }
            else
            {
                merged.Add((start, end));
            }
        }


        return $"{merged.Sum(r => r.End - r.Start + 1)}";
    }
}
