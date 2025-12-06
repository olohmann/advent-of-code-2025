public class Day03 : SolverBase
{
    private int FindAnyMaxValues(int index,int[] input, int maxValue)
    {
        if (index >= input.Length)
        {
            return maxValue;
        }

        for (var i = index; i < input.Length; i++)
        {
            for (var k = i + 1; k < input.Length; k++)
            {
                var value = int.Parse($"{input[i]}{input[k]}");
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }
        }

        return FindAnyMaxValues(index + 1, input, maxValue);
    }

    public override string Part1(string input)
    {
        var lines = Lines(input);
        var highestBatteriesList = new List<int>(); 
        foreach (var bank in lines)
        {
            var batteries = bank.ToCharArray().Select(_ => int.Parse(_.ToString())).ToArray();
            var highestBatteryCombination = FindAnyMaxValues(0, batteries, 0);
            // Console.WriteLine($"{highestBatteryCombination}");
            highestBatteriesList.Add(highestBatteryCombination);
        }
        
        return $"{highestBatteriesList.Sum()}";
    }
    
    public override string Part2(string input)
    {
        var lines = Lines(input);
        var highestBatteriesList = new List<long>(); 
        foreach (var bank in lines)
        {
            var stack = new Stack<int>();
            var batteries = bank.ToCharArray().Select(_ => int.Parse(_.ToString())).ToArray();
            var toRemove = batteries.Length - 12;
            foreach(var battery in batteries)
            {
                while (stack.Count > 0 && toRemove > 0 && stack.First() < battery)
                {
                    stack.Pop();
                    toRemove -= 1;
                }  

                stack.Push(battery);
            }

            while (toRemove > 0)
            {
                stack.Pop();
                toRemove -= 1;
            }

            highestBatteriesList.Add(long.Parse(string.Join("", stack.Reverse())));
        }

        foreach (var highestBatteries in highestBatteriesList)
        {
            Console.WriteLine(highestBatteries);
        }
        
        return $"{highestBatteriesList.Sum()}";
    }
}
