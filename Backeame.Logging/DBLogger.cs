using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository.Hierarchy;
using log4net.Appender;

namespace Backeame.Logging
{
    public static class DBLogger
    {
        private static ILog log;

        public static void LogException(Exception ex, string location)
        {
            XmlConfigurator.Configure();
            log = LogManager.GetLogger(location);
            log.Error(ex.Message, ex);
        }

        public static void LogMessage(string message, string location)
        {
            XmlConfigurator.Configure();
            log = LogManager.GetLogger(location);
            log.Info(message);
        }
    }
}
