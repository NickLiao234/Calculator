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
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : Controller
    {
        private readonly CalculateFactory calculateFactory;

        public CalculateController(CalculateFactory calculateFactory)
        {
            this.calculateFactory = calculateFactory;
        }
        [HttpPost("result")]
        public IActionResult GetCalculateResult(List<string> expression)
        {
            var service = calculateFactory.GetCalculateService(CalculateEnum.postfix);
            var result = service.GetCalculateResult(expression);
            return Ok(result);
        }

        [HttpPost("infix")]
        public IActionResult GetInfixResult(List<string> expression)
        {
            var service = calculateFactory.GetCalculateService(CalculateEnum.infix);
            var result = service.GetExpressionString(expression);
            return Ok(result);
        }

        [HttpPost("prefix")]
        public IActionResult GetPrefixResult(List<string> expression)
        {
            var service = calculateFactory.GetCalculateService(CalculateEnum.prefix);
            var result = service.GetExpressionString(expression);
            return Ok(result);
        }

        [HttpPost("postfix")]
        public IActionResult GetPostfixResult(List<string> expression)
        {
            var service = calculateFactory.GetCalculateService(CalculateEnum.postfix);
            var result = service.GetExpressionString(expression);
            return Ok(result);
        }
    }
}
