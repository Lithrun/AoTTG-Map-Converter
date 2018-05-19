using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Logic;
using Logic.Objects;

namespace Debug
{
    // custom,sphere,stone3,5,1,5,0,1,1,1,1.0,1.0,15143.89,151.928,39963.08,0,0.1469965,0,0.9891371;
    // custom,sphere,stone3,    (5,1,5),    (0,1,1,1),  (1.0,1.0),  (15143.89,151.928,39963.08) ,0,0.1469965,0,0.9891371;
    // Name, type, texture, scale (width, height, length), color (enabled 1/0, R, G, B), Tiling (x, y), Cords (x, z, y), Rotation
    
    // Idk how to add this console within the same project so oef
    // Issue: double.Parse uses Culture (so it only checks for comma instead of a dot for doubles while the text file uses dots...)
    
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(); //reuse this if you are generating many
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();

            //a quick and dirty way to generate a Normal distributed data point
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                        Math.Sin(2.0 * Math.PI * u2); //random normal(0,1))



            Console.ReadLine();
        }
    }
}
