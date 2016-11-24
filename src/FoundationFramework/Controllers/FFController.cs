using System;
using System.IO;
using FoundationFramework.Filter;
using FoundationFramework.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace FoundationFramework.Controllers
{
    /// <summary>
    /// 控制器基类  提供访问配置文件，写日志，根据Token获取用户信息等方法
    /// </summary>
    [Authorize]
    [TypeFilter(typeof(ExceptionFilter))]
    public class FFController : Controller
    {
        protected IConfigurationRoot Configuration;
        protected ILogLogic logLogic { get; }
        protected IUserInfoLogic userLogic { get; }
        protected IDepartmentLogic deptLogic { get; }
        protected string userJobNumber => GetJobNumberFromToken();
        protected int userId => userLogic.GetUserIdByJobNumber(userJobNumber) ?? Convert.ToInt32(Configuration["Log:AnonymousUserId"]);

        /// <summary>
        /// 注入各个实体
        /// </summary>
        /// <param name="iLogLogic"></param>
        /// <param name="iuserLogic"></param>
        /// <param name="ideptLogic"></param>
        public FFController(ILogLogic iLogLogic, IUserInfoLogic iuserLogic, IDepartmentLogic ideptLogic)
        {
            logLogic = iLogLogic;
            userLogic = iuserLogic;
            deptLogic = ideptLogic;

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
