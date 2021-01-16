using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with extention methods ************");

            // The int has awssumed a new identity
            int myInt = 1234567;

            myInt.DisplayDefiningAssembly();

            // So has the dataset
            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();

            // and the sound player
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.DisplayDefiningAssembly();

            Console.WriteLine(myInt.ReverseDigits().ToString());
            Console.ReadLine();
        }
    }
}
