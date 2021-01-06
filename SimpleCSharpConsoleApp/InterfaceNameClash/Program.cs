using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with interface name clashes");
            Octagon oct = new Octagon();

            IDrawToForm idtf = (IDrawToForm) oct;
            idtf.Draw();

            IDrawToMemory idtm = (IDrawToMemory) oct;
            idtm.Draw();

            IDrawToPrinter idtp = (IDrawToPrinter) oct;
            idtp.Draw();

            Console.ReadLine();
        }
    }
}
