using Caculator.Objects.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Services
{
    /// <summary>
    /// 計算表達式服務介面
    /// </summary>
    public interface ICalculateExpressionService
    {
        /// <summary>
        /// 取得表達式計算結果
        /// </summary>
        /// <returns>運算結果</returns>
        public decimal GetResult();
    }
}
