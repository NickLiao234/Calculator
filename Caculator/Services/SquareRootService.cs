using Calculator;
using System;

namespace Caculator.Services
{
    public class SquareRootService : ISquareRootService
    {
        private readonly CalculatorViewModel calculatorViewModel;

        public SquareRootService(CalculatorViewModel calculatorViewModel)
        {
            this.calculatorViewModel = calculatorViewModel;
        }
        public void SquareRoot()
        {
            var operand = Convert.ToDouble(calculatorViewModel.CurrentValue);
            var squareRootValue = Math.Sqrt(operand);
            calculatorViewModel.CurrentValue = squareRootValue.ToString();
        }
    }
}
