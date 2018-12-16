﻿using FullLogging.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullLogging.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            LogDetail logDetail = GetLogDetail("Starting application");
            Logger.WriteDiagnosticLog(logDetail);

            var perfTracker = new PerformanceTracker("FullLogging.Console_Execution", string.Empty, logDetail.UserName, logDetail.Location, logDetail.Product, logDetail.Layer);

            try
            {
                var forcedException = new Exception("Something bad has happened!");

                forcedException.Data.Add("input param", "nothing to see here");

                throw forcedException;
            }
            catch (Exception ex)
            {
                logDetail = GetLogDetail(string.Empty, ex);

                Logger.WriteErrorLog(logDetail);
            }

            logDetail = GetLogDetail("used full logging console.");
            Logger.WriteUsageLog(logDetail);

            logDetail = GetLogDetail("Stopping app");
            Logger.WriteDiagnosticLog(logDetail);

            perfTracker.Stop();
        }

        private static LogDetail GetLogDetail(string message, Exception exception = null)
        {
            return new LogDetail()
            {
                Product = "FullLogging",
                Location = "FullLogging.Console", // this application
                Layer = "Job",
                UserName = Environment.UserName,
                Hostname = Environment.MachineName,
                Message = message,
                Exception = exception
            };
        }
    }
}