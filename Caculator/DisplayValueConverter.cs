using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Calculator
{
    /// <summary>
    /// 轉換器
    /// </summary>
    public class DisplayValueConverter : IValueConverter
    {
        /// <summary>
        /// 轉換方法
        /// </summary>
        /// <param name="value">欲轉換物件</param>
        /// <param name="targetType">轉換物件型別</param>
        /// <param name="parameter">參數</param>
        /// <param name="culture">CultureInfo</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return value;
            }

            var result = System.Convert.ToDecimal(value);

            return result;
        }

        /// <summary>
        /// 回復轉換方法
        /// </summary>
        /// <param name="value">欲轉換物件</param>
        /// <param name="targetType">轉換物件型別</param>
        /// <param name="parameter">參數</param>
        /// <param name="culture">CultureInfo</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
