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
        public Car GetCar(int carId)
        {
            OpenConnection();
            Car car = null;
            string cmdText = $"SELECT * FROM Inventory WHERE CarId = {carId}";
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
            // Обратите внимание на "@параметры заполнители" в запросе SQL.
            string cmdText = $"INSERT Inventory (Make, Color, Name) VALUES (@Make, @Color, @Name)";
            // Эта команда будет иметь внутренние параметры.
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, SqlConnection))
            {
                // Заполнить коллекцию параметров.
                sqlCommand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@Make", SqlDbType.NVarChar, 50) { Value = car.Make },
                    new SqlParameter("@Color", SqlDbType.NVarChar, 50) { Value = car.Color },
                    new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = car.Name }
                });
                sqlCommand.ExecuteNonQuery();
            }
            CloseConnection();
        }
        public void DeleteCar(int carId)
        {
            OpenConnection();
            // Получить идентификатор автомобиля, подлежащего удалению, и удалить запись о нем.
            string cmdText = $"DELETE FROM Inventory WHERE CarId = '{carId}'";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, SqlConnection))
            {
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Этот автомобиль уже заказан!", ex);
                }
            }
            CloseConnection();
        }
        public void UpdateCarName(int carId, string carName)
        {
            OpenConnection();
            // Получить идентификатор автомобиля для модификации дружественного имени.
            string cmdText = $"UPDATE Inventory SET Name = '{carName}' WHERE CarId = '{carId}'";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, SqlConnection))
                sqlCommand.ExecuteNonQuery();
            CloseConnection();
        }
        public string GetCarName(int carId)
        {
            OpenConnection();
            string carName;
            // Установить имя хранимой процедуры.
            using (SqlCommand sqlCommand = new SqlCommand("GetName", SqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddRange(new SqlParameter[]
                {
                    // Входной параметр.
                    new SqlParameter("@carId", SqlDbType.Int) { Value = carId, Direction = ParameterDirection.Input },
                    // Выходной параметр.
                    new SqlParameter("@carName", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output }
                });

                // Выполнить хранимую процедуру.
                sqlCommand.ExecuteNonQuery();
                // Возвратить выходной параметр.
                carName = (string)sqlCommand.Parameters["@carName"].Value;
                CloseConnection();
            }
            return carName;
        }
    }
}