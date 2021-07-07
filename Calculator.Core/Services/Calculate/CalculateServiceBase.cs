using Calculator.Core.Operators;
using Calculator.Core.Services.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Core.Service.Calculate
{
    /// <summary>
    /// 運算服務基底類別
    /// </summary>
    public abstract class CalculateServiceBase
    {
        /// <summary>
        /// 字元類別對應表
        /// </summary>
        private Dictionary<string, Type> map;

        /// <summary>
        /// 建構式初始化
        /// </summary>
        public CalculateServiceBase()
        {
            InitMap();
        }

        /// <summary>
        /// 初始化對應表
        /// </summary>
        private void InitMap()
        {
            map = new Dictionary<string, Type>();
            map.Add("+", typeof(AddElement));
            map.Add("-", typeof(SubElement));
            map.Add("*", typeof(MultipleElement));
            map.Add("/", typeof(DivideElement));
            map.Add("(", typeof(OpenParentthesisElement));
            map.Add(")", typeof(CloseParentthesisElement));
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
        /// <returns>表達式</returns>
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
        /// <param name="tempStack">暫存堆疊</param>
        /// <returns>優先權</returns>
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
        /// <returns>bool</returns>
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
        /// <returns>表達式物件List</returns>
        protected List<CalculateElementBase> TransferExpressionToListObject(List<string> expression)
        {
            var result = new List<CalculateElementBase>();
            var openthesisLevel = 1;

            foreach (var element in expression)
            {
                if (map.ContainsKey(element))
                {
                    if (element == "(")
                    {
                        openthesisLevel += 10;
                    }

                    if (element == ")")
                    {
                        openthesisLevel -= 10;
                    }
                    var elementType = map[element];
                    var instance = Activator.CreateInstance(elementType) as OperatorElement;
                    instance.Priority = instance.Priority * openthesisLevel;
                    result.Add(instance);
                }
                else
                {
                    result.Add(new OperandElement(element));
                }
            }

            return result;
        } 

        /// <summary>
        /// 取得表達式使用tree資料結構
        /// </summary>
        /// <param name="calculateElements">表達式物件</param>
        /// <returns>tree</returns>
        protected TreeNode GetExpressionTreeNode(List<CalculateElementBase> calculateElements)
        {
            var queueElement = new Queue<CalculateElementBase>();
            foreach (var item in calculateElements)
            {
                queueElement.Enqueue(item);
            }

            return AppendTreeNode(null, queueElement);
        }

        /// <summary>
        /// 遞迴方法
        /// </summary>
        /// <param name="root">tree</param>
        /// <param name="queueElement">剩餘表達式</param>
        /// <returns></returns>
        private TreeNode AppendTreeNode(TreeNode root, Queue<CalculateElementBase> queueElement)
        {
            if (queueElement.Count == 0)
            {
                return root;
            }

            var item = queueElement.ToList()[0];
            var token = new TreeNode(item);

            if (item.Value == ")")
            {
                return root;
            }
            if (item.Value == "(")
            {
                queueElement.Dequeue();

                if (root is null)
                {
                    root = AppendTreeNode(root, queueElement);
                }
                else
                {
                    if (root.RightNode is null)
                    {
                        root.RightNode = AppendTreeNode(null, queueElement);
                    }
                    else
                    {
                        root.RightNode = AppendTreeNode(root.RightNode, queueElement);
                    }
                }
                queueElement.Dequeue();
                return AppendTreeNode(root, queueElement);
            }

            if (root is null)
            {
                queueElement.Dequeue();
                root = token;
                return AppendTreeNode(root, queueElement);
            }

            if (!IsOperand(token.Token))
            {
                var operatorToken = (OperatorElement)token.Token;

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