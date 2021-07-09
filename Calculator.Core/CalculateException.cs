using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core
{
    public class CalculateException : Exception
    {
        public int StatusCode { get; set; }

        public CalculateException(string message, int statusCode = 400) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
