namespace TDDKata.Tests
{
    public class TestSimpleCalculator
    {
        [TestCase("", 0)]
        [TestCase("3", 3)]
        [TestCase("0, 1", 1)]
        [TestCase("0,1", 1)]
        [TestCase("\n0,1", 1)]
        [TestCase("1, 2", 3)]
        [TestCase("1, 2, 3, 4, 5", 15)]
        [TestCase("1,2, 3,4, 5", 15)]
        [TestCase("1, 2 \n 5", 8)]
        public void GivenAStringInput_ThenItReturnsTheSum(string input, int expected)
        {
            var success = SimpleCalculator.Add(input, out var result);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(result, Is.EqualTo(expected));
            });
        }

        [TestCase("1,2,")]
        [TestCase("1, 2,\n")]
        [TestCase("1,2\n")]
        public void GivenAStringInputWithASeparatorAtTheEnd_ThenReturnsFalse(string input)
        {
            var success = SimpleCalculator.Add(input, out var result);
            Assert.That(success, Is.False);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//\n\n1\n2", 3)]
        public void GivenAStringInputWithCustomSeparator_ThenItReturnsTheSum(string input, int expected)
        {
            var success = SimpleCalculator.Add(input, out var result);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(result, Is.EqualTo(expected));
            });
        }
    }
}