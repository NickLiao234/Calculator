using Calculator.Core.Enums;
using Calculator.Core.Service.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Calculate
{
    public class CalculateFactory
    {
        public CalculateServiceBase GetCalculateService(CalculateEnum calculateEnum)
        {
            switch (calculateEnum)
            {
                case CalculateEnum.prefix:
                    return new PrefixService();
                case CalculateEnum.infix:
                    return new InfixService();
                case CalculateEnum.postfix:
                    return new PostfixService();
                default:
                    return new InfixService();
            }
        }
    }
}
