using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// 右中括號運算子類別
    /// </summary>
    public class CloseBracketElement : OpenCloseElement
    {
        /// <summary>
        /// 建構式初始化
        /// </summary>
        public CloseBracketElement() : base("]")
        {
            PriorityLevel = -10;
        }
    }
}
