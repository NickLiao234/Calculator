using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Enums
{
    public static class StringExtention
    {
        public static T ToEnum<T>(this string str) where T : Enum
        {
            var result = Enum.Parse(typeof(T), str);
            return (T)result;
        }
    }
}
