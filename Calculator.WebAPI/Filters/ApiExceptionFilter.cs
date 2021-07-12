using Calculator.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.WebAPI.Filters
{
    /// <summary>
    /// exception filter
    /// </summary>
    public class ApiExceptionFilter : IAsyncExceptionFilter
    {
        /// <summary>
        /// 執行例外處理
        /// </summary>
        /// <param name="context">httpcontext</param>
        /// <returns>task</returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            //var result = new Result();
            if (context.Exception is CalculateException)
            {
                var ex = context.Exception as CalculateException;
                //result.Messages = ex.Message;
                context.HttpContext.Response.StatusCode = ex.StatusCode;
                context.Result = new JsonResult(ex.Message)
                {
                    ContentType = "application/json"
                };
            }
            else
            {
                context.HttpContext.Response.StatusCode = 500;
                context.Result = new JsonResult(context.Exception.Message)
                {
                    ContentType = "application/json"
                };
            }
            return Task.CompletedTask;
        }
    }
}
