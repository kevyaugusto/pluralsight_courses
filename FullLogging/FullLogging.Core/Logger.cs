using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullLogging.Core
{
    public static class Logger
    {
        private static readonly Serilog.ILogger _performanceLogger;
        private static readonly Serilog.ILogger _usageLogger;
        private static readonly Serilog.ILogger _errorLogger;
        private static readonly Serilog.ILogger _diagnosticLogger;

        private static readonly string _logFilesPath = ConfigurationManager.AppSettings["LogFilesPath"];

        static Logger()
        {
            _performanceLogger = new LoggerConfiguration()
                .WriteTo.File(path: $@"{_logFilesPath}performancelog.txt")
                .CreateLogger();

            _usageLogger = new LoggerConfiguration()
                .WriteTo.File(path: $@"{_logFilesPath}usagelog.txt")
                .CreateLogger();

            _errorLogger = new LoggerConfiguration()
                .WriteTo.File(path: $@"{_logFilesPath}errorlog.txt")
                .CreateLogger();

            _diagnosticLogger = new LoggerConfiguration()
                .WriteTo.File(path: $@"{_logFilesPath}diagnosticlog.txt")
                .CreateLogger();
        }

        public static void WritePerformanceLog(LogDetail logDetail)
        {
            _performanceLogger.Write(LogEventLevel.Information, "{@LogDetail}", logDetail);
        }

        public static void WriteUsageLog(LogDetail logDetail)
        {
            _usageLogger.Write(LogEventLevel.Information, "{@LogDetail}", logDetail);
        }

        public static void WriteErrorLog(LogDetail logDetail)
        {
            _errorLogger.Write(LogEventLevel.Information, "{@LogDetail}", logDetail);
        }

        public static void WriteDiagnosticLog(LogDetail logDetail)
        {
            var enabledDiagnostics = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDiagnostics"]);

            if (!enabledDiagnostics) return;
            
            _diagnosticLogger.Write(LogEventLevel.Information, "{@LogDetail}", logDetail);
        }
    }
}
