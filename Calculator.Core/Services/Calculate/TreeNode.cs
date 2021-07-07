using Calculator.Core.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Calculate
{
    /// <summary>
    /// Tree
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// Token
        /// </summary>
        public CalculateElementBase Token { get; set; }

        /// <summary>
        /// 左子樹
        /// </summary>
        public TreeNode LeftNode { get; set; }

        /// <summary>
        /// 右子樹
        /// </summary>
        public TreeNode RightNode { get; set; }

        /// <summary>
        /// 空建構式
        /// </summary>
        public TreeNode()
        {
        }

        /// <summary>
        /// 建構式初始化token
        /// </summary>
        /// <param name="token">token</param>
        public TreeNode(CalculateElementBase token)
        {
            Token = token;
        }
    }
}
