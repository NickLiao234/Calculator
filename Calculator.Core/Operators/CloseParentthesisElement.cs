using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// 右括號運算子類別
    /// </summary>
    public class CloseParentthesisElement : OperatorElement
    {
        /// <summary>
        /// 建構式初始化
        /// </summary>
        public CloseParentthesisElement() : base(")")
        {
            Priority = 10;
        }

        /// <summary>
        /// 執行方法
        /// </summary>
        /// <param name="firstOperand">第一運算子</param>
        /// <param name="secondOperand">第二運算子</param>
        /// <returns></returns>
        public override decimal Calculate(decimal firstOperand, decimal secondOperand)
        {
            throw new NotImplementedException();
        }
    }
}
