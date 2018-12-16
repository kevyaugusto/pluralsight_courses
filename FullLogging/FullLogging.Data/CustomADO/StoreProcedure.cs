using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullLogging.Data.CustomADO
{
    public class StoreProcedure
    {
        private SqlCommand Command { get; set; }

        public StoreProcedure(SqlConnection sqlConnection, string procedureName, int timeoutSeconds = 30)
        {
            Command = new SqlCommand(procedureName, sqlConnection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            if (timeoutSeconds > 30)
                Command.CommandTimeout = timeoutSeconds;
        }

        public void AddParameter(string parameterName, object parameterValue)
        {
            Command.Parameters.Add(new SqlParameter(parameterName, parameterValue ?? DBNull.Value));
        }

        public int ExecuteNonQuery()
        {
            try
            {
                return Command.ExecuteNonQuery(); // return number of rows affected.
            }
            catch (Exception ex)
            {
                throw CreateProcedureException(ex);
            }
        }

        private Exception CreateProcedureException(Exception ex)
        {
            var newException = new Exception("Stored Procedure call failed!", ex);

            newException.Data.Add("Procedure", Command.CommandText);
            newException.Data.Add("Procedure Parameters", GetParameters());

            return newException;
        }

        private object GetParameters()
        {
            var sbParameters = new StringBuilder();

            for (int i = 0; i < Command.Parameters.Count; i++)
            {
                var param = Command.Parameters[i];
                sbParameters.Append($"{param.ParameterName}={param.Value}|");
            }

            return sbParameters.ToString();
        }
    }
}
