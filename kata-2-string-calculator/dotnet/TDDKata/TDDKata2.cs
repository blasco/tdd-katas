namespace TDDKata;

public class SimpleCalculatorInput(IEnumerable<int> numbers)
{
    public bool IsValid { get; private set; } = true;
    public IEnumerable<int> Numbers { get; private set; } = numbers;

    private static readonly char[] _DefaultSeparators = [',', '\n'];

    public static SimpleCalculatorInput Create(string input)
    {
        if (input.Length == 0)
        {
            var emptyResult = new SimpleCalculatorInput(numbers: [])
            {
                IsValid = true
            };
            return emptyResult;
        }

        ParseCustomSeparator(input, out string calculationInput, out char[] separators);

        if (!IsInputStringValid(input, separators))
        {
            var invalidResult = new SimpleCalculatorInput(numbers: [])
            {
                IsValid = false
            };
            return invalidResult;
        }

        bool success = GetNumbers(calculationInput, separators, out var numbers);
        var result = new SimpleCalculatorInput(numbers)
        {
            IsValid = success
        };
        return result;
    }

    public static implicit operator SimpleCalculatorInput(string input)
    {
        return Create(input);
    }

    private static bool IsInputStringValid(string input, char[] separators)
    {
        var lastChar = input.Last();
        return !separators.Contains(lastChar);
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
        separators = [.._DefaultSeparators, input[2]];
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
    public static bool Add(SimpleCalculatorInput input, out int result)
    {
        if (!input.IsValid)
        {
            result = 0;
            return false;
        }

        result = input.Numbers.Sum();

        return true;
    }
}