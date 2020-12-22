using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Car
    {
        // The state of the car
        public string petName;
        public int currSpeed;

        public Car()
        {
            petName = "Chuck";
            currSpeed = 10;
        }

        // Here, currSpeed will receieve the default vaule of an int (zero)
        public Car(string pn) => petName = pn;

        public Car(string pn, int cs)
        {
            petName = pn;
            currSpeed = cs;
        }

        public void SpeedUp(int delta)
        {
            currSpeed += delta;
        }

        public void AlternateSpeedUp(int delta) => currSpeed += delta;

        public void PrintState()
        {
            Console.WriteLine($"{petName} is currently going at {currSpeed} MPH");
        }
    }


    class MotoCycle
    {
        public int driverIntensity;
        public string driverName;

        public MotoCycle()
        {
            Console.WriteLine("In default ctor");
        }

        //public MotoCycle(int intensity) 
        //    : this(intensity, "") {
        //    Console.WriteLine("In constructor taking an int");
        //}

        //public MotoCycle(string name)
        //    : this(0, name)
        //{
        //    Console.WriteLine("In constructor taking a string");
        //}

        public MotoCycle(int intensity = 0, string name = "")
        {
            Console.WriteLine("In constructor taking an int and a string");
            SetDriverIntensity(intensity);
            this.driverName = name;
        }

        private void SetDriverIntensity(int intensity)
        {
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
        }
        public void PopAWheely()
        {
            for (int i = 0; i < driverIntensity; i++)
            {
                Console.WriteLine("Yeeeeeeeeeeeee Haaaaaaaaaaaaaaaaaa");
            }
        }

        public void SetDriverName(string name)
        {
            this.driverName = name;
        }
    }
}
