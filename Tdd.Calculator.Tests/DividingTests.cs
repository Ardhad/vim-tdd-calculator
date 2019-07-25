using System;
using Bogus;
using Shouldly;
using Xunit;

namespace Tdd.Calculator.Tests
{
    public class DividingTests
    {
        private readonly Logic.Calculator _target;
        private readonly Faker _rand;

        public DividingTests()
        {
            _target = new Logic.Calculator();
            _rand = new Faker();
        }

        [Fact]
        public void two_even_numbers__first_is_multiplier_of_second__result_is_integer()
        {
            int firstNumber = 6;
            int secondNumber = 2;
            double expectedResult = 3;

            var actualResult = _target.Divide(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        [Fact]
        public void first_number_is_zero__result_is_zero()
        {
            int firstNumber = 0;
            int secondNumber = 2;
            double expectedResult = 0;

            var actualResult = _target.Divide(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(-50, 2, -25d)]
        [InlineData(50, -2, -25d)]
        public void one_of_numbers_is_negative__result_is_negative(int firstNumber, int secondNumber, double expectedResult)
        {
            var actualResult = _target.Divide(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(-50, -2, 25d)]
        [InlineData(50, 2, 25d)]
        public void both_numbers_are_positive_or_negative__result_is_positive(int firstNumber, int secondNumber, double expectedResult)
        {
            var actualResult = _target.Divide(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        [Fact]
        public void two_even_numbers__first_is_NOT_multiplier_of_second___result_is_not_integer()
        {
            int firstNumber = 3;
            int secondNumber = 2;
            double expectedResult = 1.5;

            var actualResult = _target.Divide(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        [Fact]
        public void divisor_is_zero__method_DO_NOT_throws_exception()
        {
            int firstNumber = 3;
            int secondNumber = 0;
            Should.NotThrow(() => _target.Divide(firstNumber, secondNumber));
        }

        [Fact]
        public void divisor_is_zero__method_returns_infinity()
        {
            int firstNumber = 3;
            int secondNumber = 0;
            double expectedResult = double.PositiveInfinity;
            var actualResult = _target.Divide(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }
    }
}