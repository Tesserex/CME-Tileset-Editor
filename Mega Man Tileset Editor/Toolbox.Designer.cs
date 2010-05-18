namespace Mega_Man_Tileset_Editor
{
    partial class Toolbox
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
            this.tilePanel = new System.Windows.Forms.Panel();
            this.picture = new System.Windows.Forms.PictureBox();
            this.toolPanel = new System.Windows.Forms.Panel();
            this.textTileName = new System.Windows.Forms.TextBox();
            this.comboProperties = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonAddFrame = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.toolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // tilePanel
            // 
            this.tilePanel.Controls.Add(this.picture);
            this.tilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilePanel.Location = new System.Drawing.Point(0, 0);
            this.tilePanel.Name = "tilePanel";
            this.tilePanel.Padding = new System.Windows.Forms.Padding(3);
            this.tilePanel.Size = new System.Drawing.Size(117, 92);
            this.tilePanel.TabIndex = 0;
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(12, 3);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(96, 82);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // toolPanel
            // 
            this.toolPanel.Controls.Add(this.textTileName);
            this.toolPanel.Controls.Add(this.comboProperties);
            this.toolPanel.Controls.Add(this.label1);
            this.toolPanel.Controls.Add(this.numericUpDown1);
            this.toolPanel.Controls.Add(this.buttonAddFrame);
            this.toolPanel.Controls.Add(this.trackBar1);
            this.toolPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolPanel.Location = new System.Drawing.Point(0, 92);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(117, 167);
            this.toolPanel.TabIndex = 1;
            // 
            // textTileName
            // 
            this.textTileName.Location = new System.Drawing.Point(10, 109);
            this.textTileName.Name = "textTileName";
            this.textTileName.Size = new System.Drawing.Size(91, 20);
            this.textTileName.TabIndex = 7;
            this.textTileName.TextChanged += new System.EventHandler(this.textTileName_TextChanged);
            // 
            // comboProperties
            // 
            this.comboProperties.FormattingEnabled = true;
            this.comboProperties.Location = new System.Drawing.Point(10, 82);
            this.comboProperties.Name = "comboProperties";
            this.comboProperties.Size = new System.Drawing.Size(91, 21);
            this.comboProperties.TabIndex = 6;
            this.comboProperties.Text = "Properties";
            this.comboProperties.SelectedIndexChanged += new System.EventHandler(this.comboProperties_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Duration:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(70, 27);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(35, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonAddFrame
            // 
            this.buttonAddFrame.AutoSize = true;
            this.buttonAddFrame.Location = new System.Drawing.Point(24, 53);
            this.buttonAddFrame.Name = "buttonAddFrame";
            this.buttonAddFrame.Size = new System.Drawing.Size(68, 23);
            this.buttonAddFrame.TabIndex = 1;
            this.buttonAddFrame.Text = "Add Frame";
            this.buttonAddFrame.UseVisualStyleBackColor = true;
            this.buttonAddFrame.Click += new System.EventHandler(this.buttonAddFrame_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(0, 0);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(117, 21);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Toolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(117, 259);
            this.Controls.Add(this.tilePanel);
            this.Controls.Add(this.toolPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Toolbox";
            this.Text = "Toolbox";
            this.tilePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.toolPanel.ResumeLayout(false);
            this.toolPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tilePanel;
        private System.Windows.Forms.Panel toolPanel;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button buttonAddFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboProperties;
        private System.Windows.Forms.TextBox textTileName;
    }
}