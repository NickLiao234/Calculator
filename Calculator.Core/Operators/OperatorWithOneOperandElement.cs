using Calculator.Core.Services.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    public abstract class OperatorWithOneOperandElement : CalculateElementBase
    {
        public int Priority { get; set; }
        public OperatorWithOneOperandElement(string value) : base(value)
        {            
        }

        /// <summary>
        /// 抽象方法
        /// </summary>
        /// <param name="firstOperand">第一運算子</param>
        /// <returns></returns>
        public abstract decimal Calculate(decimal firstOperand);

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
