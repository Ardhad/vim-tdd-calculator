namespace Tdd.Calculator.Logic
{
    public class Calculator : ICalculator
    {
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public int Subtract(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public int Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;

        }

        public double Divide(int firstNumber, int secondNumber)
        {
            return (double)firstNumber / secondNumber;
        }
    }
}