using System;
using Bogus;
using Shouldly;
using Xunit;

namespace Tdd.Calculator.Tests
{
    public class AddingTests
    {
        private readonly Logic.Calculator _target;
        private readonly Faker _rand;

        public AddingTests()
        {
            _target = new Logic.Calculator();
            _rand = new Faker();
        }

        /// <summary>
        /// First partition of data - zero.
        /// </summary>
        [Fact]
        public void add_two_zeros__result_is_zero()
        {
            int firstNumber = 0;
            int secondNumber = 0;
            int expectedResult = 0;

            int actualResult = _target.Add(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        /// <summary>
        /// Second partition of data - two numbers greater than zero. 
        /// </summary>
        [Fact]
        public void two_positive_integers__result_is_positive_integer()
        {
            int firstNumber = 5;
            int secondNumber = 7;
            int expectedResult = 12;

            int actualResult = _target.Add(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        /// <summary>
        /// Third partition of data - two numbers lower than zero. 
        /// </summary>
        [Fact]
        public void two_negative_integers__result_is_negative_integer()
        {
            int firstNumber = -50;
            int secondNumber = -7;
            int expectedResult = -57;

            int actualResult = _target.Add(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        /// <summary>
        /// Mix of positive & negative inputs
        /// </summary>
        [Fact]
        public void one_positive_one_negative_integer__positive_bigger_than_abs_of_negative__result_is_positive_integer()
        {
            int firstNumber = 50;
            int secondNumber = -7;
            int expectedResult = 43;

            int actualResult = _target.Add(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        /// <summary>
        /// Mix of positive & negative inputs
        /// </summary>
        [Fact]
        public void one_positive_one_negative_integer__abs_of_negative_bigger_than_positive__result_is_negative_integer()
        {
            int firstNumber = 50;
            int secondNumber = -70;
            int expectedResult = -20;

            int actualResult = _target.Add(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        /// <summary>
        /// Tests with zero - possible corner case.
        /// </summary>
        [Theory]
        [InlineData(0, 10, 10)]
        [InlineData(10, 0, 10)]
        [InlineData(-10, 0, -10)]
        [InlineData( 0, -10, -10)]

        public void add_zero_and_another_number__result_equals_another_number(int firstNumber, int secondNumber, int expectedResult)
        {
            int actualResult = _target.Add(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        /// <summary>
        /// Tests for random positive integers.
        /// </summary>
        [Fact]
        public void two_random_positive_integers__result_is_positive_integer()
        {
            int firstNumber = _rand.Random.Number(0);
            int secondNumber = _rand.Random.Number(0);
            int expectedResult = firstNumber + secondNumber;

            int actualResult = _target.Add(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }
        
        /// <summary>
        /// Tests for random negative integers.
        /// </summary>
        [Fact]
        public void two_random_negative_integers__result_is_negative_integer_smaller_than_both_of_them()
        {
            int firstNumber = _rand.Random.Int(-4000, -1);
            int secondNumber = _rand.Random.Int(-4000, -1);
            int expectedResult = firstNumber + secondNumber;

            int actualResult = _target.Add(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }
    }
}
