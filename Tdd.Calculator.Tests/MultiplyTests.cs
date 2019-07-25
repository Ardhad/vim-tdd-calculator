using Bogus;
using Shouldly;
using Xunit;

namespace Tdd.Calculator.Tests
{
    public class MultiplyTests
    {
        private readonly Logic.Calculator _target;
        private readonly Faker _rand;

        public MultiplyTests()
        {
            _target = new Logic.Calculator();
            _rand = new Faker();
        }

        [Fact]
        public void any_number_multiplied_by_0__result_is_zero()
        {
            int firstNumber = 0;
            int secondNumber = _rand.Random.Int();
            int expectedResult = 0;

            int actualResult = _target.Multiply(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        [Fact]
        public void any_number_multiplied_by_1__result_is_given_number()
        {
            int firstNumber = 1;
            int secondNumber = _rand.Random.Int();
            int expectedResult = secondNumber;

            int actualResult = _target.Multiply(firstNumber, secondNumber);

            actualResult.ShouldBe(expectedResult);
        }

        [Fact]
        public void two_random_numbers__result_is_correct()
        {
            int firstNumber = _rand.Random.Int(-5000, 5000);
            int secondNumber = _rand.Random.Int(-5000, 5000);
            int expectedNumber = firstNumber * secondNumber;

            int actualResult = _target.Multiply(firstNumber, secondNumber);
            
            actualResult.ShouldBe(expectedNumber);
        }

        [Fact]
        public void first_number_positive_second_negative__result_is_negative()
        {
            int firstNumber = _rand.Random.Int(1, 5000);
            int secondNumber = _rand.Random.Int(-5000, -1);

            int actualResult = _target.Multiply(firstNumber, secondNumber);

            (actualResult < 0).ShouldBeTrue($"Result was {actualResult} for given numbers: {firstNumber}, {secondNumber}");
        }

        [Fact]
        public void first_number_negative_second_positive__result_is_negative()
        {
            int firstNumber = _rand.Random.Int(-5000, -1); 
            int secondNumber = _rand.Random.Int(1, 5000);

            int actualResult = _target.Multiply(firstNumber, secondNumber);
            
            (actualResult < 0).ShouldBeTrue($"Result was {actualResult} for given numbers: {firstNumber}, {secondNumber}");
        }

        [Fact]
        public void two_given_numbers__multiplying_is_commutative()
        {
            int firstNumber = 10;
            int secondNumber = 24;

            int actualResult1 = _target.Multiply(firstNumber, secondNumber);
            int actualResult2 = _target.Multiply(secondNumber, firstNumber);

            actualResult2.ShouldBe(actualResult1);
        }
    }
}