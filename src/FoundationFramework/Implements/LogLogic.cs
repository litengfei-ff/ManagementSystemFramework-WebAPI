using System;
using LTF.Models.Enums;

namespace LTF.Implements
{
    public partial class LogLogic
    {
        public void Debug(string info, int userId, string requestUrl)
        {
            Add(new Models.DomainModel.Log
            {
                LogLevel = LogLevelEnum.Debug.ToString(),
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
                LogLevel = LogLevelEnum.Information.ToString(),
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
                LogLevel = LogLevelEnum.Warn.ToString(),
                Msg = info,
                NavUserId = userId,
                RequestUrl = requestUrl
            });
            SaveChanges();
        }

        public void Error(Exception excep, int userId, string requestUrl)
        {
            Add(new Models.DomainModel.Log
            {
                LogLevel = LogLevelEnum.Error.ToString(),
                Msg = excep.Message,
                StackTrace = excep.StackTrace,
                NavUserId = userId,
                RequestUrl = requestUrl
            });
            SaveChanges();
        }
    }
}
