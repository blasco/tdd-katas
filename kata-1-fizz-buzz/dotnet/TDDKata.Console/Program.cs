using TDDKata1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter a number:");
        var input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        int number = int.Parse(input);

        string result = Kata1.FizzBuzz(number);

        Console.WriteLine("Result:");
        Console.WriteLine(result);
    }
}