using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIInterfaceHeirarchy
{
    class Square : IShape
    {
        void IDrawable.Draw()
        {
            throw new NotImplementedException();
        }

        void IPrintable.Draw()
        {
            throw new NotImplementedException();
        }

        int IShape.GetNumberOfSides()
        {
            throw new NotImplementedException();
        }

        void IPrintable.Print()
        {
            throw new NotImplementedException();
        }
    }
}
