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
            this.propEdit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.frameTicker = new System.Windows.Forms.NumericUpDown();
            this.comboProperties = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.frameDuration = new System.Windows.Forms.NumericUpDown();
            this.buttonAddFrame = new System.Windows.Forms.Button();
            this.textTileName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.toolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameTicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameDuration)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tilePanel
            // 
            this.tilePanel.Controls.Add(this.picture);
            this.tilePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilePanel.Location = new System.Drawing.Point(0, 27);
            this.tilePanel.Name = "tilePanel";
            this.tilePanel.Padding = new System.Windows.Forms.Padding(3);
            this.tilePanel.Size = new System.Drawing.Size(128, 93);
            this.tilePanel.TabIndex = 0;
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(18, 6);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(96, 82);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // toolPanel
            // 
            this.toolPanel.Controls.Add(this.propEdit);
            this.toolPanel.Controls.Add(this.label3);
            this.toolPanel.Controls.Add(this.frameTicker);
            this.toolPanel.Controls.Add(this.comboProperties);
            this.toolPanel.Controls.Add(this.label1);
            this.toolPanel.Controls.Add(this.frameDuration);
            this.toolPanel.Controls.Add(this.buttonAddFrame);
            this.toolPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolPanel.Location = new System.Drawing.Point(0, 120);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(128, 107);
            this.toolPanel.TabIndex = 1;
            // 
            // propEdit
            // 
            this.propEdit.Location = new System.Drawing.Point(84, 79);
            this.propEdit.Name = "propEdit";
            this.propEdit.Size = new System.Drawing.Size(39, 21);
            this.propEdit.TabIndex = 10;
            this.propEdit.Text = "Edit";
            this.propEdit.UseVisualStyleBackColor = true;
            this.propEdit.Click += new System.EventHandler(this.propEdit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Current Frame";
            // 
            // frameTicker
            // 
            this.frameTicker.Location = new System.Drawing.Point(88, 6);
            this.frameTicker.Name = "frameTicker";
            this.frameTicker.ReadOnly = true;
            this.frameTicker.Size = new System.Drawing.Size(35, 20);
            this.frameTicker.TabIndex = 8;
            this.frameTicker.ValueChanged += new System.EventHandler(this.frameTicker_Change);
            // 
            // comboProperties
            // 
            this.comboProperties.FormattingEnabled = true;
            this.comboProperties.Location = new System.Drawing.Point(6, 79);
            this.comboProperties.Name = "comboProperties";
            this.comboProperties.Size = new System.Drawing.Size(72, 21);
            this.comboProperties.TabIndex = 6;
            this.comboProperties.Text = "Properties";
            this.comboProperties.SelectedIndexChanged += new System.EventHandler(this.comboProperties_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Frame Duration";
            // 
            // frameDuration
            // 
            this.frameDuration.Location = new System.Drawing.Point(88, 32);
            this.frameDuration.Name = "frameDuration";
            this.frameDuration.Size = new System.Drawing.Size(35, 20);
            this.frameDuration.TabIndex = 3;
            this.frameDuration.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonAddFrame
            // 
            this.buttonAddFrame.AutoSize = true;
            this.buttonAddFrame.Location = new System.Drawing.Point(10, 50);
            this.buttonAddFrame.Name = "buttonAddFrame";
            this.buttonAddFrame.Size = new System.Drawing.Size(68, 23);
            this.buttonAddFrame.TabIndex = 1;
            this.buttonAddFrame.Text = "Add Frame";
            this.buttonAddFrame.UseVisualStyleBackColor = true;
            this.buttonAddFrame.Click += new System.EventHandler(this.buttonAddFrame_Click);
            // 
            // textTileName
            // 
            this.textTileName.Location = new System.Drawing.Point(47, 3);
            this.textTileName.Name = "textTileName";
            this.textTileName.Size = new System.Drawing.Size(76, 20);
            this.textTileName.TabIndex = 7;
            this.textTileName.TextChanged += new System.EventHandler(this.textTileName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textTileName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 27);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name";
            // 
            // Toolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(128, 227);
            this.Controls.Add(this.toolPanel);
            this.Controls.Add(this.tilePanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Toolbox";
            this.Text = "Toolbox";
            this.tilePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.toolPanel.ResumeLayout(false);
            this.toolPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameTicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameDuration)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tilePanel;
        private System.Windows.Forms.Panel toolPanel;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button buttonAddFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown frameDuration;
        private System.Windows.Forms.ComboBox comboProperties;
        private System.Windows.Forms.TextBox textTileName;
        private System.Windows.Forms.NumericUpDown frameTicker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button propEdit;
    }
}