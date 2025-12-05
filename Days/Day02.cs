public class Day02 : SolverBase
{
    public override string Part1(string input)
    {
        var lines = Lines(input);

        var line = lines[0];
        var idRanges = line.Split(',');

        var invalidIDs = new List<string>() {};
        foreach(var idRange in idRanges)
        {
            var startEnd = idRange.Split('-');
            var start = long.Parse(startEnd[0]);
            var end = long.Parse(startEnd[1]);

            for(var i = start; i <= end; i++)
            {
                var iStr = i.ToString();
                var mid = iStr.Length / 2;

                var left = iStr.Substring(0, mid);
                var right = iStr.Substring(mid);
                if (left == right)
                {
                    invalidIDs.Add(iStr); 
                }
            }
        }

        Console.WriteLine(string.Join(';', invalidIDs));
        var result = invalidIDs.Select(_ => long.Parse(_)).Sum();

        // TODO: Implement part 1
        
        return $"{result}";
    }
    
    public override string Part2(string input)
    {
        var lines = Lines(input);

        var line = lines[0];
        var idRanges = line.Split(',');

        var invalidIDs = new List<string>() {};
        foreach(var idRange in idRanges)
        {
            var startEnd = idRange.Split('-');
            var start = long.Parse(startEnd[0]);
            var end = long.Parse(startEnd[1]);

            Console.WriteLine($"range: {idRange}");
            for(var i = start; i <= end; i++)
            {
                var id = i.ToString();
                var length = id.Length;
                for (int patternLen = 1; patternLen <= length / 2; patternLen++)
                {
                    if (length % patternLen != 0)
                        continue;
                        
                    string pattern = id.Substring(0, patternLen);
                    bool isRepeating = true;
                    
                    for (int k = patternLen; k < length; k += patternLen)
                    {
                        if (id.Substring(k, patternLen) != pattern)
                        {
                            isRepeating = false;
                            break;
                        }
                    }
                    
                    if (isRepeating)
                    {
                        Console.WriteLine($"{id} - repeating");
                        invalidIDs.Add(id);
                        break;
                    }
                }
            }
        }

        var result = invalidIDs.Select(_ => long.Parse(_)).Sum();

        return $"{result}"; 
    }
}
