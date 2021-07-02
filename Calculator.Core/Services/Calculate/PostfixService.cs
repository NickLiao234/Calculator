using Calculator.Core.Operators;
using System;
using System.Collections.Generic;

namespace Calculator.Core.Service.Calculate
{
    /// <summary>
    /// 運算後序表達式服務
    /// </summary>
    public class PostfixService : CalculateServiceBase
    {

        /// <summary>
        /// 初始化
        /// </summary>
        public PostfixService():base()
        {
        }

        /// <summary>
        /// 取得後序表達式字串
        /// </summary>
        /// <param name="expression">未排序過表達式</param>
        /// <returns>字串</returns>
        public override string GetExpressionString(List<string> expression)
        {
            string result = "";

            var listPostfix = GetExpressionList(expression);

            foreach (var item in listPostfix)
            {
                result += item.Value;
            }

            return result;
        }

        /// <summary>
        /// 取得後序表達式
        /// </summary>
        /// <param name="expression">未排序過表達式</param>
        /// <returns>List<CalculateElementBase></returns>
        public override List<CalculateElementBase> GetExpressionList(List<string> expression)
        {
            var result = new List<CalculateElementBase>();

            var listObject = TransferExpressionToListObject(expression);

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
        /// 取得後序表達式運算結果
        /// </summary>
        /// <param name="expression">未排序過表達式</param>
        /// <returns>decimal</returns>
        public override decimal GetCalculateResult(List<string> expression)
        {
            var postfixList = GetExpressionList(expression);

            var tempOperandStack = new Stack<decimal>();

            foreach (var element in postfixList)
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
    }
}
