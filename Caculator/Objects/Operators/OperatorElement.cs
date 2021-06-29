using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects.Operators
{
    /// <summary>
    /// 運算元類別
    /// </summary>
    public abstract class OperatorElement : CalculateElementBase
    {
        /// <summary>
        /// 優先權
        /// </summary>
        public int Priority { get; protected set; }

        /// <summary>
        /// 初始化呼叫基底類別建構子
        /// </summary>
        /// <param name="value">顯示值</param>
        public OperatorElement(string value) : base(value)
        {
        }

        /// <summary>
        /// 抽象方法
        /// </summary>
        /// <param name="firstOperand">第一運算子</param>
        /// <param name="secondOperand">第二運算子</param>
        /// <returns></returns>
        public abstract decimal Calculate(decimal firstOperand, decimal secondOperand);
    }
}
