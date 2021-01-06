using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHeirarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            BitmapImage bmi = new BitmapImage();
            bmi.Draw();
            bmi.DrawInBoundingBox(10, 10, 60, 60);
            bmi.DrawUpsideDown();

            IAdvancedDraw iad = bmi as IAdvancedDraw;
            if (iad != null)
            {
                iad.DrawInBoundingBox(10, 10, 20, 20);
                iad.DrawUpsideDown();
            }

            Console.ReadLine();
        }
    }
}
