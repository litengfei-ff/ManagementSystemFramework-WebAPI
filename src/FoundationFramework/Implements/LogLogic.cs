using System;
using System.Collections.Generic;
using LTF.Models.Enums;
using LTF.Models.ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LTF.Implements
{
    public partial class LogLogic
    {
        public void Debug(string info, int userId, string requestUrl)
        {
            Add(new Models.DomainModel.Log
            {
                LogLevel = LogLevelEnum.Debug,
                Msg = info,
                NavUserId = userId,
                RequestUrl = requestUrl
            });
            SaveChanges();
        }

        public void Info(string info, int userId, string requestUrl)
        {
            Add(new Models.DomainModel.Log
            {
                LogLevel = LogLevelEnum.Information,
                Msg = info,
                NavUserId = userId,
                RequestUrl = requestUrl
            });
            SaveChanges();
        }

        public void Warn(string info, int userId, string requestUrl)
        {
            Add(new Models.DomainModel.Log
            {
                LogLevel = LogLevelEnum.Warn,
                Msg = info,
                NavUserId = userId,
                RequestUrl = requestUrl
            });
            SaveChanges();
        }

        public void Error(Exception excep, int? userId, string requestUrl)
        {
            Add(new Models.DomainModel.Log
            {
                LogLevel = LogLevelEnum.Error,
                Msg = excep.Message,
                StackTrace = excep.StackTrace,
                NavUserId = userId,
                RequestUrl = requestUrl
            });
            SaveChanges();
        }

        public List<LogInfo> GetLogInfo(LogLevelEnum logLevel, DateTime startDate, DateTime endDate)
        {

            return this.context.Log.Include(p => p.NavUser)
                  .Where(p => p.DelFlag == (int)DelFlagEnum.Normal
                      & (logLevel == 0 || p.LogLevel == logLevel)
                      & (startDate == DateTime.MinValue || p.CreateTime >= startDate)
                      & (endDate == DateTime.MinValue || p.CreateTime <= endDate)
                  )
                  .OrderByDescending(p => p.CreateTime)
                  .Select(l => new LogInfo
                  {
                      CreateTime = l.CreateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                      LogLevel = l.LogLevel.ToString(),
                      Msg = l.Msg,
                      RequestUrl = l.RequestUrl,
                      StackTrace = l.StackTrace,
                      UserName = l.NavUser.Name
                  }).ToList();
        }
    }
}
