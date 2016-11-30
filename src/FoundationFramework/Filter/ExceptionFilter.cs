using System;
using System.IO;
using LTF.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace LTF.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        private ILogLogic logLogic { get; }

        public ExceptionFilter(ILogLogic iLogLogic)
        {
            logLogic = iLogLogic;
        }

        /// <summary>
        /// 发生异常记录到日志 并返回BadRequest
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            //异常未被处理之前进行处理
            if (!context.ExceptionHandled)
            {
                string requestUrl = context.HttpContext.Request.Path;
                string httpMethod = context.HttpContext.Request.Method;
                context.Result = new BadRequestResult();

                logLogic.Error(context.Exception, null, requestUrl);

                context.ExceptionHandled = true;
            }
        }
    }
}
