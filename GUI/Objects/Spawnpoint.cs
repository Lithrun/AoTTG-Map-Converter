using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Objects
{
    public class Spawnpoint : MapObject
    {


        // Constructor based on a string array
        public Spawnpoint(string[] input)
        {
            try
            {

                // given input has not the correct size, invalid!
                if (input.Length != 9)
                {
                    throw new Exception();
                }

                Name = input[0];
                Type = input[1];
                Coordinates = new double[3] { double.Parse(input[2]), double.Parse(input[4]), double.Parse(input[3]) }; // Note this gets formatted to X, Y, Z
                Quarternion = new double[4] { double.Parse(input[5]), double.Parse(input[6]), double.Parse(input[7]), double.Parse(input[8])  };


            } catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                // something went wrong!
            }
        }

        // Return a string in CSV format
        public override string ConvertObjectToString()
        {
            return String.Format("{0},{1},{2:},{3},{4},{5},{6},{7},{8};",Name, Type, Coordinates[0].ToString(), Coordinates[2], Coordinates[1], Quarternion[0], Quarternion[1], Quarternion[2], Quarternion[3]);
        }

        

    }
}
