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
    /// 中序表達式服務
    /// </summary>
    public class InfixService : CalculateServiceBase
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public InfixService() : base()
        {
        }

        /// <summary>
        /// 計算結果
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns>結果</returns>
        public override decimal GetCalculateResult(List<string> expression)
        {
            var expresionListObject = GetExpressionList(expression);

            var tempOperandStack = new Stack<decimal>();

            foreach (var element in expresionListObject)
            {
                if (IsOperand(element))
                {
                    var value = Convert.ToDecimal(element.Value);
                    tempOperandStack.Push(value);
                }
                else
                {
                    var op2 = tempOperandStack.Pop();
                    var op1 = tempOperandStack.Pop();
                    var thisOperator = (OperatorElement)element;
                    var result = thisOperator.Calculate(op1, op2);
                    tempOperandStack.Push(result);
                }
            }

            return tempOperandStack.Pop();
        }

        /// <summary>
        /// 取得表達式
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns></returns>
        public override List<CalculateElementBase> GetExpressionList(List<string> expression)
        {
            var result = new List<CalculateElementBase>();
            var listObject = GetValidExpression(expression);
            var tempStack = new Stack<OperatorElement>();

            foreach (var item in listObject)
            {
                if (IsOperand(item))
                {
                    result.Add(item);
                    continue;
                }

                if (item.Value == ")")
                {
                    do
                    {
                        var temp = tempStack.Pop();

                        if (temp.Value == "(")
                        {
                            break;
                        }

                        result.Add(temp);
                    }
                    while (true);
                }
                else
                {
                    if (((OperatorElement)item).Priority > GetStackPriority(tempStack))
                    {
                        var element = (OperatorElement)item;
                        tempStack.Push(element);
                    }
                    else
                    {
                        while (((OperatorElement)item).Priority <= GetStackPriority(tempStack))
                        {
                            var temp = tempStack.Pop();
                            result.Add(temp);
                        }

                        var element = (OperatorElement)item;
                        tempStack.Push(element);
                    }
                }
            }

            while (tempStack.Count != 0)
            {
                var temp = tempStack.Pop();
                result.Add(temp);
            }

            return result;
        }

        /// <summary>
        /// 取得表達式字串
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns>字串</returns>
        public override string GetExpressionString(List<string> expression)
        {
            var listPostfix = GetValidExpression(expression);
            var expressionTreeNode = GetExpressionTreeNode(listPostfix);

            return AppendTreeNodeByInfix(expressionTreeNode, "");
        }

        /// <summary>
        /// 遞迴方法
        /// </summary>
        /// <param name="tree">tree</param>
        /// <param name="str">表達式初始值</param>
        /// <returns>表達式</returns>
        private string AppendTreeNodeByInfix(TreeNode tree, string str)
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
                str = AppendTreeNodeByInfix(tree.LeftNode, str);
                str += tree.Token.Value;
                str = AppendTreeNodeByInfix(tree.RightNode, str);

                return str;
            }
        }
    }
}
