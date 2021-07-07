using Calculator.Core.Operators;
using Calculator.Core.Services.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Core.Service.Calculate
{
    public abstract class CalculateServiceBase
    {
        /// <summary>
        /// 字元類別對應表
        /// </summary>
        private Dictionary<string, CalculateElementBase> map;

        public CalculateServiceBase()
        {
            initMap();
        }

        /// <summary>
        /// 初始化對應表
        /// </summary>
        private void initMap()
        {
            map = new Dictionary<string, CalculateElementBase>();
            map.Add("+", new AddElement());
            map.Add("-", new SubElement());
            map.Add("*", new MultipleElement());
            map.Add("/", new DivideElement());
            map.Add("(", new OpenParentthesisElement());
            map.Add(")", new CloseParentthesisElement());
        }

        /// <summary>
        /// 取得表達式字串
        /// </summary>
        /// <param name="expression">未排序過表達式</param>
        /// <returns>字串</returns>
        public abstract string GetExpressionString(List<string> expression);

        /// <summary>
        /// 取得表達式List
        /// </summary>
        /// <param name="expression">未排序過表達式</param>
        /// <returns>List<CalculateElementBase></returns>
        public abstract List<CalculateElementBase> GetExpressionList(List<string> expression);

        /// <summary>
        /// 取得表達式運算結果
        /// </summary>
        /// <param name="expression">未排序過表達式</param>
        /// <returns>decimal</returns>
        public abstract decimal GetCalculateResult(List<string> expression);

        /// <summary>
        /// 取得運算子暫存堆疊第一個物件的優先權
        /// </summary>
        /// <param name="tempStack"></param>
        /// <returns></returns>
        protected virtual int GetStackPriority(Stack<OperatorElement> tempStack)
        {
            if (tempStack.Count == 0)
            {
                return 0;
            }

            var element = tempStack.Peek();

            if (element.Value == "(")
            {
                return 0;
            }

            return element.Priority;
        }

        /// <summary>
        /// 判斷是否為運算元
        /// </summary>
        /// <param name="item">欲判斷物件</param>
        /// <returns></returns>
        protected bool IsOperand(CalculateElementBase item)
        {
            OperandElement operand = item as OperandElement;

            if (operand is null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 表達式List字串轉為List物件
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns></returns>
        protected List<CalculateElementBase> TransferExpressionToListObject(List<string> expression)
        {
            var result = new List<CalculateElementBase>();

            foreach (var element in expression)
            {
                if (map.ContainsKey(element))
                {
                    result.Add(map[element]);
                }
                else
                {
                    result.Add(new OperandElement(element));
                }
            }

            return result;
        } 

        protected TreeNode GetExpressionTreeNode(List<CalculateElementBase> calculateElements)
        {
            var queueElement = new Queue<CalculateElementBase>();
            foreach (var item in calculateElements)
            {
                queueElement.Enqueue(item);
            }

            var root = new TreeNode();
            return AppendTreeNode(root, queueElement);
        }

        private TreeNode AppendTreeNode(TreeNode root, Queue<CalculateElementBase> queueElement)
        {
            if (queueElement.Count == 0)
            {
                return root;
            }

            var item = queueElement.ToList()[0];
            var token = new TreeNode(item);

            if (root.Token is null)
            {
                queueElement.Dequeue();
                root = token;
                return AppendTreeNode(root, queueElement);
            }

            if (!IsOperand(token.Token))
            {
                if (!IsOperand(root.Token) && root.RightNode is null)
                {
                    throw new Exception();
                }

                if (IsOperand(root.Token))
                {
                    queueElement.Dequeue();
                    token.LeftNode = root;
                    root = token;
                    return AppendTreeNode(root, queueElement);
                }
                else
                {
                    var operatorToken = (OperatorElement)token.Token;
                    var operatorRootToken = (OperatorElement)root.Token;

                    if (operatorToken.Priority <= operatorRootToken.Priority)
                    {
                        queueElement.Dequeue();
                        token.LeftNode = root;
                        root = token;
                        return AppendTreeNode(root, queueElement);
                    }
                    else
                    {
                        root.RightNode = AppendTreeNode(root.RightNode, queueElement);
                        return AppendTreeNode(root, queueElement);
                    }
                }
            }
            else
            {
                if (IsOperand(root.Token))
                {
                    throw new Exception();
                }
                else
                {
                    if (root.RightNode == null)
                    {
                        root.RightNode = token;
                        queueElement.Dequeue();
                        return AppendTreeNode(root, queueElement);
                    }
                    else
                    {
                        root.RightNode = AppendTreeNode(root.RightNode, queueElement);
                        queueElement.Dequeue();
                        return AppendTreeNode(root, queueElement);
                    }
                }
            }
        }
    }
}