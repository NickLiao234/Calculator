using Caculator.Objects.Operators;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 計算表達式服務
    /// </summary>
    public class CalculateExpressionService : ICalculateExpressionService
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="viewModel">viewModel</param>
        public CalculateExpressionService(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// 取得表達式計算結果
        /// </summary>
        /// <returns>運算結果</returns>
        public decimal GetResult()
        {
            var expression = new Stack<CalculateElementBase>(viewModel.ExpressionStack);

            decimal result = 0;

            result = Calculate(null, null, expression).Value;

            return result;
        }

        /// <summary>
        /// 表達式計算方法
        /// </summary>
        /// <param name="firstOperand">第一運算元</param>
        /// <param name="secondOperand">第二運算元</param>
        /// <param name="expression">表達式堆疊</param>
        /// <returns></returns>
        private decimal? Calculate(decimal? firstOperand, decimal? secondOperand, Stack<CalculateElementBase> expression)
        {
            if (expression.Count == 0)
            {
                return secondOperand;
            }

            if (!secondOperand.HasValue)
            {
                secondOperand = Convert.ToDecimal(expression.Pop().Value);
                if (expression.Count == 0)
                {
                    return secondOperand;
                }
            }

            var operatorElement = (OperatorElement)expression.Pop();
            firstOperand = Convert.ToDecimal(expression.Pop().Value);
            var nextOperator = (expression.Count == 0) ? null : (OperatorElement)expression.Peek();

            if (nextOperator is null)
            {
                return operatorElement.Calculate(firstOperand.Value, secondOperand.Value);
            }

            if (operatorElement.Priority >= nextOperator.Priority)
            {
                return Calculate(null, operatorElement.Calculate(firstOperand.Value, secondOperand.Value), expression);
            }
            else
            {
                return operatorElement.Calculate(Calculate(null, firstOperand, expression).Value, secondOperand.Value);
            }
        }
    }
}
