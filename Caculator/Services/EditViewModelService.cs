using Caculator.Objects.Operators;
using Calculator;
using Calculator.Core.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 處理viewModel服務
    /// </summary>
    public class EditViewModelService : IEditViewModelService
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        private readonly CalculatorViewModel viewModel;

        /// <summary>
        /// 初始化注入viewModel
        /// </summary>
        /// <param name="viewModel">viewModel</param>
        public EditViewModelService(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        /// <summary>
        /// 運算元加入表達式
        /// </summary>
        public void AddOperand()
        {
            var oprand = Convert.ToDecimal(viewModel.CurrentValue).ToString();

            if (!viewModel.IsCurrentEdited())
            {
                //viewModel.Expression.RemoveAt(viewModel.Expression.Count - 1);
                return;
            }

            if (viewModel.Expression.Count == 0)
            {
                viewModel.Expression.Add(oprand);
                return;
            }

            var lastElement = viewModel.Expression[viewModel.Expression.Count - 1];
            if (IsOperand(lastElement) || lastElement == ")" || lastElement == "]")
            {
                return;
            }

            viewModel.Expression.Add(oprand);
        }

        /// <summary>
        /// 運算子加入表達式
        /// </summary>
        /// <param name="value">顯示值</param>
        public void AddOperator(string value)
        {
            if (viewModel.Expression.Count == 0)
            {
                return;
            }

            viewModel.Expression.Add(value);
        }

        /// <summary>
        /// 表達式加入左括號
        /// </summary>
        public void AddOpenParentthesis()
        {
            viewModel.Expression.Add("(");
        }

        /// <summary>
        /// 表達式加入右括號
        /// </summary>
        public void AddCloseParentthesis()
        {
            if (viewModel.Expression.Count == 0)
            {
                return;
            }

            viewModel.Expression.Add(")");
        }

        /// <summary>
        /// 加入左中括號
        /// </summary>
        public void AddOpenBracket()
        {
            viewModel.Expression.Add("[");
        }

        /// <summary>
        /// 加入右中括號
        /// </summary>
        public void AddCloseBracket()
        {
            if (viewModel.Expression.Count == 0)
            {
                return;
            }

            viewModel.Expression.Add("]");
        }

        /// <summary>
        /// 清除目前運算元
        /// </summary>
        public void ClearCurrentValue()
        {
            viewModel.CurrentValue = "0";
        }

        /// <summary>
        /// 設定運算表達式
        /// </summary>
        public void SetHistoryValue()
        {
            var expressionList = viewModel.Expression;
            var history = "";
            foreach (var item in expressionList)
            {
                decimal number;
                var isNumber = decimal.TryParse(item, out number);
                if (isNumber)
                {
                    history += $"{number} ";
                }
                else
                {
                    history += $"{item} ";
                }                
            }

            viewModel.HistoryValue = history;
        }

        /// <summary>
        /// 設定運算表達式
        /// </summary>
        /// <param name="value">顯示值</param>
        public void SetHistoryValue(string value)
        {
            viewModel.HistoryValue = value.ToString();
        }

        /// <summary>
        /// 設定目前運算元值
        /// </summary>
        /// <param name="value">目前運算子值</param>
        public void SetCurrentValue(string value)
        {
            viewModel.CurrentValue = value;
            viewModel.DisplayCurrentValue = viewModel.CurrentValue;
        }

        /// <summary>
        /// 設定後序表達式
        /// </summary>
        /// <param name="value">表達式字串</param>
        public void SetPostfixValue(string value)
        {
            viewModel.Postfix = value;
        }

        /// <summary>
        /// 設定前序表達式
        /// </summary>
        /// <param name="value">表達式字串</param>
        public void SetPrefixValue(string value)
        {
            viewModel.Prefix = value;
        }

        /// <summary>
        /// 設定中序表達式
        /// </summary>
        /// <param name="value">表達式字串</param>
        public void SetInfixValue(string value)
        {
            viewModel.Infix = value;
        }

        /// <summary>
        /// 判斷是否為運算元方法
        /// </summary>
        /// <param name="lastElement">stack pop第一個物件</param>
        /// <returns></returns>
        private bool IsOperand(string lastElement)
        {
            var listOperator = new List<string>() { "+", "-", "*", "/", "(", ")", "[", "]"};
            if (listOperator.Contains(lastElement))
            {
                return false;
            }

            return true;
        }      

        /// <summary>
        /// 設定表達式字串
        /// </summary>
        /// <param name="expression">表達式字串</param>
        public void SetExpressionList(List<string> expression)
        {
            viewModel.Expression = expression;
        }
    }
}
