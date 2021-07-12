using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core
{
    /// <summary>
    /// 計算例外
    /// </summary>
    public class CalculateException : Exception
    {
        /// <summary>
        /// 狀態碼
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// 建構式初始化
        /// </summary>
        /// <param name="message">訊息</param>
        /// <param name="statusCode">狀態碼</param>
        public CalculateException(string message, int statusCode = 400) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
