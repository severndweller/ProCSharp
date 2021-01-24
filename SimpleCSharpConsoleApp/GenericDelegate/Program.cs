using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate
{
    public delegate void MyGenericDelegate<T>(T myParam);
    class Program
    {
        // Declare the delegate type

        private bool myBool;

        string myName { get; set; }
        static void getMine(string temper)
        {
            Console.WriteLine("getMine was called");
        }
        static void Main(string[] args)
        {
            //            Console.WriteLine("Generic Delegates");
            // Register Targets
            List<string> thisList = new List<string>();

            // Declare a member variable of the delegate 
            //            private MyGenericDelegate<string> thisDel;
            // Register targets
            //        MyGenericDelegate<string> thisDel = new MyGenericDelegate<string>(getMine);

            MyGenericDelegate<string> thisDel = new MyGenericDelegate<string>(MyStringDel);
            thisDel("Hey");

            MyGenericDelegate<int> thisInt = new MyGenericDelegate<int>(MyIntDel);
            thisInt(30);
            Console.ReadLine();
            //            thisDel+= getMine;
        }
        static void MyStringDel(string Msg)
        {
            Console.WriteLine("MyString Del Reporting {0}", Msg);
        }

        static void MyIntDel(int myNum)
        {
            Console.WriteLine("MyIntDel reporting {0}", myNum.ToString());
        }
    }
}

