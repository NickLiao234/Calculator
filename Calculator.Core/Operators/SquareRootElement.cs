using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// 開根號類別
    /// </summary>
    public class SquareRootElement : OperatorWithOneOperandElement
    {
        /// <summary>
        /// 建構式初始化
        /// </summary>
        public SquareRootElement() : base("²√")
        {
            Priority = 9;
        }

        /// <summary>
        /// 計算方法
        /// </summary>
        /// <param name="firstOperand">運算元</param>
        /// <returns>decimal</returns>
        public override decimal Calculate(decimal firstOperand)
        {
            if (firstOperand < 0)
            {
                throw new CalculateException("It cant not SquareRoot");
            }

            var squareRootValue = Math.Sqrt(Convert.ToDouble(firstOperand));
            return Convert.ToDecimal(squareRootValue);
        }
    }
}
