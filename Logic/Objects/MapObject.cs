using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Objects
{

    public abstract class MapObject
    {

        public string Type { get; set; }
        public string Name { get; set; }
        public double[] Coordinates { get; set; }
        public double[] Vector4D { get; set; }

        // Return a string based on the object
        public abstract string ConvertObjectToString();

    }
}
