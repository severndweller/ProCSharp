using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIInterfaceHeirarchy
{
    interface IDrawable
    {
        void Draw();
    }

    interface IPrintable
    {
        void Print();
        void Draw();
    }

    interface IShape : IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }
}
