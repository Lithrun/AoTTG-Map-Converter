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

            CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("en-US");

            var lines = File.ReadAllLines(@"D:\Utgard.csv").Select(a => a.Split(';'));
            HashSet<string[]> items = new HashSet<string[]>();

            foreach (string[] line in lines)
            {
                items.Add(line[0].Split(',').ToArray());
            }


            foreach (string[] line in items)
            {
                Console.WriteLine(line[0]);
            }

            Console.ReadLine();

            // csv consists of multiple lines of string arrays (line)

            string[] csv = { "spawnpoint", "playerC", "-1625.263", "36.26612", "12391.56", "0", "0.01555714", "0", "0.999879" };
            MapObject mapObject;
            MapObjectFactory mapObjectFactory = MapObjectFactory.GetMapObjectFactory();

            double number = double.Parse(csv[2]);
            Console.WriteLine(number);

            mapObject = mapObjectFactory.GetMapObject(csv);

            Console.WriteLine(mapObject.Name);
            Console.WriteLine(mapObject.ConvertObjectToString());
            Console.ReadLine();

        }
    }
}
