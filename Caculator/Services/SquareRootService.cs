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
        private readonly IEditViewModelService editViewModelService;

        /// <summary>
        /// 初始化注入服務
        /// </summary>
        /// <param name="calculatorViewModel">viewmodel</param>
        public SquareRootService(
            CalculatorViewModel calculatorViewModel,
            IEditViewModelService editViewModelService)
        {
            this.calculatorViewModel = calculatorViewModel;
            this.editViewModelService = editViewModelService;
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
            editViewModelService.SetCurrentValue(squareRootValue.ToString());
        }
    }
}
