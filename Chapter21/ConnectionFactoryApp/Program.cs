using System;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace ConnectionFactoryApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Абстрагирование поставщиков данных с использованием интерфейсов");
            // Прочитать ключ provider.
            string dataProviderString = ConfigurationManager.AppSettings["provider"];
            // Преобразовать строку в перечисление.
            bool successParse = Enum.TryParse(dataProviderString, out DataProvider dataProvider);
            if (!successParse || dataProvider == DataProvider.None)
            {
                Console.WriteLine("Поставщики отсутствуют");
                Console.ReadLine();
                return;
            }

            // Получить конкретное подключение.
            IDbConnection dbConnection = GetConnection(dataProvider);
            Console.WriteLine($"Ваше подключение: { dbConnection.GetType().Name }");
            // Открыть, использовать и закрыть подключение...
            Console.ReadLine();
        }

        // Этот метод возвращает конкретный объект подключения
        // на основе значения перечисления DataProvider.
        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection dbConnection = null;
            switch (dataProvider)
            {
                case DataProvider.SqlServer:
                    dbConnection = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    dbConnection = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    dbConnection = new OdbcConnection();
                    break;
            }
            return dbConnection;
        }

    }
}
