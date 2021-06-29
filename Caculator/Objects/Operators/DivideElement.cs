using Caculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects.Operators
{
    /// <summary>
    /// 表達式除法物件
    /// </summary>
    public class DivideElement : OperatorElement
    {
        /// <summary>
        /// 初始化優先權
        /// </summary>
        /// <param name="value">顯示值</param>
        public DivideElement(string value) : base(value)
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
                throw new Exception("無法執行除法");
            }

            return firstOperand / secondOperand;
        }
    }
}
