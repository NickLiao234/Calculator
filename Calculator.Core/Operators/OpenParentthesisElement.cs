using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// 左括號運算子類別
    /// </summary>
    public class OpenParentthesisElement : OperatorElement
    {
        /// <summary>
        /// 建構式初始化
        /// </summary>
        public OpenParentthesisElement() : base("(")
        {
            Priority = 10;
        }

        /// <summary>
        /// 運算方法
        /// </summary>
        /// <param name="firstOperand">第一運算元</param>
        /// <param name="secondOperand">地二運算元</param>
        /// <returns></returns>
        public override decimal Calculate(decimal firstOperand, decimal secondOperand)
        {
            throw new NotImplementedException();
        }
    }
}
