using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSecurity2._0
{
    public class ActivityLogger
    {
        private List<string> logs = new List<string>();

        public void AddLog(string message)
        {
            logs.Add($"{DateTime.Now}: {message}");
        }

        public List<string> GetLatestLogs()
        {
            return logs.TakeLast(10).ToList();
        }
    }
}