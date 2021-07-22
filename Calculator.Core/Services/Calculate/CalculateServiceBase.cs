using Calculator.Core.Operators;
using Calculator.Core.Services.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Core.Extentions;

namespace Calculator.Core.Services.Calculate
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
            map.Add("[", typeof(OpenBracketElement));
            map.Add("]", typeof(CloseBracketElement));
            map.Add("²√", typeof(SquareRootElement));
            map.Add("negate", typeof(NegateElement));
        }

        /// <summary>
        /// 取得表達式字串
        /// </summary>
        /// <param name="expression">未排序過表達式</param>
        /// <returns>字串</returns>
        public virtual string GetExpressionString(List<string> expression)
        {
            var valisExpression = GetValidExpression(expression);
            var listExpression = GetValidAndBalanceExpression(valisExpression);
            var expressionTreeNode = GetExpressionTreeNode(listExpression);

            return AppendTreeNode(expressionTreeNode, "");
        }

        /// <summary>
        /// 產生表達式字串抽象方法(在infix,prefix,postfix各自實作)
        /// </summary>
        /// <param name="tree">tree</param>
        /// <param name="str">字串</param>
        /// <returns>字串結果</returns>
        public abstract string AppendTreeNode(TreeNode tree, string str);

        /// <summary>
        /// 取得表達式運算結果
        /// </summary>
        /// <param name="expression">未排序過表達式</param>
        /// <returns>decimal</returns>
        public virtual decimal GetCalculateResult(List<string> expression)
        {
            var listPostfix = GetValidAndBalanceExpression(expression);
            var expressionTreeNode = GetExpressionTreeNode(listPostfix);

            return GetResult(expressionTreeNode);
        }

        /// <summary>
        /// 計算結果遞迴方法
        /// </summary>
        /// <param name="expressionTreeNode">表達式tree</param>
        /// <returns>decimal</returns>
        private decimal GetResult(TreeNode expressionTreeNode)
        {
            if (expressionTreeNode is null)
            {
                return 0;
            }
            if (expressionTreeNode.Token is null)
            {
                return 0;
            }

            if (expressionTreeNode.LeftNode is null && expressionTreeNode.RightNode is null)
            {
                var result = decimal.Parse(expressionTreeNode.Token.Value);
                return result;
            }
            else
            {
                if (expressionTreeNode.Token is OperatorElement)
                {
                    var op = expressionTreeNode.Token as OperatorElement;
                    var oprandLeft = GetResult(expressionTreeNode.LeftNode);
                    var oprandRight = GetResult(expressionTreeNode.RightNode);
                    return op.Calculate(oprandLeft, oprandRight);
                }
                else
                {
                    var op = expressionTreeNode.Token as OperatorWithOneOperandElement;
                    var oprandLeft = GetResult(expressionTreeNode.LeftNode);
                    return op.Calculate(oprandLeft);
                }              
            }
        }

        /// <summary>
        /// 表達式List字串轉為List物件
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns>表達式物件List</returns>
        protected List<CalculateElementBase> TransferExpressionToListObject(List<string> expression)
        {
            var result = new List<CalculateElementBase>();

            foreach (var element in expression)
            {
                if (map.ContainsKey(element))
                {
                    var elementType = map[element];
                    var instance = Activator.CreateInstance(elementType) as CalculateElementBase;
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
        /// 取得合法表達式
        /// </summary>
        /// <param name="expression">表達式字串</param>
        /// <returns>合法表達式字串</returns>
        public List<string> GetValidExpression(List<string> expression)
        {
            var result = new List<string>();

            if (expression.Contains("="))
            {
                expression.Remove("=");
            }

            var listObj = TransferExpressionToListObject(expression);

            while (listObj[listObj.Count - 1].IsOperator())
            {
                listObj.RemoveAt(listObj.Count - 1);
            }

            FixOperatorWithOneOperandElementPosition(listObj);
            listObj = BalanceCurrentOpenClose(listObj);

            foreach (var element in listObj)
            {
                result.Add(element.Value);
            }

            return result;
        }

        /// <summary>
        /// 取得合法且平衡表達式
        /// </summary>
        /// <param name="expression">原始表達式</param>
        /// <returns>合法表達式物件List</returns>
        protected List<CalculateElementBase> GetValidAndBalanceExpression(List<string> expression)
        {
            if (expression.Contains("="))
            {
                expression.Remove("=");
            }

            var listObj = TransferExpressionToListObject(expression);

            while (listObj[listObj.Count - 1].IsOperator())
            {
                listObj.RemoveAt(listObj.Count - 1);
            }
            
            listObj = AddBracketToBalance(listObj);
            return AddParentthesisToBalance(listObj);
        }

        /// <summary>
        /// 平衡運算表達式(小括號)
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns>表達式物件List</returns>
        private List<CalculateElementBase> AddParentthesisToBalance(List<CalculateElementBase> expression)
        {
            var openParantthesisCount = expression.Where(element => element is OpenParentthesisElement).Count();
            var closeParantthesisCount = expression.Where(element => element is CloseParentthesisElement).Count();
            var openCloseSub = openParantthesisCount - closeParantthesisCount;

            while (openCloseSub != 0)
            {
                expression.Add(new CloseParentthesisElement());
                openCloseSub--;
            }

            return expression;
        }

        /// <summary>
        /// 平衡運算表達式(中括號)
        /// </summary>
        /// <param name="expression">表達式物件List</param>
        /// <returns></returns>
        private List<CalculateElementBase> AddBracketToBalance(List<CalculateElementBase> expression)
        {
            var diff = expression.Where(element => element is OpenBracketElement).Count() - expression.Where(element => element is CloseBracketElement).Count();
            
            while (diff != 0)
            {
                var targetOpenBracketIndex = expression.FindIndexByTargetCount(0, diff, element => element is OpenBracketElement);
                var nextOpenBracketIndex = 
                    expression.FindIndex(targetOpenBracketIndex + 1, element => element is OpenBracketElement) == -1 ?
                    expression.Count() - 1 :
                    expression.FindIndex(targetOpenBracketIndex + 1, element => element is OpenBracketElement);

                var openParentthesisCount = expression.CountByCondition(targetOpenBracketIndex, nextOpenBracketIndex, element => element is OpenParentthesisElement);
                var closeParentthesisCount = expression.CountByCondition(targetOpenBracketIndex, nextOpenBracketIndex, element => element is CloseParentthesisElement);

                while (openParentthesisCount - closeParentthesisCount != 0)
                {
                    expression.Add(new CloseParentthesisElement());
                    closeParentthesisCount++;
                }                
                expression.Add(new CloseBracketElement());
                diff--;
            }

            return expression;
        }

        /// <summary>
        /// 取得表達式使用tree資料結構
        /// </summary>
        /// <param name="calculateElements">表達式物件</param>
        /// <returns>tree</returns>
        protected TreeNode GetExpressionTreeNode(List<CalculateElementBase> calculateElements)
        {
            var result = new CalculateResult();
            foreach (var item in calculateElements)
            {
                result = item.AppendElement(result);
            }

            return result.Root;
        }

        /// <summary>
        /// 找到右括號相對的左括號index, 若無則回應-1
        /// </summary>
        /// <typeparam name="TOpen">左括號型別</typeparam>
        /// <typeparam name="TClose">右括號型別</typeparam>
        /// <param name="expession">表達式物件</param>
        /// <param name="closeElementIndex">右括號的index</param>
        /// <returns>左括號index</returns>
        private int FindOppositeOpenElementIndex<TOpen, TClose>(List<CalculateElementBase> expession, int closeElementIndex) where TOpen : OpenCloseElement where TClose : OpenCloseElement 
        {
            int closeElementCountFlag = 1;

            for (int i = closeElementIndex - 1; i > -1; i--)
            {
                if (expession[i] is TClose)
                {
                    closeElementCountFlag++;
                }
                if (expession[i] is TOpen)
                {
                    closeElementCountFlag--;
                }
                if (closeElementCountFlag == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 修改單一運算元的運算子位置
        /// </summary>
        /// <param name="expression">表達式物件</param>
        /// <returns></returns>
        private List<CalculateElementBase> FixOperatorWithOneOperandElementPosition(List<CalculateElementBase> expression)
        {
            if (expression.Count < 2)
            {
                return expression;
            }
            var lastElement = expression[expression.Count - 1];
            var lastElementIndex = expression.Count - 1;
            var lastTwoElement = expression[expression.Count - 2];
            int index = expression.Count - 2;

            if (lastElement is not OperatorWithOneOperandElement)
            {
                return expression;
            }

            if (lastTwoElement is CloseParentthesisElement)
            {
                index = FindOppositeOpenElementIndex<OpenParentthesisElement, CloseParentthesisElement>(expression, expression.Count - 2);
            }
            if (lastTwoElement is CloseBracketElement)
            {
                index = FindOppositeOpenElementIndex<OpenBracketElement, CloseBracketElement>(expression, expression.Count - 2);
            }

            if (expression[index - 1] is OperatorWithOneOperandElement)
            {
                index = index - 1;
            }

            expression[lastElementIndex] = new CloseParentthesisElement();
            expression.Insert(index, new OpenParentthesisElement());
            expression.Insert(index, lastElement);           
            return expression;
        }

        /// <summary>
        /// 平衡目前左右括號
        /// </summary>
        /// <param name="expression">表達式物件</param>
        /// <returns></returns>
        private List<CalculateElementBase> BalanceCurrentOpenClose(List<CalculateElementBase> expression)
        {
            var lastElement = expression[expression.Count - 1];
            int index = -2;

            if (!(lastElement is OpenCloseElement))
            {
                return expression;
            }

            if (expression.Count == 1 && (lastElement is OpenParentthesisElement || lastElement is OpenBracketElement))
            {
                return expression;
            }

            var beforeLastElement = expression[expression.Count - 2];

            if (lastElement is OpenBracketElement || lastElement is OpenParentthesisElement)
            {
                if (!beforeLastElement.IsOperator())
                {
                    expression.RemoveAt(expression.Count - 1);
                }
            }

            if (lastElement is CloseBracketElement || lastElement is CloseParentthesisElement)
            {
                if (!beforeLastElement.IsOperand() && !beforeLastElement.IsOpenCloseElement())
                {
                    expression.RemoveAt(expression.Count - 1);
                    return expression;
                }
                if (lastElement is CloseBracketElement)
                {
                    index = FindOppositeOpenElementIndex<OpenBracketElement, CloseBracketElement>(expression, expression.Count - 1);
                }
                if (lastElement is CloseParentthesisElement)
                {
                    index = FindOppositeOpenElementIndex<OpenParentthesisElement, CloseParentthesisElement>(expression, expression.Count - 1);
                } 
            }

            if (index == -1)
            {
                expression.RemoveAt(expression.Count - 1);
                return expression;
            }
            if (index == -2)
            {
                return expression;
            }

            var tempExpression = expression.GetRange(index + 1, expression.Count - index - 2);
            tempExpression = AddBracketToBalance(tempExpression);
            tempExpression = AddParentthesisToBalance(tempExpression);
            expression.RemoveRange(index + 1, expression.Count - index - 2);
            expression.InsertRange(index + 1, tempExpression);
            return expression;
        }
    }
}