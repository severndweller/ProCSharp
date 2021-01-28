using System;

namespace PassRefsByValue
{
    class northerner
    {
        public string personName;
        public int personAge;

        public northerner(string personName, int personAge)
        {
            this.personName = personName;
            this.personAge = personAge;
        }

        public northerner()
        {
        }

        public void Display()
        {
            Console.WriteLine("Name {0}, Age {1}", personName, personAge);
        }
    }
}