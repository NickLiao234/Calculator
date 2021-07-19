using Calculator.Core.Services.Calculate;
using System;

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

        /// <summary>
        /// 複寫加入元素至tree方法
        /// </summary>
        /// <param name="result">運算結果物件</param>
        /// <returns>結果物件</returns>
        public override CalculateResult AppendElement(CalculateResult result)
        {
            if (result.Root is null)
            {
                result.Root = new TreeNode(this);
                return result;
            }

            if (result.Root.Token.IsOperatorWithOneOperand())
            {
                var tempCalculateResult = new CalculateResult();
                tempCalculateResult.Root = result.Root.LeftNode;
                result.Root.LeftNode = AppendElement(tempCalculateResult).Root;
            }

            if (result.Root.Token.IsOperand())
            {
                throw new Exception();
            }

            if(result.Root.Token.IsOperator())
            {
                if (result.Root.RightNode is null)
                {
                    result.Root.RightNode = new TreeNode(this);
                }
                else
                {
                    var tempCalculateResult = new CalculateResult();
                    tempCalculateResult.Root = result.Root.RightNode;
                    result.Root.RightNode = AppendElement(tempCalculateResult).Root;
                }
            }

            return result;
        }
    }
}
