using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCSharpConsoleAppSep
{
    class Car
    {
        private Radio myRadio = new Radio();
        public string PetName;

        public void TurnOnRadio (bool onOff)
        {
            myRadio.Power(onOff);
        }
    }

    public class Radio
    {
        public void Power (bool turnOn)
        {
            Console.WriteLine("Radio On: {0}", turnOn);
        }
    }
}