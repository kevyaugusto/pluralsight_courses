using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullLogging.Core
{
    public class PerformanceTracker
    {
        private readonly Stopwatch _stopwatch;

        private readonly LogDetail _logDetail;

        public PerformanceTracker(string name, string userID, string userName, string location,
            string product, string layer)
        {
            _stopwatch = Stopwatch.StartNew();

            _logDetail = new LogDetail()
            {
                Message = name,
                UserID = userID,
                UserName = userName,
                Product = product,
                Layer = layer,
                Location = location,
                Hostname = Environment.MachineName
            };

            var beginTime = DateTime.Now;

            _logDetail.AdditionalInfo.Add("Started", beginTime.ToString(CultureInfo.InvariantCulture));
        }

        public PerformanceTracker(string name, string userID, string userName, string location,
            string product, string layer, Dictionary<string, object> additionalInfo)
            : this(name, userID, userName, location, product, layer)
        {
            foreach (var item in additionalInfo)
                _logDetail.AdditionalInfo.Add($"input-{item.Key}", item.Value);
        }

        public void Stop()
        {
            _stopwatch.Stop();

            _logDetail.ElapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

            Logger.WritePerformanceLog(_logDetail);
        }
    }
}