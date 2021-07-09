using Calculator.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.WebAPI.Filters
{
    public class ApiExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {

            if (context.Exception is CalculateException)
            {
                var ex = context.Exception as CalculateException;
                context.Result = new JsonResult(ex.Message)
                {
                    StatusCode = ex.StatusCode,
                    ContentType = "application/json"
                };
            }
            else
            {
                context.HttpContext.Response.StatusCode = 500;
                context.Result = new JsonResult(context.Exception.Message);
            }

            return Task.CompletedTask;
        }
    }
}
