using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Logic.Objects;

namespace Debug
{

    // custom,sphere,stone3,5,1,5,0,1,1,1,1.0,1.0,15143.89,151.928,39963.08,0,0.1469965,0,0.9891371;
    // custom,sphere,stone3,    (5,1,5),    (0,1,1,1),  (1.0,1.0),  (15143.89,151.928,39963.08) ,0,0.1469965,0,0.9891371;
    // Name, type, texture, scale (width, height, length), color (enabled 1/0, R, G, B), Tiling (x, y), Cords (x, z, y), Rotation


    // Idk how to add this console within the same project so oef
    class Program
    {
        static void Main(string[] args)
        {

            // csv consists of multiple lines of string arrays (line)

            string[] line = { "spawnpoint", "playerC","-1625.263","36.26612","12391.56","0","0.01555714","0","0.999879" };
            MapObject mapObject;


            switch (line[0])
            {
                case "spawnpoint":
                    mapObject = new Spawnpoint(line);
                    break;
                case "custom":
                    mapObject = new Custom(line);
                    break;
                //Same as custom???
                case "customb":
                    mapObject = new Custom(line);
                    break;
                //Undefined
                default:
                    mapObject = null;
                    break;


            }

            Console.WriteLine(mapObject.Name);
            Console.WriteLine(mapObject.ConvertObjectToString());
            Console.ReadLine();

        }
    }
}
