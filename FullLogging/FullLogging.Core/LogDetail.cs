using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullLogging.Core
{
    public class LogDetail
    {
        public LogDetail()
        {
            Timestamp = DateTime.Now;

            AdditionalInfo = new Dictionary<string, object>();
        }

        public string Message { get; set; }

        public DateTime Timestamp { get; private set; }

        //WHERE QUESTIONS
        /// <summary>
        /// Name of the product that is being logged information.
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Backend or frontend log
        /// </summary>
        public string Layer { get; set; }

        /// <summary>
        /// Class name, file name, page name, etc
        /// </summary>
        public string Location { get; set; }

        public string Hostname { get; set; }

        //END WHERE QUESTIONS

        // WHO
        public string UserID { get; set; }

        public string UserName { get; set; }

        public int CustomerID { get; set; }

        public string CustomerName { get; set; }
        // END WHO

        // EVERYTHING ELSE
        public long? ElapsedMilliseconds { get; set; } // only for performance entries

        public Exception Exception { get; set; } // the exception for error logging

        public string CorrelationID { get; set; } // exception shielding from server to client

        public Dictionary<string, object> AdditionalInfo { get; private set; } // catch-all for anything else we want to log
        // END EVERYTHING ELSE
    }
}
