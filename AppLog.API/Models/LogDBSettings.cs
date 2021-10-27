using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLog.API.Models
{
    public interface ILogDBSettings
    {
        string ApplicationName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class LogDBSettings : ILogDBSettings
    {
        public string ApplicationName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
