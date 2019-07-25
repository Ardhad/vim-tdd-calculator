using Bogus;
using Shouldly;
using Xunit;

namespace Tdd.Calculator.Tests
{
    public class SubstractionTests
    {
        private readonly Logic.Calculator _target;
        private readonly Faker _rand;

        public SubstractionTests()
        {
            _target = new Logic.Calculator();
            _rand = new Faker();
        }

        [Fact]
        public void two_positive_numbers__first_bigger_than_second__result_is_positive_number()
        {
            int firstNumber = 7;
            int secondNumber = 5;
            int expectedResult = 2;

            int actualResult = _target.Subtract(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        [Fact]
        public void two_positive_numbers__second_bigger_than_first__result_is_negative_number()
        {
            int firstNumber = 70;
            int secondNumber = 500;
            int expectedResult = -430;

            int actualResult = _target.Subtract(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        [Fact]
        public void two_zeros__result_is_zero()
        {
            int firstNumber = 0;
            int secondNumber = 0;
            int expectedResult = 0;

            int actualResult = _target.Subtract(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(100, 0, 100)]
        [InlineData(100, 200, -100)]
        [InlineData(0, 100, -100)]
        public void two_given_numbers__result_is_correct(int firstNumber, int secondNumber, int expectedResult)
        {
            int actualResult = _target.Subtract(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }
        
        [Fact]
        public void two_minimal_ints__result_is_zero()
        {
            int firstNumber = int.MinValue;
            int secondNumber = int.MinValue;
            int expectedResult = 0;

            int actualResult = _target.Subtract(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        [Fact]
        public void CORNER_CASE_minimal_int_substract_maximal_int__result_is_1()
        {
            int firstNumber = int.MinValue;
            int secondNumber = int.MaxValue;
            int expectedResult = 1;

            int actualResult = _target.Subtract(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

    }
}