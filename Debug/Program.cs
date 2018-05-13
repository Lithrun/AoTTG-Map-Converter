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


        // <summary>
        // these three objects is a coordinate system with colored axes
        // custom,cuboid,default,1,1,100,1,1,0,0,1.0,1.0,500,0,0,0,0.707,0,-0.707;
        //custom,cuboid,default,1,1,100,1,0,1,0,1.0,1.0,0,0,500,0,0,0,-1;
        //custom,cuboid,default,1,1,100,1,0,0,1,1.0,1.0,0,500,0,-0.707,0,0,-0.707;
        //misc,region,X,2000,2000,2000,476.8452,282.2386,531.3534,0,0,0,1;
        // </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("en-US");

            MapObjectFactory Factory = new MapObjectFactory();

            string[] lines = new string[3] 
            {
                "custom,cuboid,default,1,100,1,1,1,0,0,1,1,500,0,0,-0.5,0.5,-0.5,-0.5",
                "custom,cuboid,default,1,100,1,1,0,1,0,1,1,0,500,0,0,0,0,-1",
                "custom,cuboid,default,1,100,1,1,0,0,1,1,1,0,0,500,-0.707,0,0,-0.707"
            };

            double[] RegionSize = new double[3] { 2000, 2000, 2000 };
            double[] XRegion = new double[3] { 0, 0, 0 };

            HashSet<string[]> items = new HashSet<string[]>();
            foreach(string item in lines)
            {
                items.Add(item.Split(','));
            }

            Factory.mapObjects = new HashSet<MapObject>();
            Factory.AddMapObjects(items);

            Factory.RotateObjectsInRegion(RegionSize, XRegion, XRegion, Math.PI/4);
            
            foreach(MapObject a in Factory.mapObjects)
            {
                Console.WriteLine(a.ConvertObjectToString());
            }
            Console.ReadLine();

        }
    }
}
