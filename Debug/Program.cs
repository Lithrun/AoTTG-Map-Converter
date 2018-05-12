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


        /// <summary>
        /// these three objects is a coordinate system with colored axes
        /// custom,cuboid,default,1,1,100,1,1,0,0,1.0,1.0,500,0,0,0,0.707,0,-0.707;
        ///custom,cuboid,default,1,1,100,1,0,1,0,1.0,1.0,0,0,500,0,0,0,-1;
        ///custom,cuboid,default,1,1,100,1,0,0,1,1.0,1.0,0,500,0,-0.707,0,0,-0.707;
        ///misc,region,X,2000,2000,2000,476.8452,282.2386,531.3534,0,0,0,1;
        /// </summary>
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
        //these are computational functions that are necessary
        private static double[] LinearTransformation(double[,] matrix, double[] vektor)
        {
            double[] temp = new double[vektor.Length];
            for (int i = 0; i < vektor.Length; i++)
            {
                for (int j = 0; j < vektor.Length; j++)
                {
                    temp[i] += matrix[i, j] * vektor[j];
                }
            }
            return temp;
        }
        private static double[,] RotateXMatrix(double angle)
        {
            double[,] temp = {
                { 1 ,          0           ,       0         },
                { 0 ,   Math.Cos(angle)    , Math.Sin(angle) },
                { 0 , -1 * Math.Sin(angle) , Math.Cos(angle) }
            };
            return temp;
        }
        private static double[,] RotateYMatrix(double angle)
        {
            double[,] temp = {
                { Math.Cos(angle) , 0  , -1 * Math.Sin(angle) },
                {        0        , 1  ,           0          },
                { Math.Sin(angle) , 0  ,   Math.Cos(angle)    }
            };
            return temp;
        }
        private static double[,] RotateZMatrix(double angle)
        {
            double[,] temp = {
                {   Math.Cos(angle)    , Math.Sin(angle) , 0 },
                { -1 * Math.Sin(angle) , Math.Cos(angle) , 0 },
                {          0           ,        0        , 1 }
            };
            return temp;
        }
        private double dotProduct(double[] v1, double[] v2)
        {
            double dot = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                dot += v1[i] * v2[i];
            }
            return dot;
        }

        //use this to multiply two quarternions, note that order matters
        //usually you want the order to be "current quarternion" * "desired rotational quarternion"
        static double[] QuartarnionMultiply(double[] Q, double[] R)
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

        //returns a Quarternion that with the desiered rotation angle around either the x,y or z axis
        static double[] QRotateZ(double angle)
        {
            double[] unitvector = { 0, 0, 1 };
            double[] Quartarnion =
            {
                Math.Cos(angle/2),
                unitvector[0]*Math.Sin(angle/2),
                unitvector[1]*Math.Sin(angle/2),
                unitvector[2]*Math.Sin(angle/2),
            };
            return Quartarnion;
        }
        static double[] QRotateX(double angle)
        {
            double[] unitvector = { 1, 0, 0 };
            double[] Quartarnion =
            {
                Math.Cos(angle/2),
                unitvector[0]*Math.Sin(angle/2),
                unitvector[1]*Math.Sin(angle/2),
                unitvector[2]*Math.Sin(angle/2),
            };
            return Quartarnion;
        }
        static double[] QRotateY(double angle)
        {
            double[] unitvector = { 0, 1, 0 };
            double[] Quartarnion =
            {
                Math.Cos(angle/2),
                unitvector[0]*Math.Sin(angle/2),
                unitvector[1]*Math.Sin(angle/2),
                unitvector[2]*Math.Sin(angle/2),
            };
            return Quartarnion;
        }
    }
}
