using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Objects
{
    public class Custom : MapObject
    {

        public string Texture { get; set; }
        public double[] Scale { get; set; }
        public double[] Color { get; set; }
        public double[] Tiling { get; set; }

        // custom,sphere,stone3,    (5,1,5),    (0,1,1,1),  (1.0,1.0),  (15143.89,151.928,39963.08) ,0,0.1469965,0,0.9891371;
        // Name, type, texture, scale (width, height, length), color (enabled 1/0, R, G, B), Tiling (x, y), Cords (x, z, y), Rotation
        // Constructor based on a string array
        public Custom(string[] input)
        {
            
            try
            {

                // given input has not the correct size, invalid!
                if (input.Length != 19)
                {
                    throw new Exception();
                }

                Name = input[0];
                Type = input[1];

                Texture = input[2];

                // length, width, height
                Scale = new double[3] { double.Parse(input[3]), double.Parse(input[4]), double.Parse(input[5]) };
                Color = new double[4] { double.Parse(input[6]), double.Parse(input[7]), double.Parse(input[8]), double.Parse(input[9]) };
                Tiling = new double[2] { double.Parse(input[10]), double.Parse(input[11]) };

                Coordinates = new double[3] { double.Parse(input[12]), double.Parse(input[14]), double.Parse(input[13]) };
                Quarternion = new double[4] { double.Parse(input[15]), double.Parse(input[16]), double.Parse(input[17]), double.Parse(input[18]) };
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                // something went wrong!
            }
        }

        // Return a string in CSV format
        public override string ConvertObjectToString()
        {
            return String.Format(
                "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18};", 
                Name, Type, Texture, Scale[0], Scale[1], Scale[2], Color[0], Color[1], Color[2], Color[3], Tiling[0], Tiling[1], Coordinates[0], Coordinates[2], Coordinates[1], Quarternion[0], Quarternion[1], Quarternion[2], Quarternion[3]);
        }
    }
}
