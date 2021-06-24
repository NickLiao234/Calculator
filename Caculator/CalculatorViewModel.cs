using Caculator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 計算服務
    /// </summary>
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// 已計算過數值
        /// </summary>
        public string HistoryValue { get; set; } = "0";

        /// <summary>
        /// 運算子
        /// </summary>
        public string CurrentValue { get; set; } = "0";

        /// <summary>
        /// 前一執行步驟
        /// </summary>
        private HistoryStep historyStep;

        /// <summary>
        /// INotifyPropertyChanged實作方法
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 暫存Delegate
        /// </summary>
        private Delegate tempDelegate;

        /// <summary>
        /// 暫存執行運算元Enum
        /// </summary>
        private OperatorEnum tempOperatorEnum;

        /// <summary>
        /// 初始化暫存Delegat為相加
        /// </summary>
        public CalculatorViewModel()
        {
            tempDelegate = new Action<string>(a => Add());
            tempOperatorEnum = OperatorEnum.Add;
            historyStep = new HistoryStep();
        }

        /// <summary>
        /// CurrentValue是否異曾經動過
        /// </summary>
        /// <returns></returns>
        public bool IsCurrentEdited()
        {
            if (CurrentValue == "0")
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 立刻執行Delegete(for修改運算元)
        /// </summary>
        /// <param name="delegate">委派方法</param>
        /// <param name="appendString">加入字元</param>
        public void Execute(Delegate @delegate, string appendString)
        {
            @delegate.DynamicInvoke(appendString);
        }

        /// <summary>
        /// 執行暫存Delegate並將tempDelegate替換(for執行運算子+-*/)
        /// </summary>
        /// <param name="delegate">委派方法</param>
        /// <param name="operatorEnum">運算元Enum</param>
        public void ExcuteOperator(Delegate @delegate, OperatorEnum operatorEnum)
        {
            tempDelegate.DynamicInvoke("1");
            historyStep.Operator = tempDelegate;
           
            tempOperatorEnum = operatorEnum;
            tempDelegate = @delegate;
        }

        /// <summary>
        /// CurrentValue字串相加
        /// </summary>
        /// <param name="appendString">加入字串</param>
        public void AppendNumber(string appendString)
        {
            CurrentValue += appendString;
        }

        /// <summary>
        /// 相加
        /// </summary>
        public void Add()
        {
            SaveHistoryStep();

            var result = Convert.ToDecimal(HistoryValue) + Convert.ToDecimal(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }

        /// <summary>
        /// 相減
        /// </summary>
        public void Sub()
        {
            SaveHistoryStep();

            var result = Convert.ToDecimal(HistoryValue) - Convert.ToDecimal(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }

        /// <summary>
        /// 相乘
        /// </summary>
        public void Multiple()
        {
            if (historyStep.OperatorFlag == OperatorEnum.Add || historyStep.OperatorFlag == OperatorEnum.Sub)
            {
                var firstStep = Convert.ToDecimal(CurrentValue) * Convert.ToDecimal(historyStep.SecondOperand);
                HistoryValue = firstStep.ToString();
                CurrentValue = historyStep.FirstOperand;
                historyStep.Operator.DynamicInvoke("1");

                return;
            }

            var result = Convert.ToDecimal(HistoryValue) * Convert.ToDecimal(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }

        /// <summary>
        /// 相除
        /// </summary>
        public void Divide()
        {
            if (CurrentValue == "0")
            {
                return;
            }

            if (historyStep.OperatorFlag == OperatorEnum.Add || historyStep.OperatorFlag == OperatorEnum.Sub)
            {
                var firstStep = Convert.ToDecimal(CurrentValue) / Convert.ToDecimal(historyStep.SecondOperand);
                HistoryValue = firstStep.ToString();
                CurrentValue = historyStep.FirstOperand;
                historyStep.Operator.DynamicInvoke("1");

                return;
            }
           
            var result = Convert.ToDecimal(HistoryValue) / Convert.ToDecimal(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }

        /// <summary>
        /// 儲存運算元至歷史步驟
        /// </summary>
        private void SaveHistoryStep()
        {
            historyStep.FirstOperand = HistoryValue;
            historyStep.SecondOperand = CurrentValue;
        }

        /// <summary>
        /// 顯示運算結果
        /// </summary>
        public void Equal()
        {
            tempDelegate.DynamicInvoke("1");
            historyStep.Operator = null;
            tempDelegate = new Action<string>(a => Add());
        }

        /// <summary>
        /// 運算元改回正數或負數
        /// </summary>
        public void Reverse()
        {
            var CurentValueToDouble = Convert.ToDouble(CurrentValue);
            CurrentValue = (0 - CurentValueToDouble).ToString();
        }

        /// <summary>
        /// 運算元退回一個字元
        /// </summary>
        public void Back()
        {
            if (CurrentValue.Length == 1)
            {
                CurrentValue = "0";
            }

            CurrentValue = CurrentValue.Remove(CurrentValue.Length - 1);
        }

        /// <summary>
        /// 清除所有運算
        /// </summary>
        public void Clear()
        {
            HistoryValue = "0";
            CurrentValue = "0";
        }

        /// <summary>
        /// 清除運算元
        /// </summary>
        public void ClearCurrent()
        {
            CurrentValue = "0";
        }
    }   
}
