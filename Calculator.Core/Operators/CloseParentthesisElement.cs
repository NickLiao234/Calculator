using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Operators
{
    public class CloseParentthesisElement : OperatorElement
    {
        public CloseParentthesisElement():base(")")
        {
            Priority = 10;
        }

        public override decimal Calculate(decimal firstOperand, decimal secondOperand)
        {
            throw new NotImplementedException();
        }
    }
}
