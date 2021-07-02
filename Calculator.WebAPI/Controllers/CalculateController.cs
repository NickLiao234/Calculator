using Calculator.Core.Service.Calculate;
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
        private readonly CalculateServiceBase calculateService;

        public CalculateController(CalculateServiceBase calculateService)
        {
            this.calculateService = calculateService;
        }
        [HttpPost("result")]
        public IActionResult GetCalculateResult(List<string> expression)
        {
            var result = calculateService.GetCalculateResult(expression);
            return Ok(result);
        }

        [HttpPost("postfix")]
        public IActionResult GetPostfixResult(List<string> expression)
        {
            var result = calculateService.GetExpressionString(expression);
            return Ok(result);
        }


    }
}
