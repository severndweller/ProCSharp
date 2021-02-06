using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.DataOperations;
using AutoLotDAL.Models;
using AutoLotDAL.BulkImport;

namespace AutoLotClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            DoBulkCopy();
            return;

            InventoryDAL dal = new InventoryDAL();
            var list = dal.GetAllInventory();
            Console.WriteLine("******************** ALL CARS ********************");

            Console.WriteLine("CarId\tMake\tColor\tPetName");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.CarId}\t{item.Make}\t{item.Color}\t{item.PetName}");
            }
            Console.WriteLine();
            var car = dal.GetCar(list.OrderBy(x => x.Color).Select(x => x.CarId).First());
            Console.WriteLine("First Car By Color");
            Console.WriteLine($"{car.CarId}\t{car.Make}\t{car.Color}\t{car.PetName}");
            Console.WriteLine();
            try
            {
                Console.WriteLine("Deleting Car with ID 2");
                dal.DeleteCar(2);
                Console.WriteLine("Car deleted, hit return");
                Console.ReadLine();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Exceptiopn occurred {ex.Message}");
            }


            Console.WriteLine();

            Console.WriteLine("TESTING transactions ***********************" +
                "");

            MoveCustomer();
            Console.ReadLine();

        }

        public static void MoveCustomer ()
        {
            Console.WriteLine("Simple Transaction Example\n");

            bool throwEx = true;

            Console.WriteLine("Do you want to throw an exception Y/N");
            var answer = Console.ReadLine();
           if (!answer.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                throwEx = false;
            }

            var dal = new InventoryDAL();
            dal.ProcessCreditRisk(throwEx, 5);
            Console.WriteLine("Check your table for results");
        }

        public static void DoBulkCopy()
        {
            Console.WriteLine("************* BULK COPY ***************");

            var cars = new List<Car>
            {
                new Car { Make = "Nissan", Color = "Pink", PetName = "Steph" },
                new Car { Make = "Peugeot", Color = "Black", PetName = "Nessa" },
                new Car { Make = "Citroen", Color = "Green", PetName = "Nell" },
                new Car { Make = "Fiat", Color = "BR Green", PetName = "Philip" },
                new Car { Make = "Massarati", Color = "Green", PetName = "Roger" },
                new Car { Make = "Suzuki", Color = "Red", PetName = "Ben" }
            };
            ProcessBulkImport.ExecuteBulkImport<Car>(cars, "INVENTORY");
            InventoryDAL dal1 = new InventoryDAL();
            List<Car> list = dal1.GetAllInventory();
            Console.WriteLine("All Cars --------------------");

            Console.WriteLine("CarId\tMake\tColor\tPetName");
            foreach (var item in list)
            {
                Console.WriteLine($"{item.CarId}\t{item.Make}\t{item.Color}\t{item.PetName}");
            }

            Console.ReadLine();

        }
    }
}
