using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;


namespace DataProviderFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with Data Provider Factories\n");
            // Get COnnection String Provider from App.Config
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            // Get the factory provider
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            // Now get the connection object
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    ShowError("Connection");
                    return;
                } else
                {
                    Console.WriteLine($"Your connection object is a {connection.GetType().Name}");
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    // Make a command object
                    DbCommand command = factory.CreateCommand();
                    if (command == null)
                    {
                        ShowError("Command");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Your command object is a {command.GetType().Name}");
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM INVENTORY";

                        // Print out data with a data reader
                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine($"Your data reader object is a {reader.GetType().Name}");
                            while (reader.Read())
                                Console.WriteLine($"-> Car {reader["CarID"]} is a datareader {reader["Make"]}.----------------------->");
                        }
                    }
                    Console.ReadLine();
                }
            }
        }

        private static void ShowError (string objectName)
        {
            Console.WriteLine($"There was an issue creating the {objectName}");
            Console.ReadLine();
        }
    }
}
