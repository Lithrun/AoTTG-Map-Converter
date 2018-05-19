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
using System.Globalization;

namespace GUI
{
    public partial class Form1 : Form
    {
        //misc,region,X,1,1,1,-24.19856,213.974,236.5408,0,0,0,1;

        MapObjectFactory Factory = new MapObjectFactory();
        public Form1()
        {
            CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            Factory.mapObjects = new HashSet<MapObject>();
            #region Add Mapobjects to the combobox

            //add Size 1,1,1 trees in our combobox
            comboBox1.Items.Add(
                new Custom(
                    new string[19] {
                        "customb","tree0","default","1","1","1","0","1","1","1","1.0","1.0","0","0","0","0","1","0","0"}));
            comboBox1.Items.Add(
                new Custom(
                    new string[19] {
                        "custom","tree1","default","1","1","1","0","1","1","1","1.0","1.0","0","0","0","0","1","0","0" }));
            comboBox1.Items.Add(
                new Custom(
                    new string[19] {
                        "custom","tree2","default","1","1","1","0","1","1","1","1.0","1.0","0","0","0","0","1","0","0" }));
            comboBox1.Items.Add(
                new Custom(
                    new string[19] {
                        "custom","tree3","default","1","1","1","0","1","1","1","1.0","1.0","0","0","0","0","1","0","0" }));
            comboBox1.Items.Add(
                new Custom(
                    new string[19] {
                        "custom","tree4","default","1","1","1","0","1","1","1","1.0","1.0","0","0","0","0","1","0","0" }));
            comboBox1.Items.Add(
                new Custom(
                    new string[19] {
                        "custom","tree5","default","1","1","1","0","1","1","1","1.0","1.0","0","0","0","0","1","0","0" }));
            comboBox1.Items.Add(
                new Custom(
                    new string[19] {
                        "custom","tree6","default","1","1","1","0","1","1","1","1.0","1.0","0","0","0","0","1","0","0" }));
            comboBox1.Items.Add(
                new Custom(
                    new string[19] {
                        "custom","tree7","default","1","1","1","0","1","1","1","1.0","1.0","0","0","0","0","1","0","0" }));


            #endregion
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
            double[] XLocation = new double[3];
            double[] RegionSize = new double[3];
            double[] YLocation = new double[3];

            //Parse the input text from the textbox, split the text before passing it through the function
            //return a hashset if inputstrings along with some very important vectors
            HashSet<string[]> items = Parse_outRegions(MapScriptTBX.Text.Split(';'), out RegionSize, out XLocation, out YLocation);

            Factory.AddMapObjects(items);

            //now get the desiered rotation value
            double angle = 0;
            try
            {
                angle = (double.Parse(RotationTBX.Text)) * Math.PI / 180;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

            //this rotates the objects inside the region
            Factory.RotateObjectsInRegion(RegionSize, XLocation, YLocation, angle);

            //print to output textbox
            MapScriptOutputTBX.Clear();
            HashSet<MapObject> MapScriptOutput = Factory.mapObjects;
            foreach(MapObject item in MapScriptOutput)
            {
                MapScriptOutputTBX.AppendText(item.ConvertObjectToString());
            }
        }
        HashSet<string[]> Parse_outRegions(string[] Lines, out double[] RegionSize, out double[] XLocation, out double[] YLocation)
        {
            HashSet<string[]> items = new HashSet<string[]>();

            XLocation = new double[3];
            RegionSize = new double[3];

            YLocation = new double[3];
            //the last string in lines will always be an empty string "", so we just avoid it
            for (int i = 0; i < Lines.Length - 1; i++)
            {
                string[] ObjectInfo = Lines[i].Split(',').ToArray();
                if(ObjectInfo[1] == "region" && ObjectInfo[2] == "X")
                {
                    try
                    {
                        //I'm not sure about the order of the script, might need some tinkering
                        RegionSize[0] = double.Parse(ObjectInfo[3]);
                        RegionSize[1] = double.Parse(ObjectInfo[4]);
                        RegionSize[2] = double.Parse(ObjectInfo[5]);

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
                    YLocation = new double[3];
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
            return items;

        }

        private void ClearTBXMP2_Click(object sender, EventArgs e)
        {
            double[] RegionSize;
            double[] XLocation;
            double[] YLocation;
            HashSet<string[]> Objects = Parse_outRegions(MPScriptTBX.Text.Split(';'), out RegionSize, out XLocation, out YLocation);
            Factory.mapObjects.Clear();
            Factory.AddMapObjects(Objects);

        }
        private void MassPlaceBTN_Click(object sender, EventArgs e)
        {
            int Count = int.Parse(MPCountTBX.Text);
        }
    }
}
