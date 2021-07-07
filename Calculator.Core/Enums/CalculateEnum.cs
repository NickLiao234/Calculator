using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Enums
{
    /// <summary>
    /// 表達式排序Enum
    /// </summary>
    public enum CalculateEnum
    {
        /// <summary>
        /// 前序
        /// </summary>
        prefix,

        /// <summary>
        /// 中序
        /// </summary>
        infix,

        /// <summary>
        /// 後序
        /// </summary>
        postfix
    }
}
