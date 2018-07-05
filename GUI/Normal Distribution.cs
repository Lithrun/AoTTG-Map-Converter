using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Normal_Distribution
    {
        private Random gen;
        public double StandardDeviation { get; set; }
        public double Mean { get; set; }
        public Normal_Distribution()
        {
            gen = new Random();
            StandardDeviation = 1;
            Mean = 0;
        }
        public double Next()
        {
            double u1 = 1.0 - gen.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - gen.NextDouble();

            //a quick and dirty way to generate a Normal distributed data point
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                        Math.Sin(2.0 * Math.PI * u2); //random normal(0,1))
            return randStdNormal * StandardDeviation + Mean;
        }
        //three overloaded uniform distributions
        public double NextUniform()
        {
            return gen.NextDouble();
        }
        public double NextUniform(double Max)
        {
            return gen.NextDouble() * Max;
        }
        public double NextUniform(double Max, double Min)
        {
            return gen.NextDouble() * (Max - Min) + Min;
        }
    }
}
