using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneablePoint
{
    class PointDescription
    {
        public string Petname { get; set; }
        public Guid ID { get; set; }

        public PointDescription ()
        {
            Petname = "No-name";
            ID = Guid.NewGuid();
        }
    }
}
