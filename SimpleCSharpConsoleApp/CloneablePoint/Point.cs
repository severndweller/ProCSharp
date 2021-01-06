using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointDescription desc = new PointDescription();
        public Point(int xPos, int yPos, string petName)
        {
            X = xPos;
            Y = yPos;
            desc.Petname = petName;
        }
        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
        public Point() { }
        public override string ToString() => $"X = {X}; Y = {Y}; \nID = {desc.Petname}; GUID = {desc.ID.ToString()}\n";

        //public object Clone() => new Point(this.X, this.Y);

        // Because the Point Class does not ontain any internal reference types
        // we can use the object MemberwiseClone method to effect the cloning of this object
        //public object Clone() => this.MemberwiseClone();
        public object Clone()
        {
            // First get a shallow copy
            Point p = (Point)this.MemberwiseClone();
            PointDescription currentDesc = new PointDescription();
            currentDesc.Petname = this.desc.Petname;
            p.desc = currentDesc;
            return p;
        }
    }
}
