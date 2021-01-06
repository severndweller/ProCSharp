using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Triangle : Shape, IPointy
    {
        public Triangle() { }

        public Triangle(string name) : base(name)
        {
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing Triangle");
        }

        public byte GetNumberOfPoints()
        {
            return 3;
        }

        public byte Points
        {
            get { return 3; }
        }
    }
}

