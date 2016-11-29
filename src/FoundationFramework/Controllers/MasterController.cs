using System;
using System.IO;
using LTF.Filter;
using LTF.Interfaces;
using LTF.Models.DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LTF.Controllers
{
    /// <summary>
    /// 控制器基类  提供访问配置文件，写日志，根据Token获取用户信息等方法 
    /// </summary>
    [Authorize]
    [TypeFilter(typeof(ExceptionFilter))]
    public class MasterController : Controller
    {
        protected IConfigurationRoot Configuration;

        protected IUserLogic userLogic { get; }

        protected ILogLogic logLogic { get; }

        protected string userJobNumber => GetJobNumberFromToken();

        protected User userInfo => userLogic.GetUserByJobNumber(userJobNumber);

        /// <summary>
        /// 注入用户逻辑处理方法
        /// </summary>
        public MasterController(IUserLogic iuserLogic, ILogLogic logLogic)
        {
            userLogic = iuserLogic;
            this.logLogic = logLogic;

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }


        /// <summary>
        /// 根据Token获取jognumber
        /// </summary>
        /// <returns></returns>
        private string GetJobNumberFromToken()
        {
            foreach (var claim in User.Claims)
            {
                if (claim.Issuer == Configuration["JWT:Issuer"])
                {
                    return claim.Value;
                }
            }
            return null;
        }



    }
}
