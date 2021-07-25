using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AutoLotDataAccessLayer.BulkImport
{
    public class ProcessBulkImport
    {
        private static SqlConnection SqlConnection;
        private static readonly string ConnectionString
            = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

        private static void OpenConnection()
        {
            SqlConnection = new SqlConnection(ConnectionString);
            SqlConnection.Open();
        }
        private static void CloseConnection()
        {
            if (SqlConnection?.State != ConnectionState.Closed)
                SqlConnection?.Close();
        }
        public static void ExecuteBulkImport<T>(IEnumerable<T> records, string tableName)
        {
            OpenConnection();
            using (SqlConnection sqlConnection = SqlConnection)
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConnection) { DestinationTableName = tableName })
            using (MyDataReader<T> myDataReader = new MyDataReader<T>(records.ToList()))
                try
                {
                    sqlBulkCopy.WriteToServer(myDataReader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }
    }
}
