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
        }

        /// <summary>
        /// 取得表達式字串
        /// </summary>
        /// <param name="expression">未排序過表達式</param>
        /// <returns>字串</returns>
        public virtual string GetExpressionString(List<string> expression)
        {
            var listExpression = GetValidExpression(expression);
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
            var listPostfix = GetValidExpression(expression);
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
                var op = expressionTreeNode.Token as OperatorElement;
                var oprandLeft = GetResult(expressionTreeNode.LeftNode);
                var oprandRight = GetResult(expressionTreeNode.RightNode);
                return op.Calculate(oprandLeft, oprandRight);
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
        /// <param name="expression">原始表達式</param>
        /// <returns>合法表達式物件List</returns>
        protected List<CalculateElementBase> GetValidExpression(List<string> expression)
        {
            var openParantthesisCount = expression.Where(item => item == "(").Count();
            var closeParantthesisCount = expression.Where(item => item == ")").Count();
            var openCloseCount = openParantthesisCount - closeParantthesisCount;

            if (expression.Contains("="))
            {
                expression.Remove("=");
            }

            while (IsOperator(expression[expression.Count - 1]))
            {
                expression.RemoveAt(expression.Count - 1);
            }

            var listObj = TransferExpressionToListObject(expression);
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
        /// 判斷運算子
        /// </summary>
        /// <param name="str">字串</param>
        /// <returns></returns>
        private bool IsOperator(string str)
        {
            if (str == "+" || str == "-" || str == "*" || str == "/")
            {
                return true;
            }

            return false;
        }
    }
}