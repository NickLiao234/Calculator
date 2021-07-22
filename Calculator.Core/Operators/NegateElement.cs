using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// 正負號轉換類別
    /// </summary>
    public class NegateElement : OperatorWithOneOperandElement
    {
        /// <summary>
        /// 建構式初始化
        /// </summary>
        public NegateElement() : base("negate")
        {
            Priority = 9;
        }

        /// <summary>
        /// 計算方法
        /// </summary>
        /// <param name="firstOperand">第一運算元</param>
        /// <returns></returns>
        public override decimal Calculate(decimal firstOperand)
        {
            return 0 - firstOperand;
        }
    }
}
