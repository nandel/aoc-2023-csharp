namespace Solutions;

public class Day1
{
    private static readonly Dictionary<string, char> s_wordMap = new()
    {
        { "zero", '0' },
        { "one", '1' },
        { "two", '2' },
        { "three", '3' },
        { "four", '4' },
        { "five", '5' },
        { "six", '6' },
        { "seven", '7' },
        { "eight", '8' },
        { "nine", '9' }
    };

    public static int SumOfCalibrationValues(StreamReader input)
    {
        var total = 0;
        while (!input.EndOfStream)
        {
            total += ParseValue(input.ReadLine());
        }
        
        return total;
    }

    private static int ParseValue(string? line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return 0;
        }
        
        char first = default;
        char last = default;
        
        for (var i = 0; i < line.Length; i++)
        {
            var current = FetchDigit(line[i..]);
            if (current is null)
            {
                continue;
            }

            if (first == default)
            {
                first = current.Value;
            }

            last = current.Value;
        }

        var calibrationValueString = $"{first}{last}";
        var calibrationValue = int.Parse(calibrationValueString);
        
        return calibrationValue;
    }

    private static char? FetchDigit(string line)
    {
        if (char.IsDigit(line[0]))
        {
            return line[0];
        }

        foreach (var pair in s_wordMap)
        {
            if (line.StartsWith(pair.Key))
            {
                return pair.Value;
            }
        }

        return default;
    }
}