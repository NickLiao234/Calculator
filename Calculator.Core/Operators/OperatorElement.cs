using Calculator.Core.Services.Calculate;
using System;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// 運算元類別
    /// </summary>
    public abstract class OperatorElement : CalculateElementBase
    {
        /// <summary>
        /// 優先權
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 初始化呼叫基底類別建構子
        /// </summary>
        /// <param name="value">顯示值</param>
        public OperatorElement(string value) : base(value)
        {
        }

        /// <summary>
        /// 抽象方法
        /// </summary>
        /// <param name="firstOperand">第一運算子</param>
        /// <param name="secondOperand">第二運算子</param>
        /// <returns></returns>
        public abstract decimal Calculate(decimal firstOperand, decimal secondOperand);

        /// <summary>
        /// 複寫加入元素至tree方法
        /// </summary>
        /// <param name="result">運算結果物件</param>
        /// <returns>結果物件</returns>
        public override CalculateResult AppendElement(CalculateResult result)
        {
            Priority += result.PriorityLevel;

            if (result.Root is null)
            {
                result.Root = new TreeNode(this);
                return result;
            }

            if (result.Root.Token.IsOperator() && result.Root.RightNode is null)
            {
                throw new Exception();
            }

            if (result.Root.Token.IsOperand())
            {
                var token = new TreeNode(this);
                token.LeftNode = result.Root;
                result.Root = token;
            }
            else
            {
                var operatorRootToken = result.Root.Token as OperatorElement;
                if (this.Priority <= operatorRootToken.Priority)
                {
                    var token = new TreeNode(this);
                    token.LeftNode = result.Root;
                    result.Root = token;
                }
                else
                {
                    var tempCalculateResult = new CalculateResult();
                    tempCalculateResult.Root = result.Root.RightNode;
                    tempCalculateResult.PriorityLevel = result.PriorityLevel;
                    result.Root.RightNode = AppendElement(tempCalculateResult).Root;
                }
            }

            return result;
        }
    }
}
