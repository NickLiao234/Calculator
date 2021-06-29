using Caculator;
using Caculator.Objects.Operators;
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
        /// 表達式堆疊
        /// </summary>
        public Stack<CalculateElementBase> ExpressionStack { get; set; }

        /// <summary>
        /// 已計算過數值
        /// </summary>
        public string HistoryValue { get; set; }

        /// <summary>
        /// 運算子
        /// </summary>
        public string CurrentValue { get; set; }

        /// <summary>
        /// INotifyPropertyChanged實作方法
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 初始化
        /// </summary>
        public CalculatorViewModel()
        {
            ExpressionStack = new Stack<CalculateElementBase>();
            HistoryValue = "0";
            CurrentValue = "0";
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
    }
}
