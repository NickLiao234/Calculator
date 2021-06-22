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
    public class CalculateService : INotifyPropertyChanged
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
        /// INotifyPropertyChanged實作方法
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 暫存Delegate
        /// </summary>
        private Delegate tempDelegate;

        /// <summary>
        /// 初始化暫存Delegat為相加
        /// </summary>
        public CalculateService()
        {
            tempDelegate = new Action<string>(a => Add());
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
        public void ExcuteOperator(Delegate @delegate)
        {
            tempDelegate.DynamicInvoke("1");
            tempDelegate = @delegate;
        }

        /// <summary>
        /// CurrentValue字串相加
        /// </summary>
        /// <param name="appendString">加入字串</param>
        public void AppendNumber(string appendString)
        {
            if (appendString == "0" && CurrentValue == "0")
            {
                return;
            }
            CurrentValue += appendString;
        }

        /// <summary>
        /// 相加
        /// </summary>
        public void Add()
        {
            var result = Convert.ToDecimal(HistoryValue) + Convert.ToDecimal(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }

        /// <summary>
        /// 相減
        /// </summary>
        public void Sub()
        {
            var result = Convert.ToDecimal(HistoryValue) - Convert.ToDecimal(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }

        /// <summary>
        /// 相乘
        /// </summary>
        public void Multiple()
        {
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
            var result = Convert.ToDecimal(HistoryValue) / Convert.ToDecimal(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }

        /// <summary>
        /// 顯示運算結果
        /// </summary>
        public void Equal()
        {
            if (CurrentValue != "0")
            {
                tempDelegate.DynamicInvoke("1");
            }

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
