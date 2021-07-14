using Calculator.Core.Services.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// 括號物件
    /// </summary>
    public class OpenCloseElement : CalculateElementBase
    {
        /// <summary>
        /// 優先權層級
        /// </summary>
        public int PriorityLevel { get; set; }

        /// <summary>
        /// 建構式初始化
        /// </summary>
        /// <param name="value">value</param>
        public OpenCloseElement(string value) : base(value)
        {
        }

        /// <summary>
        /// 複寫加入元素至tree方法
        /// </summary>
        /// <param name="result">運算結果物件</param>
        /// <returns>結果物件</returns>
        public override CalculateResult AppendElement(CalculateResult result)
        {
            result.PriorityLevel += PriorityLevel;

            return result;
        }
    }
}
