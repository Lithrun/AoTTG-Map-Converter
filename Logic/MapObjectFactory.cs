using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Objects;

namespace Logic
{
    public sealed class MapObjectFactory
    {
        public HashSet<MapObject> mapObjects { get; set; }

        private static MapObjectFactory _instance;
        private static object _lockThis = new object();
        
        //Singleton Pattern (Make sure that only one MapObjectFactory exists)
        public static MapObjectFactory GetMapObjectFactory()
        {
            lock (_lockThis)
            {
                if (_instance == null) _instance = new MapObjectFactory();
            }
            return _instance;
        }

        public void AddMapObjects(HashSet<string[]> objects)
        {
            foreach (string[] line in objects)
            {
                MapObject item = GetMapObject(line);
                if(item != null)
                    mapObjects.Add(item);
            }
        }

        public MapObject GetMapObject(string[] input)
        {
            MapObject mapObject;
            if (input[0][0] == '\n')
            {
                input[0] = input[0].Remove(0, 1);
            }
            switch (input[0])
            {
                case "spawnpoint":
                    mapObject = new Spawnpoint(input);
                    break;
                case "custom":
                    mapObject = new Custom(input);
                    break;
                //Same as custom???
                //I think so...
                case "customb":
                    mapObject = new Custom(input);
                    break;
                //Undefined
                default:
                    mapObject = null;
                    break;
            }
            return mapObject;
        }

        public void RotateObjectsInRegion(double[] size, double[] XLocation, double[] YLocation, double angle)
        {
            //first we need to find all the mapObjects that are in the region and sort them out
            HashSet<MapObject> Group = GetObjectsInRegion(size, XLocation);


            foreach (MapObject item in Group)
            {
                //centralise the objects to the origin
                for (int i = 0; i < 3; i++)
                {
                    item.Coordinates[i] -= XLocation[i];
                }

                //apply linear transformation and quarternion multiplication
                item.Coordinates = LinearTransformation(RotateZMatrix(angle), item.Coordinates);
                item.Quarternion = QuartarnionMultiply(item.Quarternion, QRotateY(-angle));
                //move the objects back
                for (int i = 0; i < 3; i++)
                {
                    //note that is there wasn't a Y region the we set it up so that Y = X
                    //works wonders
                    item.Coordinates[i] += YLocation[i];
                }
            }
        }

        public HashSet<MapObject> GetObjectsInRegion(double[] size, double[] Location)
        {
            HashSet<MapObject> Group = new HashSet<MapObject>();
            foreach (MapObject item in mapObjects)
            {
                //I assume that the origin of a region is the center
                //this could use some optimization
                if (Math.Abs(item.Coordinates[0] - Location[0]) < size[0] / 2 &&
                    Math.Abs(item.Coordinates[1] - Location[1]) < size[1] / 2 &&
                    Math.Abs(item.Coordinates[2] - Location[2]) < size[2] / 2)
                {
                    Group.Add(item);
                }
            }
            return Group;
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
        //usually you want the order to be "desired rotational quarternion" * "current quarternion"
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