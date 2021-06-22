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

        public CalculateService()
        {
            tempDelegate = new Action<string>(a => Add());
        }

        public void AppendNumber(string str)
        {
            if (str == "0" && CurrentValue == "0")
            {
                return;
            }
            CurrentValue += str;            

        }

        public void Excute(Delegate @delegate, string a)
        {
            @delegate.DynamicInvoke(a);
        }

        public void ExcuteTemp(Delegate @delegate)
        {
            tempDelegate.DynamicInvoke("1");
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
            if (CurrentValue == "0")
            {
                return;
            }
            var result = Convert.ToDouble(HistoryValue) / Convert.ToDouble(CurrentValue);
            HistoryValue = result.ToString();
            CurrentValue = "0";
        }
        public void Equal()
        {
            if (CurrentValue != "0")
            {
                tempDelegate.DynamicInvoke("1");
            }

            tempDelegate = new Action<string>(a => Add());
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
