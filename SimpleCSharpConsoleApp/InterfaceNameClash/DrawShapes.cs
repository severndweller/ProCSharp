using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Drawing to Form");
        }

        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Drawing to Memory");
        }

        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing to Printer");
        }
    }
}