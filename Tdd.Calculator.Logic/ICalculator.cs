using System;

namespace Tdd.Calculator.Logic
{
    public interface ICalculator
    {
        int Subtract(int firstNumber, int secondNumber);
        int Multiply(int firstNumber, int secondNumber);
        double Divide(int firstNumber, int secondNumber);
        int Add(int firstNumber, int secondNumber);
    }
}
