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

namespace GUI
{
    public partial class Form1 : Form
    {
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
            //the last string in lines will always be an empty string "", so we just avoid it
            for (int i = 0; i < lines.Length - 1; i++)
            {
                items.Add(lines[i].Split(',').ToArray());
            }
            Factory.AddMapObjects(items);
            try
            {
                angle = (double.Parse(RotationTBX.Text)) * Math.PI / 180;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //here we need code to find the specified region X and all objects inside that region
            //and then we need to center the group of objects at the origin
            //then apply a linear transformation and a quarternion rotation
            //and then move it to the desiered coordinates specified by region Y
        }
    }
}
