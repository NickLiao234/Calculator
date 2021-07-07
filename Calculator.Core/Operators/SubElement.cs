namespace Calculator.Core.Operators
{
    /// <summary>
    /// 表達式減法類別
    /// </summary>
    public class SubElement : OperatorElement
    {
        /// <summary>
        /// 初始化優先權
        /// </summary>
        public SubElement() : base("-")
        {
            Priority = 2;
        }

        /// <summary>
        /// 運算方法
        /// </summary>
        /// <param name="firstOperand">第一運算子</param>
        /// <param name="secondOperand">第二運算子</param>
        /// <returns></returns>
        public override decimal Calculate(decimal firstOperand, decimal secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
