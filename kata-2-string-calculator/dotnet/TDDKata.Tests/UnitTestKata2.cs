namespace TDDKata.Tests
{
    public class TestSimpleCalculator
    {
        [Test]
        public void GivenASimpleCalculatorInput_WhenAddIsCalled_ItReturnsTheSum()
        {
            var input = new SimpleCalculatorInput([1, 2, 3]);
            var success = SimpleCalculator.Add(input, out var result);
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(result, Is.EqualTo(6));
            });
        }

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

    public class TestSimpleCalculatorInput
    {

        [Test]
        public void GivenAnEmptyInputString_ThenItReturnsIsValidTrueAndEmptyNumbers()
        {
            var input = SimpleCalculatorInput.Create("");
            Assert.Multiple(() =>
            {
                Assert.That(input.IsValid, Is.True);
                Assert.That(input.Numbers, Is.Empty);
            });
        }


        [TestCase("1,2,3", new int[] { 1, 2, 3 })]
        [TestCase("1\n2\n3", new int[] { 1, 2, 3 })]
        [TestCase("1\n2,3", new int[] { 1, 2, 3 })]
        public void GivenAStringUsingDefaultSeparators_ThenItReturnsIsValidAndTheNumbers(
            string inputString, int[] numbers)
        {
            var input = SimpleCalculatorInput.Create(inputString);
            Assert.Multiple(() =>
            {
                Assert.That(input.IsValid, Is.True);
                Assert.That(input.Numbers, Is.EqualTo(numbers));
            });
        }

        [TestCase("1,2,3,")]
        [TestCase("1,2,3\n")]
        [TestCase("//;\n1,2;3;")]
        public void GivenAStringWithASeparatorAtTheEnd_ThenItReturnsIsValidFalse(
            string inputString)
        {
            var input = SimpleCalculatorInput.Create(inputString);
            Assert.Multiple(() =>
            {
                Assert.That(input.IsValid, Is.False);
                Assert.That(input.Numbers, Is.Empty);
            });
        }

        [TestCase("//;\n1;2;3", new int[] { 1, 2, 3 })]
        [TestCase("//;\n1,2;3", new int[] { 1, 2, 3 })]
        public void GivenACustomSeparator_ThenItReturnsTheExpectedNumbers(
            string inputString, int[] numbers)
        {
            var input = SimpleCalculatorInput.Create(inputString);
            Assert.Multiple(() =>
            {
                Assert.That(input.IsValid, Is.True);
                Assert.That(input.Numbers, Is.EqualTo(numbers));
            });
        }
    }
}