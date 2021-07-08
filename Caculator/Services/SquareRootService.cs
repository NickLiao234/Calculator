using Calculator;
using System;

namespace Caculator.Services
{
    /// <summary>
    /// 開根號服務
    /// </summary>
    public class SquareRootService : ISquareRootService
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        private readonly CalculatorViewModel calculatorViewModel;

        /// <summary>
        /// 初始化注入服務
        /// </summary>
        /// <param name="calculatorViewModel">viewmodel</param>
        public SquareRootService(CalculatorViewModel calculatorViewModel)
        {
            this.calculatorViewModel = calculatorViewModel;
        }

        /// <summary>
        /// 開根號方法
        /// </summary>
        public void SquareRoot()
        {
            var operand = Convert.ToDouble(calculatorViewModel.CurrentValue);
            if (operand < 0)
            {
                throw new Exception("無法執行開根號");
            }
            var squareRootValue = Math.Sqrt(operand);
            calculatorViewModel.CurrentValue = squareRootValue.ToString();
        }
    }
}
