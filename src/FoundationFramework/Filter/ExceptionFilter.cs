using System;
using System.IO;
using FoundationFramework.Interfaces;
using FoundationFramework.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;

namespace FoundationFramework.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        private IConfigurationRoot Configuration;
        private ILogLogic logLogic { get; }
        private int userId => Convert.ToInt32(Configuration["Log:AnonymousUserId"]);

        public ExceptionFilter(ILogLogic iLogLogic)
        {
            logLogic = iLogLogic;

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            Configuration = builder.Build();
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

                logLogic.Error(context.Exception, userId, requestUrl);

                context.ExceptionHandled = true;
            }
        }
    }
}
