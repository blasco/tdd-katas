namespace TDDKata;


public class SimpleCalculatorInput
{
    public bool IsValid;
    public IEnumerable<int> Numbers;

    private static readonly char[] _DefaultSeparators = [',', '\n'];

    private SimpleCalculatorInput(bool isValid, IEnumerable<int> numbers)
    {
        Numbers = numbers;
    }

    public static SimpleCalculatorInput Create(string input)
    {
        if (!IsInputStringValid(input))
        {
            return new SimpleCalculatorInput(isValid: false, numbers: []);
        }

        ParseCustomSeparator(input, out string calculationInput, out char[] separators);

        bool success = GetNumbers(calculationInput, separators, out var numbers);
        return new SimpleCalculatorInput(isValid: success, numbers: numbers);
    }

    private static bool IsInputStringValid(string input)
    {
        if (input.Length == 0) return true;
        var lastChar = input.Last();
        return !_DefaultSeparators.Contains(lastChar);
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

    private static bool GetNumbers(string input, char[] separators, out IEnumerable<int> numbers)
    {
        var maybeParsedNumbers = input
            .Split(separators)
            .Select(x => x.Trim())
            .Where(static n => !string.IsNullOrWhiteSpace(n))
            .Select(static number => int.TryParse(number.Trim(), out var result) ? (int?)result : null);

        if (maybeParsedNumbers.Any(static n => n == null))
        {
            numbers = [];
            return false;
        }

        numbers = maybeParsedNumbers.Select(n => n.GetValueOrDefault());
        return true;
    }
}

public class SimpleCalculator
{
    public static bool Add(string input, out int result)
    {

        var calculatorInput = SimpleCalculatorInput.Create(input);

        if (!calculatorInput.IsValid)
        {
            result = 0;
            return false;
        }

        result = calculatorInput.Numbers.Sum();

        return true;
    }

}