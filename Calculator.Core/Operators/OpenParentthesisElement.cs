using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    public class OpenParentthesisElement : OperatorElement
    {
        public OpenParentthesisElement() : base("(")
        {
            Priority = 10;
        }

        public override decimal Calculate(decimal firstOperand, decimal secondOperand)
        {
            throw new NotImplementedException();
        }
    }
}
