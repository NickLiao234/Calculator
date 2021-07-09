using Calculator.Core.Operators;
using Calculator.Core.Service.Calculate;
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
        /// 取得結果
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns>結果</returns>
        public override decimal GetCalculateResult(List<string> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得表達式物件
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns></returns>
        public override List<CalculateElementBase> GetExpressionList(List<string> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得表達式字串
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns></returns>
        public override string GetExpressionString(List<string> expression)
        {
            var listPostfix = GetValidExpression(expression);
            var expressionTreeNode = GetExpressionTreeNode(listPostfix);

            return AppendTreeNodeByPrefix(expressionTreeNode, "");
        }

        /// <summary>
        /// 遞迴方法
        /// </summary>
        /// <param name="tree">tree</param>
        /// <param name="str">表達式初始值</param>
        /// <returns>表達式</returns>
        private string AppendTreeNodeByPrefix(TreeNode tree, string str)
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
                str = AppendTreeNodeByPrefix(tree.LeftNode, str);
                str = AppendTreeNodeByPrefix(tree.RightNode, str);
                
                return str;
            }
        }
    }
}
