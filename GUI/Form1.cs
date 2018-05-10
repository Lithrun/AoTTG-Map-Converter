using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;
using Logic.Objects;

namespace GUI
{
    public partial class Form1 : Form
    {
        //misc,region,X,1,1,1,-24.19856,213.974,236.5408,0,0,0,1;

        MapObjectFactory Factory = new MapObjectFactory();
        public Form1()
        {
            InitializeComponent();
        }
        //One liners
        private void MapScriptClearBTN_Click(object sender, EventArgs e)
        {
            MapScriptTBX.Clear();
        }
        private void CopyClipboardBTN_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MapScriptOutputTBX.Text);
        }
        private void MapScriptOutpClearBTN_Click(object sender, EventArgs e)
        {
            MapScriptOutputTBX.Clear();
        }

        private void MoveObjectsBTN_Click(object sender, EventArgs e)
        {
            Factory.mapObjects.Clear();
            HashSet<string[]> items = new HashSet<string[]>();
            //now get the desiered rotation value
            double angle = 0;
            string[] lines = MapScriptTBX.Text.Split(';');


            double[] XLocation = new double[3];
            double[] size = new double[3];

            double[] YLocation = new double[3];
            //the last string in lines will always be an empty string "", so we just avoid it
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] ObjectInfo = lines[i].Split(',').ToArray();
                if(ObjectInfo[1] == "region" && ObjectInfo[2] == "X")
                {
                    try
                    {
                        //I'm not sure about the order of the script, might need some tinkering
                        size[0] = double.Parse(ObjectInfo[3]);
                        size[1] = double.Parse(ObjectInfo[4]);
                        size[2] = double.Parse(ObjectInfo[5]);

                        XLocation[0] = double.Parse(ObjectInfo[6]);
                        XLocation[1] = double.Parse(ObjectInfo[8]);
                        XLocation[2] = double.Parse(ObjectInfo[7]);
                        //if there isn't a region called Y then assume Y = X
                        //will be very handy in RotateObjectsInRegion method
                        YLocation = XLocation;
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }
                }
                else if(ObjectInfo[1] == "region" && ObjectInfo[2] == "Y")
                {
                    try
                    {
                        YLocation[0] = double.Parse(ObjectInfo[6]);
                        YLocation[1] = double.Parse(ObjectInfo[8]);
                        YLocation[2] = double.Parse(ObjectInfo[7]);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                items.Add(ObjectInfo);
            }
            Factory.AddMapObjects(items);
            try
            {
                angle = (double.Parse(RotationTBX.Text)) * Math.PI / 180;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

            //this rotates the objects inside the region
            Factory.RotateObjectsInRegion(size, XLocation, YLocation, angle);

            //print to output textbox
            MapScriptOutputTBX.Clear();
            HashSet<MapObject> MapScriptOutput = Factory.mapObjects;
            foreach(MapObject item in MapScriptOutput)
            {
                //ConvertObjectToString isn't implemented yet
                MapScriptOutputTBX.AppendText(item.ConvertObjectToString());
            }
        }
    }
}
