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
    public class CloseParentthesisElement : OpenCloseElement
    {
        /// <summary>
        /// 建構式初始化
        /// </summary>
        public CloseParentthesisElement() : base(")")
        {
            PriorityLevel = -10;
        }
    }
}
