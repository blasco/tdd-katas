namespace TDDKata;

public class SimpleCalculator
{
    private static readonly char[] _DefaultSeparators = [',', '\n'];

    public static bool Add(string input, out int result)
    {
        if (!IsInputStringValid(input))
        {
            result = 0;
            return false;
        }

        ParseCustomSeparator(input, out string calculationInput, out char[] separators);

        bool success = GetNumbers(calculationInput, separators, out var numbers);

        if (!success)
        {
            result = 0;
            return false;
        }

        result = numbers.Sum();
        return true;
    }

    private static void ParseCustomSeparator(string input, out string calculationInput, out char[] separators)
    {
        bool hasCustomSeparator =
            input.Length > 4 && input[0] == '/' && input[1] == '/' && input[3] == '\n';

        if (!hasCustomSeparator)
        {
            separators = _DefaultSeparators;
            calculationInput = input;
            return;
        }
        separators = [input[2]];
        calculationInput = input[4..];
    }

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