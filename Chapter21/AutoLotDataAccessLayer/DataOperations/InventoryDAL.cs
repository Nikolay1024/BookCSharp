using AutoLotDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataAccessLayer.DataOperations
{
    public class InventoryDAL
    {
        private SqlConnection SqlConnection = null;
        private readonly string ConnectionString;

        public InventoryDAL()
            : this(@"Data Source = NIK\SQLEXPRESS;Initial Catalog=AutoLot;Integrated Security=true")
        { }
        public InventoryDAL(string connectionString)
            => ConnectionString = connectionString;

        private void OpenConnection()
        {
            SqlConnection = new SqlConnection(ConnectionString);
            SqlConnection.Open();
        }
        private void CloseConnection()
        {
            if (SqlConnection?.State != ConnectionState.Closed)
                SqlConnection?.Close();
        }

        public List<Car> GetAllCars()
        {
            OpenConnection();
            // Здесь будут храниться записи.
            List<Car> inventory = new List<Car>();
            // Подготовить объект команды.
            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Inventory", SqlConnection))
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                while (sqlDataReader.Read())
                    inventory.Add(new Car
                    {
                        CarId = (int)sqlDataReader["CarId"],
                        Color = (string)sqlDataReader["Color"],
                        Make = (string)sqlDataReader["Make"],
                        Name = (string)sqlDataReader["Name"]
                    });
            return inventory;
        }
        public Car GetCarById(int id)
        {
            OpenConnection();
            Car car = null;
            string cmdText = $"SELECT * FROM Inventory WHERE CarId = {id}";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, SqlConnection))
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                if (sqlDataReader.Read())
                    car = new Car
                    {
                        CarId = (int)sqlDataReader["CarId"],
                        Color = (string)sqlDataReader["Color"],
                        Make = (string)sqlDataReader["Make"],
                        Name = (string)sqlDataReader["Name"]
                    };
            return car;
        }
        public void InsertCar(Car car)
        {
            OpenConnection();
            // Обратите внимание на "@заполнители" в запросе SQL.
            string cmdText = $"INSERT Inventory (Make, Color, Name) VALUES (@Make, @Color, @Name)";
            // Эта команда будет иметь внутренние параметры.
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, SqlConnection))
            {
                // Заполнить коллекцию параметров.
                sqlCommand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@Make", SqlDbType.Char, 10) { Value = car.Make },
                    new SqlParameter("@Color", SqlDbType.Char, 10) { Value = car.Color },
                    new SqlParameter("@Name", SqlDbType.Char, 10) { Value = car.Name }
                });
                sqlCommand.ExecuteNonQuery();
            }
            CloseConnection();
        }
        public void DeleteCar(int id)
        {
            OpenConnection();
            // Получить идентификатор автомобиля, подлежащего удалению, и удалить запись о нем.
            string cmdText = $"DELETE FROM Inventory WHERE CarId = '{id}'";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, SqlConnection))
            {
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Этот автомобиль уже заказан!\n{ex.Message}");
                }
            }
            CloseConnection();
        }
        public void UpdateCarName(int id, string name)
        {
            OpenConnection();
            // Получить идентификатор автомобиля для модификации дружественного имени,
            string cmdText = $"UPDATE Inventory SET Name = '{name}' WHERE CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(cmdText, SqlConnection))
                command.ExecuteNonQuery();
            CloseConnection();
        }
    }
}