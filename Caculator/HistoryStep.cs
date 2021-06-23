using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator
{
    /// <summary>
    /// 歷史運算步驟類別
    /// </summary>
    public class HistoryStep
    {
        /// <summary>
        /// 前運算元
        /// </summary>
        public string FirstOperand { get; set; }

        /// <summary>
        /// 後運算元
        /// </summary>
        public string SecondOperand { get; set; }

        /// <summary>
        /// 運算子
        /// </summary>
        public Delegate Operator { get; set; }

        /// <summary>
        /// 運算元Enum
        /// </summary>
        public OperatorEnum OperatorFlag { get; set; }
    }
}
