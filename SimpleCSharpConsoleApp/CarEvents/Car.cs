﻿using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Car
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

        // Define the delegate type
        public delegate void CarEngineHandler(string msg);
        // Define a member variable of this delegate

        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;
        private CarEngineHandler listofHandlers;
        // Regn function

        private void ListTheHandlers()
        {
            if (listofHandlers == null)
            {
                Console.WriteLine("Handler list is EMPTY !!!!");
            }
            else
            {
                Console.WriteLine("Handler List is now --->");

                foreach (Delegate item in listofHandlers.GetInvocationList())
                {
                    Console.WriteLine("-->", item.Method.ToString() + " : " + item.Target == null ? "" : "Hey");
                    Console.WriteLine("-->", item.Method.ToString() + " : " + item.Target == null ? "" : item.Target.ToString());
                }
                Console.WriteLine("--------------------------");
            }
        }
        // Add a registration function to the caller
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            Console.WriteLine("Registering {0}", methodToCall.Method + " : " + methodToCall.Target);
            listofHandlers += methodToCall;
            ListTheHandlers();
        }

        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            Console.WriteLine("UnRegistering {0}", methodToCall.Method + " : " + methodToCall.Target);
            listofHandlers -= methodToCall;
            ListTheHandlers();
        }

        public void Accelerate(int delta)
        {
            Console.WriteLine("Speeding up from {0} by {1}", CurrentSpeed, delta);
            // If car is dead, send dead message
            if (carIsDead)
            {
                if (Exploded != null)
                {
                    Exploded("Sorry this car is dead...");
                }
            }
            else
            {
                CurrentSpeed += delta;
                // Is the car almost dead
                if (10 == (MaxSpeed - CurrentSpeed) && AboutToBlow!= null)
                {
                    AboutToBlow("Careful buddy, gonna blow");
                }
                if (CurrentSpeed > MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine("Current speed = {0}", CurrentSpeed);
                }
            }
        }
    }
}
