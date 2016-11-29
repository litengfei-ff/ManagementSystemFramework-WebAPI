using System;

namespace LTF.Interfaces
{
    partial interface ILogLogic
    {
        void Debug(string msg, int userId, string requestUrl);

        void Info(string msg, int userId, string requestUrl);

        void Warn(string msg, int userId, string requestUrl);

        void Error(Exception exception, int userId, string requestUrl);

    }
}
