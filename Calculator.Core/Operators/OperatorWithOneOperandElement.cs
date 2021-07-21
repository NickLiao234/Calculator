using Calculator.Core.Services.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    /// <summary>
    /// 單一運算元運算子類別
    /// </summary>
    public abstract class OperatorWithOneOperandElement : CalculateElementBase
    {
        /// <summary>
        /// 優先權
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 建構式初始化
        /// </summary>
        /// <param name="value">顯示值</param>
        public OperatorWithOneOperandElement(string value) : base(value)
        {            
        }

        /// <summary>
        /// 抽象方法
        /// </summary>
        /// <param name="firstOperand">第一運算子</param>
        /// <returns></returns>
        public abstract decimal Calculate(decimal firstOperand);

        /// <summary>
        /// 加入tree方法
        /// </summary>
        /// <param name="result">運算結果</param>
        /// <returns>結果</returns>
        public override CalculateResult AppendElement(CalculateResult result)
        {
            Priority += result.PriorityLevel;

            if (result.Root is null)
            {
                result.Root = new TreeNode(this);
                return result;
            }

            if (result.Root.Token.IsOperand())
            {
                throw new CalculateException("Wrong Expression");
            }

            if (result.Root.Token.IsOperatorWithOneOperand())
            {
                var tempCalculateResult = new CalculateResult();
                tempCalculateResult.Root = result.Root.LeftNode;
                tempCalculateResult.PriorityLevel = result.PriorityLevel;
                result.Root.LeftNode = AppendElement(tempCalculateResult).Root;
            }

            if (result.Root.Token.IsOperator())
            {
                var tempCalculateResult = new CalculateResult();
                tempCalculateResult.Root = result.Root.RightNode;
                tempCalculateResult.PriorityLevel = result.PriorityLevel;
                result.Root.RightNode = AppendElement(tempCalculateResult).Root;
            }

            return result;
        }
    }
}
