namespace GUI
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
            this.MassPlace = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.InstructionsTBX = new System.Windows.Forms.TextBox();
            this.MapScriptTBX = new System.Windows.Forms.TextBox();
            this.MapScriptClearBTN = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.RegionMove.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(391, 486);
            this.tabControl1.TabIndex = 0;
            // 
            // RegionMove
            // 
            this.RegionMove.Controls.Add(this.MapScriptClearBTN);
            this.RegionMove.Controls.Add(this.MapScriptTBX);
            this.RegionMove.Controls.Add(this.InstructionsTBX);
            this.RegionMove.Location = new System.Drawing.Point(4, 22);
            this.RegionMove.Name = "RegionMove";
            this.RegionMove.Padding = new System.Windows.Forms.Padding(3);
            this.RegionMove.Size = new System.Drawing.Size(383, 460);
            this.RegionMove.TabIndex = 0;
            this.RegionMove.Text = "Edit Region";
            this.RegionMove.UseVisualStyleBackColor = true;
            // 
            // MassPlace
            // 
            this.MassPlace.Location = new System.Drawing.Point(4, 22);
            this.MassPlace.Name = "MassPlace";
            this.MassPlace.Padding = new System.Windows.Forms.Padding(3);
            this.MassPlace.Size = new System.Drawing.Size(383, 460);
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
            // InstructionsTBX
            // 
            this.InstructionsTBX.Location = new System.Drawing.Point(7, 7);
            this.InstructionsTBX.Multiline = true;
            this.InstructionsTBX.Name = "InstructionsTBX";
            this.InstructionsTBX.ReadOnly = true;
            this.InstructionsTBX.Size = new System.Drawing.Size(354, 64);
            this.InstructionsTBX.TabIndex = 0;
            this.InstructionsTBX.Text = resources.GetString("InstructionsTBX.Text");
            // 
            // MapScriptTBX
            // 
            this.MapScriptTBX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapScriptTBX.Location = new System.Drawing.Point(7, 77);
            this.MapScriptTBX.Multiline = true;
            this.MapScriptTBX.Name = "MapScriptTBX";
            this.MapScriptTBX.Size = new System.Drawing.Size(354, 77);
            this.MapScriptTBX.TabIndex = 1;
            // 
            // MapScriptClearBTN
            // 
            this.MapScriptClearBTN.Location = new System.Drawing.Point(297, 160);
            this.MapScriptClearBTN.Name = "MapScriptClearBTN";
            this.MapScriptClearBTN.Size = new System.Drawing.Size(64, 23);
            this.MapScriptClearBTN.TabIndex = 2;
            this.MapScriptClearBTN.Text = "Clear";
            this.MapScriptClearBTN.UseVisualStyleBackColor = true;
            this.MapScriptClearBTN.Click += new System.EventHandler(this.MapScriptClearBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 510);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.RegionMove.ResumeLayout(false);
            this.RegionMove.PerformLayout();
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
    }
}

