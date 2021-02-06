using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using MySqlConnector;
using AutoLotDAL.Models;

namespace AutoLotDAL.DataOperations
{
    public class InventoryDAL
    {
        private readonly string _connectionString;
        public InventoryDAL() : this(@"Server=localhost;User ID=root;Password=administrator;Database=autolot")
        {

        }

        public InventoryDAL(string connectionString) => _connectionString = connectionString;

        private MySqlConnection _sqlConnection = null;
        private void OpenConnection()
        {
            _sqlConnection = new MySqlConnection(_connectionString);
            _sqlConnection.Open();
        }

        private void CloseConnection()
        {
            if (_sqlConnection.State != ConnectionState.Closed)
            {
                _sqlConnection.Close();
            }
        }

        public List<Car> GetAllInventory()
        {
            OpenConnection();
            List<Car> inventory = new List<Car>();
            string sql = "SELECT * FROM INVENTORY";
            using (MySqlCommand command = new MySqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                MySqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    inventory.Add(new Car
                    {
                        CarId = (int)(dataReader["CarId"]),
                        Make = (string)dataReader["Make"],
                        Color = (string)dataReader["Color"],
                        PetName = (string)dataReader["PetName"]
                    });
                }
                dataReader.Close();
            };
            
            return inventory;
        }

        public Car GetCar(int carId)
        {
            Car car = null;
            OpenConnection();
            string sql = $"SELECT * FROM INVENTORY WHERE CarId = {carId.ToString()}";
            using (MySqlCommand command = new MySqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                MySqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    car = new Car                                        
                    {
                        CarId = (int)(dataReader["CarId"]),
                        Make = (string)dataReader["Make"],
                        Color = (string)dataReader["Color"],
                        PetName = (string)dataReader["PetName"]
                    };

                }
            }
            return car;
        }

        public void InsertAuto (string make, string color, string petName)
        {
            OpenConnection();
            string sql = $"INSERT INTO INVENTORY Make, Color, Petname VALUES '{make}', '{color}', '{petName}'";
            using (MySqlCommand command = new MySqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void InsertAuto(Car car)
        {
            OpenConnection();
            string sql = $"INSERT INTO INVENTORY Make, Color, Petname VALUES '{car.Make}', '{car.Color}', '{car.PetName}'";
            using (MySqlCommand command = new MySqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void DeleteCar (int carId)
        {
            OpenConnection();
            string sql = $"DELETE FROM INVENTORY WHERE CarId = '{carId.ToString()}'";
            using (MySqlCommand command = new MySqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Sorry, failed to delete car with Id {carId.ToString()}", ex);
                }
            }
            CloseConnection();
        }


        public void UpdateCarPetName(int carId, string newPetName)
        {
            OpenConnection();
            string sql = $"UPDATE INVENTORY SET PetName = '{newPetName}' WHERE CarId = '{carId.ToString()}'";
            using (MySqlCommand command = new MySqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new Exception($"Sorry, failed to update car with Id {carId.ToString()}", ex);
                }
            }
            CloseConnection();
        }

        public void ProcessCreditRisk (bool throwEx, int custId)
        {
            OpenConnection();
            // First look up current name based on Customer ID
            string fName, lName;
            var cmdSelect = new MySqlCommand($"SELECT * FROM CUSTOMERS WHERE CustId = '{custId.ToString()}'", _sqlConnection);
            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    fName = (string)dataReader["FirstName"];
                    lName = (string)dataReader["LastName"];
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }
            var cmdRemove = new MySqlCommand ($"DELETE FROM CUSTOMERS WHERE CustId = {custId}", _sqlConnection);
            var cmdInsert = new MySqlCommand ($"INSERT INTO CREDITRISKS (FirstName, LastName) VALUES ('{fName}', '{lName}')", _sqlConnection);

            MySqlTransaction tx = null;
            try
            {
                tx = _sqlConnection.BeginTransaction();
                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;
                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();

                if (throwEx)
                {
                    throw new Exception("Sorry it went wrong Tx failed...");
                }
                tx.Commit();
            }


            catch (Exception ex)
            {
                Console.WriteLine($"Failure ---> {ex.Message}\n {ex.ToString()}");
                tx?.Rollback();
            }

            finally
            {
                CloseConnection();
            }

        }
    }
}
