using AutoLotDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataAccessLayer.DataOperations
{
    public class InventoryDAL
    {
        private SqlConnection SqlConnection = null;
        private readonly string ConnectionString;

        public InventoryDAL()
            : this(ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString)
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

        public List<Car> ReadAllCars()
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
                        CarId = (int)sqlDataReader["car_id"],
                        Color = (string)sqlDataReader["color"],
                        Make = (string)sqlDataReader["make"],
                        Name = (string)sqlDataReader["name"]
                    });
            return inventory;
        }
        public Car ReadCar(int carId)
        {
            OpenConnection();
            Car car = null;
            string cmdText = $"SELECT * FROM Inventory WHERE car_id = {carId}";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, SqlConnection))
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                if (sqlDataReader.Read())
                    car = new Car
                    {
                        CarId = (int)sqlDataReader["car_id"],
                        Color = (string)sqlDataReader["color"],
                        Make = (string)sqlDataReader["make"],
                        Name = (string)sqlDataReader["name"]
                    };
            return car;
        }
        public void CreateCar(Car car)
        {
            OpenConnection();
            // Обратите внимание на "@параметры заполнители" в запросе SQL.
            string cmdText = $"INSERT Inventory (make, color, name) VALUES (@make, @color, @name)";
            // Эта команда будет иметь внутренние параметры.
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, SqlConnection))
            {
                // Заполнить коллекцию параметров.
                sqlCommand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@make", SqlDbType.NVarChar, 50) { Value = car.Make },
                    new SqlParameter("@color", SqlDbType.NVarChar, 50) { Value = car.Color },
                    new SqlParameter("@name", SqlDbType.NVarChar, 50) { Value = car.Name }
                });
                sqlCommand.ExecuteNonQuery();
            }
            CloseConnection();
        }
        public void DeleteCar(int carId)
        {
            OpenConnection();
            // Получить идентификатор автомобиля, подлежащего удалению, и удалить запись о нем.
            string cmdText = $"DELETE FROM Inventory WHERE car_id = '{carId}'";
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
        public void UpdateCarName(int carId, string newCarName)
        {
            OpenConnection();
            // Получить идентификатор автомобиля для модификации дружественного имени.
            string cmdText = $"UPDATE Inventory SET name = '{newCarName}' WHERE car_id = '{carId}'";
            using (SqlCommand sqlCommand = new SqlCommand(cmdText, SqlConnection))
                sqlCommand.ExecuteNonQuery();
            CloseConnection();
        }
        public string ReadCarName(int carId)
        {
            OpenConnection();
            string carName;
            // Установить имя хранимой процедуры.
            using (SqlCommand sqlCommand = new SqlCommand("ReadCarName", SqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddRange(new SqlParameter[]
                {
                    // Входной параметр.
                    new SqlParameter("@car_id", SqlDbType.Int) { Value = carId, Direction = ParameterDirection.Input },
                    // Выходной параметр.
                    new SqlParameter("@car_name", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output }
                });

                // Выполнить хранимую процедуру.
                sqlCommand.ExecuteNonQuery();
                // Возвратить выходной параметр.
                carName = (string)sqlCommand.Parameters["@car_name"].Value;
                CloseConnection();
            }
            return carName;
        }
        public void MoveCustomerToCreditRisk(bool throwEx, int customerId)
        {
            OpenConnection();
            // Первым делом найти текущее имя по идентификатору клиента.
            string firstName, lastName;
            SqlCommand sqlCmdSelect = new SqlCommand($"SELECT * FROM Customers WHERE customer_id = @customer_id", SqlConnection);
            sqlCmdSelect.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Int) { Value = customerId });
            using (SqlDataReader sqlDataReader = sqlCmdSelect.ExecuteReader())
            {
                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    firstName = (string)sqlDataReader["first_name"];
                    lastName = (string)sqlDataReader["last_name"];
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }
            // Создать объекты команд, которые представляют каждый шаг операции.
            SqlCommand sqlCmdDelete = new SqlCommand($"DELETE FROM Customers WHERE customer_id = @customer_id", SqlConnection);
            sqlCmdDelete.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Int) { Value = customerId });
            SqlCommand sqlCmdInsert = new SqlCommand("INSERT CreditRisks (first_name, last_name) VALUES (@first_name, @last_name)", SqlConnection);
            sqlCmdInsert.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@first_name", SqlDbType.NVarChar, 50) { Value = firstName },
                new SqlParameter("@last_name", SqlDbType.NVarChar, 50) { Value = lastName }
            });
            // Это будет получено из объекта подключения.
            SqlTransaction sqlTransaction = null;
            try
            {
                sqlTransaction = SqlConnection.BeginTransaction();
                // Включить команды в транзакцию.
                sqlCmdInsert.Transaction = sqlTransaction;
                sqlCmdDelete.Transaction = sqlTransaction;
                // Выполнить команды.
                sqlCmdInsert.ExecuteNonQuery();
                sqlCmdDelete.ExecuteNonQuery();
                // Эмулировать ошибку.
                if (throwEx)
                    throw new Exception("Возникла ошибка, связанная с базой данных! Отказ транзакции...");
                // Зафиксировать транзакцию!
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Любая ошибка приведет к откату транзакции.
                // Использовать условную операцию для проверки на предмет null.
                sqlTransaction?.Rollback();
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}