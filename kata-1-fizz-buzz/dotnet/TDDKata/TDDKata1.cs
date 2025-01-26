namespace TDDKata1;

public interface IFizzBuzzStrategy
{
    bool CanHandle(int number);
    string Handle(int number);
}

public class DefaultStrategy : IFizzBuzzStrategy
{
    public bool CanHandle(int number) => true;
    public string Handle(int number) => $"{number}";
}

public class MultipleOfThreeStrategy : IFizzBuzzStrategy
{
    public bool CanHandle(int number) => number % 3 == 0;
    public string Handle(int number) => "Fizz";
}

public class MultipleOfFiveStrategy : IFizzBuzzStrategy
{
    public bool CanHandle(int number) => number % 5 == 0;
    public string Handle(int number) => "Buzz";
}

public class MultipleOfThreeAndFiveStrategy : IFizzBuzzStrategy
{
    public bool CanHandle(int number) => number % 3 == 0 && number % 5 == 0;
    public string Handle(int number) => "FizzBuzz";
}

public class Kata1
{
    private static List<IFizzBuzzStrategy> _strategies = [
        new MultipleOfThreeAndFiveStrategy(),
        new MultipleOfThreeStrategy(),
        new MultipleOfFiveStrategy(),
    ];

    private static IFizzBuzzStrategy DefaultStrategy = new DefaultStrategy();
    
    public static string FizzBuzzSimple(int number) {
        return $"{number}";
    }

    public static string FizzBuzz(int number)
    {
        foreach (IFizzBuzzStrategy strategy in _strategies)
        {
            if (strategy.CanHandle(number))
            {
                return strategy.Handle(number);
            }
        }
        return DefaultStrategy.Handle(number);
    }
}
