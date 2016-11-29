using System;
using Newtonsoft.Json;

namespace LTF.Models.DomainModel
{

    public partial class Log : BaseEntity
    {
        public int? NavUserId { get; set; }

        public User NavUser { get; set; }

        public string LogLevel { get; set; }

        public string RequestUrl { get; set; }

        public string Msg { get; set; }

        public string StackTrace { get; set; }

        public System.DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
