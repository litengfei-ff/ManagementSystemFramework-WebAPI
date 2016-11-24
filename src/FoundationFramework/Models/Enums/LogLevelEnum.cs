using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoundationFramework.Models.Enums
{
    public enum LogLevelEnum
    {
        /// <summary>
        /// 致命的
        /// </summary>
        Fatal,
        /// <summary>
        /// 程序出现错误
        /// </summary>
        Error,
        /// <summary>
        /// 警告
        /// </summary>
        Warn,
        /// <summary>
        /// 消息
        /// </summary>
        Information,
        /// <summary>
        /// 调试信息
        /// </summary>
        Debug
    }
}
