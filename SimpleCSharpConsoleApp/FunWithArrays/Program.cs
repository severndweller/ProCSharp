using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with Arrays ****");
            //MultiDArrays();
            string outputResult;
            //ParmTesting();
            //StringRefArrayTests();
            ParamsModifier();
            //ParmTesting.OutDataTest("Testing", out outputResult);
            Console.ReadLine();
        }

        private static void SimpleArrays()
        {
            Console.WriteLine(" => Simple Array Creation");
            int[] myInts = new int[3];
            myInts[0] = 100;
            myInts[1] = 200;
            myInts[2] = 300;
            // Create a 100 item string array indexed 0 - 99
            string[] myStrings = new string[100];
            Console.WriteLine();

            foreach (int item in myInts)
            {
                Console.WriteLine(item);
            }

            string[] moreStrings = new string[] { "one", "two", "three" };
            for (int i = 0; i < moreStrings.Length; i++)
            {
                Console.WriteLine(moreStrings[i]);
            }

            var a = new[] { 0, 1, 2, 3, 4 };

            var b = new[] { "six", "seven" };

            bool[] c = new bool[] { false, false, true };

        }

        private static void ArrayOfObjects()
        {
            object[] myObjects = new object[4];
            myObjects[0] = false;
            myObjects[1] = "A STRING";
            myObjects[2] = 3.4;
            myObjects[3] = DateTime.Now;
            foreach (var item in myObjects)
            {
                Console.WriteLine("Object is of type {0} : {1}", item.GetType(), item);
            }
        }

        static void MultiDArrays()
        {
            int[,] myMattrix;
            myMattrix = new int[3, 4];

            int[,,] myMatrix;
            myMatrix = new int[1,2,4];
        }

        public static void ParmTesting()
        {

            Console.WriteLine("Got to ParmTesting");
            void OutDataTest(string inputString, out string result)
            {
                result = String.Format("{0} modified", inputString);
                result = String.Format("Modified this '{0}' to this '{1}'", inputString, result);
            }

            OutDataTest("TryMe", out string outResult);
            Console.WriteLine("Output Result is {0}", outResult);


            OutDataTest("TryMode", out _);
            Console.WriteLine("Output Result is {0}", outResult);

            void RefTesting (string myInputString, ref string myRefString, string myValueString)
            {
                myValueString = "changed";
                myRefString= "also changed";
            }

            string testRefOutput = "Init";
            string testValueOutput = "Init";
            RefTesting("Test Input", ref testRefOutput, testValueOutput);
            Console.WriteLine(testValueOutput);
            Console.WriteLine(testRefOutput);
        }

        public static string SimpleReturn(string[] strArray, int position)
        {
            return strArray[position];
        }

        public static ref string SimpleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }


        private static void StringRefArrayTests()
        {
            string[] stringArray = { "one", "two", "three" };
            int pos = 1;
            Console.WriteLine("Simple Return");
            Console.WriteLine("Before values {0}, {1}, {2}", stringArray[0], stringArray[1], stringArray[2]);
            string output = SimpleReturn(stringArray, 1);
            Console.WriteLine("Output is {0}", output);
            Console.WriteLine("Before values {0}, {1}, {2}", stringArray[0], stringArray[1], stringArray[2]);
            output = "new";
            Console.WriteLine("Assignment now to new");
            Console.WriteLine("Before values {0}, {1}, {2}", stringArray[0], stringArray[1], stringArray[2]);

            ref var output2 = ref SimpleRefReturn(stringArray, 1);
            output2 = "new";
            Console.WriteLine("Before values {0}, {1}, {2}", stringArray[0], stringArray[1], stringArray[2]);






        }

        private static void ParamsModifier()
        {

            void TakeLots (string myString, int[] theIntList)
            {
                foreach (var item in theIntList)
                {
                    Console.WriteLine("Item is {0}", item);
                }
                for (int i = 0; i < theIntList.Length; i++)
                    {
                    Console.WriteLine("Item {0} is {1}", i, theIntList[i]);
                }
            }

            void TakeLotsAsParams(string myString, string temp = "Wotcha", params int[] theIntList)
            {
                foreach (var item in theIntList)
                {
                    Console.WriteLine("Item is {0}", item);
                }
                for (int i = 0; i < theIntList.Length; i++)
                {
                    Console.WriteLine("Item {0} is {1}", i, theIntList[i]);
                }
            }


            int[] myInts = { 1, 2, 3 };

            //TakeLotsAsParams("Try", myInts);
            //TakeLotsAsParams("Try", , 30, 31, 32, 33, 34, 35, 60);

        }



    }

}
