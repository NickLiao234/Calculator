using Calculator.Core.Enums;
using Calculator.Core.Services.Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Calculate
{
    /// <summary>
    /// 運算服務工廠
    /// </summary>
    public class CalculateFactory
    {
        /// <summary>
        /// 取得運算服務實體
        /// </summary>
        /// <param name="calculateEnum">運算Enum</param>
        /// <returns>CalculateServiceBase實體</returns>
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
