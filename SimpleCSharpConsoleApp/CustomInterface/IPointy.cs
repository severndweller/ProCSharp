using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    interface IPointy
    {
        // Implicitly public and abstract
        // 
        byte GetNumberOfPoints();

        byte Points { get; }
    }

    interface IDraw3D
    {
        void Draw3D();
    }
}
