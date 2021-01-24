using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelMethodTest
{
    class Program
    {

        static string GetNLivenDeliveryMethod (string thebsDeliveryMethod)
        {
            string nLivenDeliveryMethod = String.Empty;
            try
            {
//                string basketNotes = "THEBS$N$NLIVEN#1345~THEBS$C$NLIVEN#132~THEBS$E$NLIVEN#68~";
                string basketNotes = "DelMethods: THEBS$N$NLIVEN#849~THEBS$C$NLIVEN#850~";

                string[] availableDeliveryMethods = basketNotes.Split('~');
                foreach (var item in availableDeliveryMethods)
                {
                    Console.WriteLine("-> : {0}", item);
                }

                string theKey = string.Concat("THEBS$", thebsDeliveryMethod, "$");
                Console.WriteLine("Looking for {0}", theKey);

                string matchedMethod = availableDeliveryMethods.FirstOrDefault(d => d.Contains(theKey));
                nLivenDeliveryMethod = matchedMethod?.Split('#', '~')[1];
                //Console.WriteLine("Matched with {0}", matchedMethod);
            }
            catch (Exception e)
            {

            }
            return nLivenDeliveryMethod;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("For N [{0}]", GetNLivenDeliveryMethod("N"));
            Console.WriteLine("For C [{0}]", GetNLivenDeliveryMethod("C"));
            Console.WriteLine("For E [{0}]", GetNLivenDeliveryMethod("E"));
            Console.WriteLine("For F [{0}]", GetNLivenDeliveryMethod("F"));
            Console.ReadLine();

            string basketNotes = "THEBS$N$NLIVEN#1345~THEBS$C$NLIVEN#132~THEBS$E$NLIVEN#68~";

            Console.WriteLine(basketNotes);
            basketNotes = "APPLIED:" + "3145-" + basketNotes.Substring(basketNotes.IndexOf("THEBS$"));

            Console.WriteLine(basketNotes);
            basketNotes = "APPLIED:" + "3145-" + basketNotes.Substring(basketNotes.IndexOf("THEBS$"));

            Console.WriteLine(basketNotes);
            basketNotes = "APPLIED:" + "3145-" + basketNotes.Substring(basketNotes.IndexOf("THEBS$"));

            Console.WriteLine(basketNotes);

            Console.ReadLine();

            //            availableDeliveryMethods.Append("THEBS$" + deliveryMethod.ThebsId + "$NLIVEN#" + deliveryMethod.ExternalId + "~");


        }
    }
}
