﻿namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.RegionMove = new System.Windows.Forms.TabPage();
            this.MapScriptClearBTN = new System.Windows.Forms.Button();
            this.MapScriptTBX = new System.Windows.Forms.TextBox();
            this.InstructionsTBX = new System.Windows.Forms.TextBox();
            this.MassPlace = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.MoveObjectsBTN = new System.Windows.Forms.Button();
            this.RotationTBX = new System.Windows.Forms.TextBox();
            this.MapScriptOutputTBX = new System.Windows.Forms.TextBox();
            this.CopyClipboardBTN = new System.Windows.Forms.Button();
            this.MapScriptOutpClearBTN = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MassPlaceScriptTBX = new System.Windows.Forms.TextBox();
            this.MassPlaceClearBTN = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.RegionMove.SuspendLayout();
            this.MassPlace.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.RegionMove);
            this.tabControl1.Controls.Add(this.MassPlace);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(377, 330);
            this.tabControl1.TabIndex = 0;
            // 
            // RegionMove
            // 
            this.RegionMove.Controls.Add(this.MapScriptOutpClearBTN);
            this.RegionMove.Controls.Add(this.CopyClipboardBTN);
            this.RegionMove.Controls.Add(this.MapScriptOutputTBX);
            this.RegionMove.Controls.Add(this.RotationTBX);
            this.RegionMove.Controls.Add(this.MoveObjectsBTN);
            this.RegionMove.Controls.Add(this.MapScriptClearBTN);
            this.RegionMove.Controls.Add(this.MapScriptTBX);
            this.RegionMove.Controls.Add(this.InstructionsTBX);
            this.RegionMove.Location = new System.Drawing.Point(4, 22);
            this.RegionMove.Name = "RegionMove";
            this.RegionMove.Padding = new System.Windows.Forms.Padding(3);
            this.RegionMove.Size = new System.Drawing.Size(369, 304);
            this.RegionMove.TabIndex = 0;
            this.RegionMove.Text = "Edit Region";
            this.RegionMove.UseVisualStyleBackColor = true;
            // 
            // MapScriptClearBTN
            // 
            this.MapScriptClearBTN.Location = new System.Drawing.Point(297, 160);
            this.MapScriptClearBTN.Name = "MapScriptClearBTN";
            this.MapScriptClearBTN.Size = new System.Drawing.Size(66, 23);
            this.MapScriptClearBTN.TabIndex = 2;
            this.MapScriptClearBTN.Text = "Clear";
            this.MapScriptClearBTN.UseVisualStyleBackColor = true;
            this.MapScriptClearBTN.Click += new System.EventHandler(this.MapScriptClearBTN_Click);
            // 
            // MapScriptTBX
            // 
            this.MapScriptTBX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapScriptTBX.Location = new System.Drawing.Point(6, 77);
            this.MapScriptTBX.Multiline = true;
            this.MapScriptTBX.Name = "MapScriptTBX";
            this.MapScriptTBX.Size = new System.Drawing.Size(357, 77);
            this.MapScriptTBX.TabIndex = 1;
            // 
            // InstructionsTBX
            // 
            this.InstructionsTBX.Location = new System.Drawing.Point(6, 6);
            this.InstructionsTBX.Multiline = true;
            this.InstructionsTBX.Name = "InstructionsTBX";
            this.InstructionsTBX.ReadOnly = true;
            this.InstructionsTBX.Size = new System.Drawing.Size(357, 65);
            this.InstructionsTBX.TabIndex = 0;
            this.InstructionsTBX.Text = resources.GetString("InstructionsTBX.Text");
            // 
            // MassPlace
            // 
            this.MassPlace.Controls.Add(this.MassPlaceClearBTN);
            this.MassPlace.Controls.Add(this.MassPlaceScriptTBX);
            this.MassPlace.Controls.Add(this.textBox1);
            this.MassPlace.Location = new System.Drawing.Point(4, 22);
            this.MassPlace.Name = "MassPlace";
            this.MassPlace.Padding = new System.Windows.Forms.Padding(3);
            this.MassPlace.Size = new System.Drawing.Size(369, 304);
            this.MassPlace.TabIndex = 1;
            this.MassPlace.Text = "Mass Place";
            this.MassPlace.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(383, 460);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MoveObjectsBTN
            // 
            this.MoveObjectsBTN.Location = new System.Drawing.Point(6, 160);
            this.MoveObjectsBTN.Name = "MoveObjectsBTN";
            this.MoveObjectsBTN.Size = new System.Drawing.Size(123, 23);
            this.MoveObjectsBTN.TabIndex = 3;
            this.MoveObjectsBTN.Text = "Move/Rotate objects";
            this.MoveObjectsBTN.UseVisualStyleBackColor = true;
            // 
            // RotationTBX
            // 
            this.RotationTBX.Location = new System.Drawing.Point(136, 160);
            this.RotationTBX.Name = "RotationTBX";
            this.RotationTBX.Size = new System.Drawing.Size(100, 20);
            this.RotationTBX.TabIndex = 4;
            // 
            // MapScriptOutputTBX
            // 
            this.MapScriptOutputTBX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapScriptOutputTBX.Location = new System.Drawing.Point(6, 189);
            this.MapScriptOutputTBX.Multiline = true;
            this.MapScriptOutputTBX.Name = "MapScriptOutputTBX";
            this.MapScriptOutputTBX.Size = new System.Drawing.Size(357, 77);
            this.MapScriptOutputTBX.TabIndex = 5;
            // 
            // CopyClipboardBTN
            // 
            this.CopyClipboardBTN.Location = new System.Drawing.Point(6, 273);
            this.CopyClipboardBTN.Name = "CopyClipboardBTN";
            this.CopyClipboardBTN.Size = new System.Drawing.Size(123, 23);
            this.CopyClipboardBTN.TabIndex = 6;
            this.CopyClipboardBTN.Text = "Copy to Clipboard";
            this.CopyClipboardBTN.UseVisualStyleBackColor = true;
            this.CopyClipboardBTN.Click += new System.EventHandler(this.CopyClipboardBTN_Click);
            // 
            // MapScriptOutpClearBTN
            // 
            this.MapScriptOutpClearBTN.Location = new System.Drawing.Point(297, 275);
            this.MapScriptOutpClearBTN.Name = "MapScriptOutpClearBTN";
            this.MapScriptOutpClearBTN.Size = new System.Drawing.Size(66, 23);
            this.MapScriptOutpClearBTN.TabIndex = 7;
            this.MapScriptOutpClearBTN.Text = "Clear";
            this.MapScriptOutpClearBTN.UseVisualStyleBackColor = true;
            this.MapScriptOutpClearBTN.Click += new System.EventHandler(this.MapScriptOutpClearBTN_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(357, 65);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "This tool allows you to place objects randomly within a region X. Start by placin" +
    "g a region named X and paste the script in the textbox below.\r\n\r\n\r\n\r\n";
            // 
            // MassPlaceScriptTBX
            // 
            this.MassPlaceScriptTBX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MassPlaceScriptTBX.Location = new System.Drawing.Point(6, 77);
            this.MassPlaceScriptTBX.Multiline = true;
            this.MassPlaceScriptTBX.Name = "MassPlaceScriptTBX";
            this.MassPlaceScriptTBX.Size = new System.Drawing.Size(357, 77);
            this.MassPlaceScriptTBX.TabIndex = 2;
            // 
            // MassPlaceClearBTN
            // 
            this.MassPlaceClearBTN.Location = new System.Drawing.Point(297, 160);
            this.MassPlaceClearBTN.Name = "MassPlaceClearBTN";
            this.MassPlaceClearBTN.Size = new System.Drawing.Size(66, 23);
            this.MassPlaceClearBTN.TabIndex = 3;
            this.MassPlaceClearBTN.Text = "Clear";
            this.MassPlaceClearBTN.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 357);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.RegionMove.ResumeLayout(false);
            this.RegionMove.PerformLayout();
            this.MassPlace.ResumeLayout(false);
            this.MassPlace.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage RegionMove;
        private System.Windows.Forms.TextBox InstructionsTBX;
        private System.Windows.Forms.TabPage MassPlace;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox MapScriptTBX;
        private System.Windows.Forms.Button MapScriptClearBTN;
        private System.Windows.Forms.Button CopyClipboardBTN;
        private System.Windows.Forms.TextBox MapScriptOutputTBX;
        private System.Windows.Forms.TextBox RotationTBX;
        private System.Windows.Forms.Button MoveObjectsBTN;
        private System.Windows.Forms.Button MapScriptOutpClearBTN;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox MassPlaceScriptTBX;
        private System.Windows.Forms.Button MassPlaceClearBTN;
    }
}
