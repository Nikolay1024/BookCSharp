using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace AutoLotDataAccessLayer.Interception
{
    public class ConsoleWriterInterceptor : IDbCommandInterceptor
    {
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            WriteInfo("NonQueryExecuting", interceptionContext.IsAsync, command.CommandText);
        }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            WriteInfo("NonQueryExecuted", interceptionContext.IsAsync, command.CommandText);
        }
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            WriteInfo("ReaderExecuting", interceptionContext.IsAsync, command.CommandText);
        }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            WriteInfo("ReaderExecuted", interceptionContext.IsAsync, command.CommandText);
        }
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            WriteInfo("ScalarExecuting", interceptionContext.IsAsync, command.CommandText);
        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            WriteInfo("ScalarExecuted", interceptionContext.IsAsync, command.CommandText);
        }

        private void WriteInfo(string methodName, bool isAsync, string commandText)
        {
            Console.WriteLine($"{ methodName }\nIsAsync: { isAsync }\nCommandText: { commandText }\n");
        }
    }
}
