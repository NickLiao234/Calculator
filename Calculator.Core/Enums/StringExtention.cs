using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Enums
{
    /// <summary>
    /// string擴充方法
    /// </summary>
    public static class StringExtention
    {
        /// <summary>
        /// 字串轉Enum
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="str">字串</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string str) where T : Enum
        {
            var result = Enum.Parse(typeof(T), str);
            return (T)result;
        }
    }
}
