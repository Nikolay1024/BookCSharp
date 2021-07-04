using System;
using System.Data.SqlClient;

namespace AutoLotDataReaderApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Полный пример фабрики поставщиков данных");
            // Создать строку подключения с помощью объекта построителя.
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"NIK\SQLEXPRESS",
                InitialCatalog = "AutoLot",
                ConnectTimeout = 30,
                IntegratedSecurity = true
            };
            // Создать и открыть подключение.
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = sqlConnectionStringBuilder.ConnectionString;
                sqlConnection.Open();
                ShowConnectionStatus(sqlConnection);
                // Создать объект команды SQL.
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Inventory; SELECT * FROM Customers", sqlConnection);
                // Получить объект чтения данных с помощью ExecuteReader().
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    Console.WriteLine($"*****Запрос: {sqlCommand.CommandText}*****");
                    do
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.Write("-> ");
                            for (int i = 0; i < sqlDataReader.FieldCount; i++)
                                Console.Write($"{sqlDataReader.GetName(i)}: {sqlDataReader.GetValue(i)}; ");
                            Console.WriteLine();
                        }
                    } while (sqlDataReader.NextResult());
                }
            }
            Console.ReadLine();
        }

        static void ShowConnectionStatus(SqlConnection sqlConnection)
        {
            Console.WriteLine("*****Сведения о объекте подключения*****");
            Console.WriteLine($"-> Версия SQL Server: {sqlConnection.ServerVersion}");
            Console.WriteLine($"-> Местоположение базы данных: {sqlConnection.DataSource}");
            Console.WriteLine($"-> Имя базы данных: {sqlConnection.Database}");
            Console.WriteLine($"-> Таймаут: {sqlConnection.ConnectionTimeout}");
            Console.WriteLine($"-> Состояние: {sqlConnection.State}\n");
        }
    }
}
