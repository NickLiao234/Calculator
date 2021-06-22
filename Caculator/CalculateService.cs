using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator
{
    public class CalculateService : INotifyPropertyChanged
    {
        public string HistoryValue { get; set; } = "0";
        public string CurrentValue { get; set; } = "0";

        public event PropertyChangedEventHandler PropertyChanged;

        private Delegate tempDelegate;

        public void AppendNumber(string str)
        {
            CurrentValue += str;

        }

        public void Excute(Delegate @delegate)
        {
            @delegate.DynamicInvoke();
        }

        public void EcuteTemp(Delegate @delegate)
        {
            tempDelegate.DynamicInvoke();
            tempDelegate = @delegate;
        }
        public void Add()
        {
            var result = Convert.ToDouble(HistoryValue) + Convert.ToDouble(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }
        public void Sub()
        {
            var result = Convert.ToDouble(HistoryValue) - Convert.ToDouble(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }
        public void Multiple()
        {
            var result = Convert.ToDouble(HistoryValue) * Convert.ToDouble(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }
        public void Divide()
        {
            var result = Convert.ToDouble(HistoryValue) / Convert.ToDouble(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }
        public void Equal()
        {

        }

        public void Reverse()
        {
            var CurentValueToDouble = Convert.ToDouble(CurrentValue);
            CurrentValue = (0 - CurentValueToDouble).ToString();
        }
        public void Back()
        {
            if (CurrentValue.Length == 1)
            {
                CurrentValue = "0";
            }

            CurrentValue =  CurrentValue.Remove(CurrentValue.Length - 1);
        }
        public void Clear()
        {
            HistoryValue = "0";
            CurrentValue = "0";
        }
        public void ClearCurrent()
        {
            CurrentValue = "0";
        }
    }
}
