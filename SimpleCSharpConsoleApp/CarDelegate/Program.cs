using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    public class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        private bool carIsDead;

        // Constructors
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            PetName = name;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }

        public delegate void CarEngineHandler(string msgForCaller);
        private CarEngineHandler listofHandlers;
        // Regn function
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            Console.WriteLine("Registering {0}", methodToCall.Method + " : " + methodToCall.Target);
            listofHandlers += methodToCall;
        }

        public void UnRegisterWithCarEngine (CarEngineHandler methodToCall)
        {
            Console.WriteLine("UnRegistering {0}", methodToCall.Method + " : " + methodToCall.Target);
            listofHandlers -= methodToCall;
        }

        public void Accelerate(int delta)
        {
            // If car is dead, send dead message
            if (carIsDead)
            {
                if (listofHandlers != null)
                {
                    listofHandlers("Sorry this car is dead...");
                } 
            } 
            else
            {
                CurrentSpeed += delta;
                // Is the car almost dead
                if (10 == (MaxSpeed - CurrentSpeed) && listofHandlers != null)
                {
                    listofHandlers("Careful buddy, gonna blow");
                }
                if (CurrentSpeed > MaxSpeed)
                {
                    carIsDead = true;
                } 
                else
                {
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegates as event enablers");
            Car c1 = new Car("Slugbug", 100, 10);
            // Now tell the car which method to call
            Car.CarEngineHandler handler1 = new Car.CarEngineHandler(OnCarEngineEvent);
            c1.RegisterWithCarEngine(handler1);
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));
//            c1.UnRegisterWithCarEngine(handler1);

            // Speed up - this will trigger the events
            Console.WriteLine("******* Speeding Up *********");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            Console.ReadLine();
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n Message from the Car Object");
            Console.WriteLine("= > {0}", msg);
            Console.WriteLine("*********************************");
        }

        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("= > {0}", msg.ToUpper());
        }
    }
}
