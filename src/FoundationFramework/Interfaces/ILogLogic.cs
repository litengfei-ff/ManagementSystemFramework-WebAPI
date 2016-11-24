using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoundationFramework.Interfaces
{
    partial interface ILogLogic
    {
        void Debug(string msg, int userId, string requestUrl);

        void Info(string msg, int userId, string requestUrl);

        void Warn(string msg, int userId, string requestUrl);

        void Error(Exception exception, int userId, string requestUrl);

    }
}
