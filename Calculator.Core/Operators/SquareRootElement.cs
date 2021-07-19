using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    public class SquareRootElement : OperatorWithOneOperandElement
    {
        public SquareRootElement() : base("²√")
        {
            Priority = 9;
        }
        public override decimal Calculate(decimal firstOperand)
        {
            if (firstOperand < 0)
            {
                throw new CalculateException("It cant not SquareRoot");
            }

            var squareRootValue = Math.Sqrt(Convert.ToDouble(firstOperand));
            return Convert.ToDecimal(squareRootValue);
        }
    }
}
