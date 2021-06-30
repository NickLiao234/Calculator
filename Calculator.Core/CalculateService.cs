using Caculator.Core.Operators;
using System.Collections.Generic;

namespace Calculator.Core
{
    /// <summary>
    /// 運算表達式服務
    /// </summary>
    public class CalculateService
    {
        /// <summary>
        /// 字元類別對應表
        /// </summary>
        private Dictionary<string, CalculateElementBase> map;

        /// <summary>
        /// 初始化
        /// </summary>
        public CalculateService()
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
            //map.Add("(", new OpenParentthesisElement());
            //map.Add(")", new CloseParentthesisElement());
        }

        /// <summary>
        /// 取得中序表達式
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns>中序表達式字串</returns>
        public string GetInfix(List<string> expression)
        {
            string result = "";

            var listObject = TransferExpressionToListObject(expression);

            foreach (var item in listObject)
            {
                result += item.Value;
            }

            return result;
        }

        /// <summary>
        /// 取得後序表達式
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns>後序表達式字串</returns>
        public string GetPostfix(List<string> expression)
        {
            string result = "";

            var listObject = TransferExpressionToListObject(expression);

            var tempStack = new Stack<OperatorElement>();

            foreach (var item in listObject)
            {
                if (IsOperand(item))
                {
                    result += $"{item.Value} ";
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

                        result += temp.Value;

                    } while (true);
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
                            result += temp.Value;
                        }

                        var element = (OperatorElement)item;
                        tempStack.Push(element);
                    }
                }
            }

            while (tempStack.Count != 0)
            {
                var temp = tempStack.Pop();
                result += temp.Value;
            }


            return result;
        }

        /// <summary>
        /// 取得運算子暫存堆疊第一個物件的優先權
        /// </summary>
        /// <param name="tempStack"></param>
        /// <returns></returns>
        private int GetStackPriority(Stack<OperatorElement> tempStack)
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
        private bool IsOperand(CalculateElementBase item)
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
        private List<CalculateElementBase> TransferExpressionToListObject(List<string> expression)
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
    }
}
