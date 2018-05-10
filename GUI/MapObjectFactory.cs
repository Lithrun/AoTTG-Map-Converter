using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Objects;

namespace GUI
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
                mapObjects.Add(GetMapObject(line));
            }
        }

        public MapObject GetMapObject(string[] input)
        {
            MapObject mapObject;


            switch (input[0])
            {
                case "spawnpoint":
                    mapObject = new Spawnpoint(input);
                    break;
                case "custom":
                    mapObject = new Custom(input);
                    break;
                //Same as custom???
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

    }
}