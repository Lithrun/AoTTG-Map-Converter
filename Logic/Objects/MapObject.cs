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
        public double[] Quarternion { get; set; }

        // Return a string based on the object
        public abstract string ConvertObjectToString();

        public void RotateRoundZ(double angle)
        {
            double[] RotationQuarternion =
            {
                Math.Cos(angle/2),
                0,
                Math.Sin(angle/2),
                0
            };
            this.Quarternion = QuartarnionMultiply(RotationQuarternion, this.Quarternion);
        }
        private static double[] QuartarnionMultiply(double[] Q, double[] R)
        {
            double[] QProduct =
            {
                R[0] * Q[0] - R[1] * Q[1] - R[2] * Q[2] - R[3] * Q[3],
                R[0] * Q[1] + R[1] * Q[0] - R[2] * Q[3] + R[3] * Q[2],
                R[0] * Q[2] + R[1] * Q[3] + R[2] * Q[0] - R[3] * Q[1],
                R[0] * Q[3] - R[1] * Q[2] + R[2] * Q[1] + R[3] * Q[0]
            };
            return QProduct;
        }
    }
}
