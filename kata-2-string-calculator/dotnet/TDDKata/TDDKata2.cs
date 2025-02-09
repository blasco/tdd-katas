namespace TDDKata;

public class SimpleCalculator
{
    public static bool Add(string input, out int result)
    {
        if (!IsInputStringValid(input))
        {
            result = 0;
            return false;
        }

        var separators = GetSeparators(input);

        bool success = GetNumbers(input, separators, out var numbers);

        if (!success)
        {
            result = 0;
            return false;
        }

        result = numbers.Sum();
        return true;
    }

    private static char[] GetSeparators(string input)
    {
        if (ParseCustomSeparator(input, out var separator))
        {
            return [separator];
        }
        else
        {
            return _DefaultSeparators;
        }
    }

    private static bool ParseCustomSeparator(string input, out char separator)
    {
        if (input.Length < 4 || input[0] != '/' || input[1] != '/')
        {
            separator = default;
            return false;
        }

        separator = input[2];
        return true;
    }

    private static readonly char[] _DefaultSeparators = [',', '\n'];

    private static bool IsInputStringValid(string input)
    {
        if (input.Length == 0) return true;
        var lastChar = input.Last();
        return !_DefaultSeparators.Contains(lastChar);
    }

    private static bool GetNumbers(string input, char[] separators, out IEnumerable<int> numbers)
    {
        var maybeParsedNumbers = input
            .Split(separators)
            .Select(x => x.Trim())
            .Where(static n => !string.IsNullOrWhiteSpace(n))
            .Select(static number => int.TryParse(number.Trim(), out var result) ? (int?)result : null);

        // Return false if any of the numbers could not be parsed
        if (maybeParsedNumbers.Any(static n => n == null))
        {
            numbers = [];
            return false;
        }

        numbers = maybeParsedNumbers.Select(n => n.GetValueOrDefault());
        return true;
    }
}