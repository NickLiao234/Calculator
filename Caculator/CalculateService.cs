using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator
{
    public class CalculateService
    {
        public string HistoryValue { get; set; } = "0";
        public string CurrentValue { get; set; } = "0";

        public void AppendNumber(string str)
        {
            CurrentValue += str;

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
        public void Back()
        {
            if (CurrentValue.Length == 1)
            {
                CurrentValue = "0";
            }

            CurrentValue.Remove(CurrentValue.Length - 1);
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
