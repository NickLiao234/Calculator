using Calculator.Core.Operators;
using Calculator.Core.Services.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Calculate
{
    /// <summary>
    /// 前序表達式服務
    /// </summary>
    public class PrefixService : CalculateServiceBase
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public PrefixService() : base()
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
                str += tree.Token.Value;
                str = AppendTreeNode(tree.LeftNode, str);
                str = AppendTreeNode(tree.RightNode, str);
                
                return str;
            }
        }
    }
}
