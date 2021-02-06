using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace AutoLotDAL.BulkImport
{
    public static class ProcessBulkImport
    {
        private static MySqlConnection _sqlConnection = null;
        private static readonly string _connectionString = @"Server=localhost;User ID=root;Password=administrator;Database=autolot; Allowloadlocalinfile=true";
        private static void OpenConnection()
        {
            _sqlConnection = new MySqlConnection(_connectionString);
            _sqlConnection.Open();
        }
        private static void CloseConnetion()
        {
            if (_sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Close();
            }
        }

        public static void ExecuteBulkImport<T>(IEnumerable<T> records, string tableName)
        {
            OpenConnection();
            using (MySqlConnection conn = _sqlConnection)
            {
                MySqlBulkCopy bc = new MySqlBulkCopy(conn)
                {
                    DestinationTableName = tableName
                };
                var dataReader = new MyDataReader<T>(records.ToList());

                try
                {
                    bc.WriteToServer(dataReader);
                }

                catch (Exception e)
                {
                    Console.WriteLine($"Bulk copy failer {e.Message}");
                }

                finally
                {
                    CloseConnetion();
                }

            }

        }

    }
}
