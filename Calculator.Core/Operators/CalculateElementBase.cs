using Calculator.Core.Services.Calculate;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// 表達式物件基底類別
    /// </summary>
    public abstract class CalculateElementBase
    {
        /// <summary>
        /// 顯示值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 初始化顯示值
        /// </summary>
        /// <param name="value">顯示值</param>
        public CalculateElementBase(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 將元素加入tree方法
        /// </summary>
        /// <param name="result">計算結果物件</param>
        /// <returns>結果物件</returns>
        public abstract CalculateResult AppendElement(CalculateResult result);

        /// <summary>
        /// 判斷是否為括號
        /// </summary>
        /// <returns>bool</returns>
        public bool IsOpenCloseElement()
        {
            return this is OpenCloseElement;
        }

        /// <summary>
        /// 判斷是否為運算元
        /// </summary>
        /// <returns>bool</returns>
        public bool IsOperand()
        {
            return this is OperandElement;
        }

        /// <summary>
        /// 判斷是否為運算子
        /// </summary>
        /// <returns>bool</returns>
        public bool IsOperator()
        {
            return this is OperatorElement;
        }

        public bool IsOperatorWithOneOperand()
        {
            return this is OperatorWithOneOperandElement;
        }
    }
}
