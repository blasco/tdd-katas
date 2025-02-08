namespace TDDKata.Tests
{
    public class TestSimpleCalculator
    {
        [TestCase("", 0)]
        [TestCase("3", 3)]
        [TestCase("0, 1", 1)]
        [TestCase("1, 2", 3)]
        [TestCase("1, 2, 3, 4, 5", 15)]
        [TestCase("1, 2 \n 5", 8)]
        public void GivenAStringInput_ItReturnsTheExpectedResult(string input, int expected)
        {
            var calculator = new SimpleCalculator();
            var result = calculator.Add(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}