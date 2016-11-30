using System;
using LTF.Models.Enums;
using Newtonsoft.Json;

namespace LTF.Models.ViewModel
{
    public class LogInfo
    {
        public string UserName { get; set; }

        public string LogLevel { get; set; }

        public string RequestUrl { get; set; }

        public string Msg { get; set; }

        public string StackTrace { get; set; }

        public string CreateTime { get; set; } 
    }
}
