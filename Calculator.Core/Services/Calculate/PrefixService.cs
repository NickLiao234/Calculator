using Calculator.Core.Operators;
using Calculator.Core.Service.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Calculate
{
    public class PrefixService : CalculateServiceBase
    {
        public PrefixService():base()
        {
        }
        public override decimal GetCalculateResult(List<string> expression)
        {
            throw new NotImplementedException();
        }

        public override List<CalculateElementBase> GetExpressionList(List<string> expression)
        {
            throw new NotImplementedException();
        }



        public override string GetExpressionString(List<string> expression)
        {
            var listPostfix = TransferExpressionToListObject(expression);
            var expressionTreeNode = GetExpressionTreeNode(listPostfix);

            return AppendTreeNodeByPrefix(expressionTreeNode, "");
        }

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
