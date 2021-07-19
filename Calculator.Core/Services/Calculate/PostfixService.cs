using Calculator.Core.Operators;
using Calculator.Core.Services.Calculate;
using System;
using System.Collections.Generic;

namespace Calculator.Core.Services.Calculate
{
    /// <summary>
    /// 運算後序表達式服務
    /// </summary>
    public class PostfixService : CalculateServiceBase
    { 
        /// <summary>
        /// 初始化
        /// </summary>
        public PostfixService() : base()
        {
        }

        /// <summary>
        /// 遞迴方法
        /// </summary>
        /// <param name="tree">tree</param>
        /// <param name="str">表達式初始值</param>
        /// <returns>表達式</returns>
        public override string AppendTreeNode(TreeNode tree, string str)
        {
            if (tree is null)
            {
                return str;
            }

            if (tree.Token is null)
            {
                return str;
            }

            if (tree.LeftNode is null && tree.RightNode is null)
            {
                str += tree.Token.Value;
                return str;
            }
            else
            {
                str = AppendTreeNode(tree.LeftNode, str);
                str = AppendTreeNode(tree.RightNode, str);
                str += tree.Token.Value;

                return str;
            }
        }
    }
}
