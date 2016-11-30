using System;
using System.Collections.Generic;
using LTF.Models.Enums;
using LTF.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LTF.Interfaces
{
    partial interface ILogLogic
    {
        void Debug(string msg, int userId, string requestUrl);

        void Info(string msg, int userId, string requestUrl);

        void Warn(string msg, int userId, string requestUrl);

        void Error(Exception exception, int? userId, string requestUrl);


        List<LogInfo> GetLogInfo(LogLevelEnum logLevel, DateTime startDate, DateTime endDate);

    }
}
