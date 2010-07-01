namespace Mega_Man_Tileset_Editor
{
    partial class TilePropForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.checkBlocking = new System.Windows.Forms.CheckBox();
            this.checkLethal = new System.Windows.Forms.CheckBox();
            this.checkClimb = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dragY = new System.Windows.Forms.NumericUpDown();
            this.pushY = new System.Windows.Forms.NumericUpDown();
            this.resistY = new System.Windows.Forms.NumericUpDown();
            this.dragX = new System.Windows.Forms.NumericUpDown();
            this.pushX = new System.Windows.Forms.NumericUpDown();
            this.resistX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gravMult = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dragY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pushY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resistY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pushX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resistX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gravMult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Property Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(95, 9);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(117, 20);
            this.name.TabIndex = 1;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(153, 172);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(58, 22);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(94, 172);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(53, 21);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // checkBlocking
            // 
            this.checkBlocking.AutoSize = true;
            this.checkBlocking.Location = new System.Drawing.Point(12, 40);
            this.checkBlocking.Name = "checkBlocking";
            this.checkBlocking.Size = new System.Drawing.Size(67, 17);
            this.checkBlocking.TabIndex = 4;
            this.checkBlocking.Text = "Blocking";
            this.checkBlocking.UseVisualStyleBackColor = true;
            this.checkBlocking.CheckedChanged += new System.EventHandler(this.checkBlocking_CheckedChanged);
            // 
            // checkLethal
            // 
            this.checkLethal.AutoSize = true;
            this.checkLethal.Location = new System.Drawing.Point(85, 40);
            this.checkLethal.Name = "checkLethal";
            this.checkLethal.Size = new System.Drawing.Size(55, 17);
            this.checkLethal.TabIndex = 5;
            this.checkLethal.Text = "Lethal";
            this.checkLethal.UseVisualStyleBackColor = true;
            this.checkLethal.CheckedChanged += new System.EventHandler(this.checkLethal_CheckedChanged);
            // 
            // checkClimb
            // 
            this.checkClimb.Location = new System.Drawing.Point(146, 40);
            this.checkClimb.Name = "checkClimb";
            this.checkClimb.Size = new System.Drawing.Size(75, 17);
            this.checkClimb.TabIndex = 0;
            this.checkClimb.Text = "Climbable";
            this.checkClimb.UseVisualStyleBackColor = true;
            this.checkClimb.CheckedChanged += new System.EventHandler(this.checkClimb_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gravity Multiplier";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dragY, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pushY, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.resistY, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dragX, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pushX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.resistX, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(52, 110);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(161, 50);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // dragY
            // 
            this.dragY.DecimalPlaces = 2;
            this.dragY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.dragY.Location = new System.Drawing.Point(109, 28);
            this.dragY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.dragY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.dragY.Name = "dragY";
            this.dragY.Size = new System.Drawing.Size(46, 20);
            this.dragY.TabIndex = 7;
            this.dragY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dragY.ValueChanged += new System.EventHandler(this.rcy_ValueChanged);
            // 
            // pushY
            // 
            this.pushY.DecimalPlaces = 2;
            this.pushY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.pushY.Location = new System.Drawing.Point(56, 28);
            this.pushY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.pushY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.pushY.Name = "pushY";
            this.pushY.Size = new System.Drawing.Size(47, 20);
            this.pushY.TabIndex = 6;
            this.pushY.ValueChanged += new System.EventHandler(this.pcy_ValueChanged);
            // 
            // resistY
            // 
            this.resistY.DecimalPlaces = 2;
            this.resistY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.resistY.Location = new System.Drawing.Point(3, 28);
            this.resistY.Name = "resistY";
            this.resistY.Size = new System.Drawing.Size(47, 20);
            this.resistY.TabIndex = 5;
            this.resistY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.resistY.ValueChanged += new System.EventHandler(this.rmy_ValueChanged);
            // 
            // dragX
            // 
            this.dragX.DecimalPlaces = 2;
            this.dragX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.dragX.Location = new System.Drawing.Point(109, 3);
            this.dragX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.dragX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.dragX.Name = "dragX";
            this.dragX.Size = new System.Drawing.Size(47, 20);
            this.dragX.TabIndex = 3;
            this.dragX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dragX.ValueChanged += new System.EventHandler(this.rcx_ValueChanged);
            // 
            // pushX
            // 
            this.pushX.DecimalPlaces = 2;
            this.pushX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.pushX.Location = new System.Drawing.Point(56, 3);
            this.pushX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.pushX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.pushX.Name = "pushX";
            this.pushX.Size = new System.Drawing.Size(47, 20);
            this.pushX.TabIndex = 2;
            this.pushX.ValueChanged += new System.EventHandler(this.pcx_ValueChanged);
            // 
            // resistX
            // 
            this.resistX.DecimalPlaces = 2;
            this.resistX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.resistX.Location = new System.Drawing.Point(3, 3);
            this.resistX.Name = "resistX";
            this.resistX.Size = new System.Drawing.Size(47, 20);
            this.resistX.TabIndex = 1;
            this.resistX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.resistX.ValueChanged += new System.EventHandler(this.rmx_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "X Axis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y Axis";
            // 
            // gravMult
            // 
            this.gravMult.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.gravMult.Location = new System.Drawing.Point(99, 62);
            this.gravMult.Name = "gravMult";
            this.gravMult.Size = new System.Drawing.Size(39, 20);
            this.gravMult.TabIndex = 11;
            this.gravMult.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gravMult.ValueChanged += new System.EventHandler(this.gravMult_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Resist";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(117, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Push";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Traction";
            // 
            // TilePropForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(223, 206);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gravMult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkClimb);
            this.Controls.Add(this.checkLethal);
            this.Controls.Add(this.checkBlocking);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TilePropForm";
            this.Text = "Edit Tile Properties";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dragY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pushY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resistY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pushX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resistX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gravMult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox checkBlocking;
        private System.Windows.Forms.CheckBox checkLethal;
        private System.Windows.Forms.CheckBox checkClimb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown gravMult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown dragY;
        private System.Windows.Forms.NumericUpDown pushY;
        private System.Windows.Forms.NumericUpDown resistY;
        private System.Windows.Forms.NumericUpDown dragX;
        private System.Windows.Forms.NumericUpDown pushX;
        private System.Windows.Forms.NumericUpDown resistX;
    }
}