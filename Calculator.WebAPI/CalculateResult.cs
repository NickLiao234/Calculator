using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.WebAPI
{
    /// <summary>
    /// 回傳計算結果
    /// </summary>
    public class CalculateResult
    {
        /// <summary>
        /// 目前表達式字串
        /// </summary>
        public List<string> Expression { get; set; }

        /// <summary>
        /// 目前計算結果
        /// </summary>
        public decimal Result { get; set; }
    }
}
