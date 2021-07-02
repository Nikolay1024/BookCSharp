using System;
using System.Configuration;
using System.Data.Common;

namespace DataProviderFactoryApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Фабрика поставщиков данных");
            // Получить строку подключения и поставщик из файла *.config,
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            // Получить фабрику поставщиков.
            DbProviderFactory providerFactory = DbProviderFactories.GetFactory(dataProvider);
            // Получить объект подключения.
            using (DbConnection сonnection = providerFactory.CreateConnection())
            {
                if (сonnection == null)
                {
                    ShowError("Connection");
                    return;
                }
                Console.WriteLine($"Объект подключения: {сonnection.GetType().Name}");
                сonnection.ConnectionString = connectionString;
                сonnection.Open();
                // Создать объект команды.
                DbCommand command = providerFactory.CreateCommand();
                if (command == null)
                {
                    ShowError("Command");
                    return;
                }
                Console.WriteLine($"Объект команды: {command.GetType().Name}");
                command.Connection = сonnection;
                command.CommandText = "SELECT * FROM Inventory";
                // Вывести данные с помощью объекта чтения данных.
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    Console.WriteLine($"Объект чтения данных: {dataReader.GetType().Name}");
                    Console.WriteLine("***** SELECT * FROM Inventory *****");
                    while (dataReader.Read())
                        Console.WriteLine($"-> Машина CarId={dataReader["CarId"] } Make={dataReader["Make"]}");
                }
                Console.ReadLine();
            }
        }
        static void ShowError(string objectName)
        {
            Console.WriteLine($"Возникла проблема с созданием объекта: {objectName}");
            Console.ReadLine();
        }
    }
}
