using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Calculate
{
    /// <summary>
    /// 計算結果
    /// </summary>
    public class CalculateResult
    {
        /// <summary>
        /// 優先權層級
        /// </summary>
        public int PriorityLevel { get; set; } = 0;

        /// <summary>
        /// TreeNode
        /// </summary>
        public TreeNode Root { get; set; }
    }
}
