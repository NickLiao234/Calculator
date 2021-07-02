namespace Calculator.Core.Operators
{
    /// <summary>
    /// 運算子類別
    /// </summary>
    public class OperandElement : CalculateElementBase
    {
        /// <summary>
        /// 初始化呼叫基底類別建構子
        /// </summary>
        /// <param name="value">顯示值</param>
        public OperandElement(string value) : base(value)
        {
        }
    }
}
