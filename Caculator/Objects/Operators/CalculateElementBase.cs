using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Objects.Operators
{
    /// <summary>
    /// 表達式物件基底類別
    /// </summary>
    public abstract class CalculateElementBase
    {
        /// <summary>
        /// 顯示值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 初始化顯示值
        /// </summary>
        /// <param name="value">顯示值</param>
        public CalculateElementBase(string value)
        {
            Value = value;
        }
    }
}
