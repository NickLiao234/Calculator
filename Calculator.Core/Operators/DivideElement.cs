using System;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// 表達式除法物件
    /// </summary>
    public class DivideElement : OperatorElement
    {
        /// <summary>
        /// 初始化優先權
        /// </summary>
        public DivideElement() : base("/")
        {
            Priority = 3;
        }

        /// <summary>
        /// 運算方式
        /// </summary>
        /// <param name="firstOperand">第一運算子</param>
        /// <param name="secondOperand">第二運算子</param>
        /// <returns></returns>
        public override decimal Calculate(decimal firstOperand, decimal secondOperand)
        {
            if (secondOperand == 0)
            {
                throw new CalculateException("It can not divide by zero");
            }

            return firstOperand / secondOperand;
        }
    }
}
