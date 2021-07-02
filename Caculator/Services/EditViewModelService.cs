using Caculator.Objects.Operators;
using Calculator;
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
            if (IsOperand(lastElement) || lastElement == ")")
            {
                return;
            }

            viewModel.Expression.Add(oprand);
        }

        /// <summary>
        /// 運算子加入表達式
        /// </summary>
        /// <param name="value">顯示值</param>
        /// <param name="type">運算元類別型態</param>
        public void AddOperator(string value)
        {
            if (viewModel.Expression.Count == 0)
            {
                return;
            }

            var lastElement = viewModel.Expression[viewModel.Expression.Count - 1];
            if (lastElement == "(")
            {
                return;
            }
            if (!IsOperand(lastElement))
            {
                viewModel.Expression.RemoveAt(viewModel.Expression.Count - 1);
                return;
            }

            viewModel.Expression.Add(value);
        }

        /// <summary>
        /// 表達式加入左括號
        /// </summary>
        public void AddOpenParentthesis()
        {
            if (viewModel.Expression.Count != 0)
            {
                var lastElement = viewModel.Expression[viewModel.Expression.Count - 1];
                if (IsOperand(lastElement) || lastElement == ")")
                {
                    return;
                }
            }

            viewModel.Expression.Add("(");
        }

        public void AddCloseParentthesis()
        {
            if (viewModel.Expression.Count == 0)
            {
                return;
            }

            var lastElement = viewModel.Expression[viewModel.Expression.Count - 1];
            if (!IsOperand(lastElement) && lastElement != ")")
            {
                return;
            }

            if (lastElement == ")" && !viewModel.IsOpenParentthesisMoreThanCloseParentThesis())
            {
                return;
            }

            viewModel.Expression.Add(")");
        }

        /// <summary>
        /// 清除目前運算元
        /// </summary>
        public void ClearCurrentValue()
        {
            viewModel.CurrentValue = "0";
        }

        /// <summary>
        /// 設定運算結果值
        /// </summary>
        /// <param name="value">顯示值</param>
        public void SetHistoryValue(decimal value)
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
        }

        /// <summary>
        /// 判斷是否為運算元方法
        /// </summary>
        /// <param name="lastElement">stack pop第一個物件</param>
        /// <returns></returns>
        private bool IsOperand(string lastElement)
        {
            var listOperator = new List<string>() { "+", "-", "*", "/", "(", ")" };
            if (listOperator.Contains(lastElement))
            {
                return false;
            }

            return true;
        }      
    }
}
