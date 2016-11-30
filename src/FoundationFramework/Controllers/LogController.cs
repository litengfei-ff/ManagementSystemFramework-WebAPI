using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTF.Interfaces;
using LTF.Models.DomainModel;
using LTF.Models.Enums;
using LTF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LTF.Controllers
{
    [Route("api/[controller]")]
    public class LogController : MasterController
    {
        public LogController(IUserLogic iuserLogic, ILogLogic logLogic) : base(iuserLogic, logLogic)
        {
        }

        [HttpGet]
        public Ret<List<LogInfo>> Get([FromQuery]LogLevelEnum logLevel, [FromQuery]DateTime startDate, [FromQuery]DateTime endDate)
        {
            return new Ret<List<LogInfo>>
            {
                ReCode = Models.Enums.ReCodeEnum.Success,
                Msg = "成功获取日志列表",
                Data = logLogic.GetLogInfo(logLevel, startDate, endDate)
            };
        }


    }
}
