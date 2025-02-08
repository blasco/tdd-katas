namespace TDDKata;

public class SimpleCalculator
{
    public int Add(string input)
    {
        bool success = GetNumbers(input, out var numbers);

        if (numbers.Count() == 0)
        {
            return 0;
        }

        return numbers.Sum();
    }

    private static bool GetNumbers(string input, out IEnumerable<int> numbers)
    {
        numbers = input.Split([',', '\n'])
                       .Select(number => int.TryParse(number.Trim(), out var result) ? (int?)result : null)
                       .Where(n => n.HasValue)
                       .Select(static n => n.GetValueOrDefault());
        return true;
    }
}
