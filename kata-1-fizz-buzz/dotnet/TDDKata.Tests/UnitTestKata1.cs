namespace TDDKata1.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(1, "1")]
    [TestCase(-1, "-1")]
    public void GivenNumber_ReturnsStringVersion(int given, string expected)
    {
        string result = Kata1.FizzBuzz(given);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(3, "Fizz")]
    [TestCase(9, "Fizz")]
    public void GivenMultipleOfThree_ThenItReturnsFizz(int given, string expected)
    {
        string result = Kata1.FizzBuzz(3);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(5, "Buzz")]
    [TestCase(10, "Buzz")]
    public void GivenMultipleOfFive_ThenItRetunrsBuzz(int given, string expected)
    {
        string result = Kata1.FizzBuzz(given);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(15, "FizzBuzz")]
    [TestCase(30, "FizzBuzz")]
    public void GivenMultipleOfThreeAndFive_ThenItReturnsFizzBuzz(int given, string expected)
    {
        string result = Kata1.FizzBuzz(given);
        Assert.That(result, Is.EqualTo(expected));
    }

}