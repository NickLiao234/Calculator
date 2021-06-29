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
        /// 運算子插入堆疊
        /// </summary>
        public void PushOperand()
        {
            var oprand = new OperandElement(viewModel.CurrentValue);

            if (!viewModel.IsCurrentEdited())
            {
                viewModel.ExpressionStack.Pop();
                return;
            }

            if (viewModel.ExpressionStack.Count == 0)
            {
                viewModel.ExpressionStack.Push(oprand);
                return;
            }

            var popOutObject = viewModel.ExpressionStack.Peek();
            if (IsOperand(popOutObject))
            {
                return;
            }

            viewModel.ExpressionStack.Push(oprand);
        }

        /// <summary>
        /// 運算元插入堆疊
        /// </summary>
        /// <param name="value">顯示值</param>
        /// <param name="type">運算元類別型態</param>
        public void PushOperator(string value, Type type)
        {
            if (viewModel.ExpressionStack.Count == 0)
            {
                return;
            }

            var stackFirstObject = viewModel.ExpressionStack.Peek();
            if (!IsOperand(stackFirstObject))
            {
                viewModel.ExpressionStack.Pop();
                return;
            }

            object[] args = { value };

            OperatorElement element = (OperatorElement)Activator.CreateInstance(type, args);

            viewModel.ExpressionStack.Push(element);
        }

        /// <summary>
        /// 清除目前運算子
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
        /// 設定目前運算子值
        /// </summary>
        /// <param name="value">目前運算子值</param>
        public void SetCurrentValue(string value)
        {
            viewModel.CurrentValue = value;
        }

        /// <summary>
        /// 判斷是否為運算子方法
        /// </summary>
        /// <param name="popOutObject">stack pop第一個物件</param>
        /// <returns></returns>
        private bool IsOperand(CalculateElementBase popOutObject)
        {
            OperandElement operand = popOutObject as OperandElement;

            if (operand is null)
            {
                return false;
            }

            return true;
        }      
    }
}
