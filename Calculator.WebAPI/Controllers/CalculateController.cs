using Calculator.Core.Enums;
using Calculator.Core.Service.Calculate;
using Calculator.Core.Services.Calculate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.WebAPI.Controllers
{
    /// <summary>
    /// CalculateController
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : Controller
    {
        /// <summary>
        /// 計算服務工廠
        /// </summary>
        private readonly CalculateFactory calculateFactory;

        /// <summary>
        /// 初始化注入服務
        /// </summary>
        /// <param name="calculateFactory">計算服務工廠</param>
        public CalculateController(CalculateFactory calculateFactory)
        {
            this.calculateFactory = calculateFactory;
        }

        /// <summary>
        /// 取得運算結果
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns></returns>
        [HttpPost("result")]
        public IActionResult GetCalculateResult(List<string> expression)
        {
            var service = calculateFactory.GetCalculateService(CalculateEnum.infix);
            var result = service.GetCalculateResult(expression);
            return Ok(result);
        }

        /// <summary>
        /// 取得中序表達式
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns></returns>
        [HttpPost("infix")]
        public IActionResult GetInfixResult(List<string> expression)
        {
            var service = calculateFactory.GetCalculateService(CalculateEnum.infix);
            var result = service.GetExpressionString(expression);
            return Ok(result);
        }

        /// <summary>
        /// 取得前序表達式
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns></returns>
        [HttpPost("prefix")]
        public IActionResult GetPrefixResult(List<string> expression)
        {
            var service = calculateFactory.GetCalculateService(CalculateEnum.prefix);
            var result = service.GetExpressionString(expression);
            return Ok(result);
        }

        /// <summary>
        /// 取得後序表達式
        /// </summary>
        /// <param name="expression">表達式</param>
        /// <returns></returns>
        [HttpPost("postfix")]
        public IActionResult GetPostfixResult(List<string> expression)
        {
            var service = calculateFactory.GetCalculateService(CalculateEnum.postfix);
            var result = service.GetExpressionString(expression);
            return Ok(result);
        }
    }
}
