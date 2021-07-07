using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// 表達式加法物件
    /// </summary>
    public class AddElement : OperatorElement
    {
        /// <summary>
        /// 初始化設定優先權
        /// </summary>
        public AddElement() : base("+")
        {
            Priority = 2;
        }

        /// <summary>
        /// 運算方法
        /// </summary>
        /// <param name="firstOperand">第一運算子</param>
        /// <param name="secondOperand">第二運算子</param>
        /// <returns></returns>
        public override decimal Calculate(decimal firstOperand, decimal secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
