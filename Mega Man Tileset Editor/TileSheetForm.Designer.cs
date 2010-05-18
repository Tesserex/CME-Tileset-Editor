namespace Mega_Man_Tileset_Editor
{
    partial class TileSheetForm
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
            this.tileSheetPicture = new System.Windows.Forms.PictureBox();
            this.sizingPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tileSheetPicture)).BeginInit();
            this.sizingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileSheetPicture
            // 
            this.tileSheetPicture.Location = new System.Drawing.Point(0, 0);
            this.tileSheetPicture.Name = "tileSheetPicture";
            this.tileSheetPicture.Size = new System.Drawing.Size(149, 134);
            this.tileSheetPicture.TabIndex = 2;
            this.tileSheetPicture.TabStop = false;
            this.tileSheetPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tileSheetPicture_MouseMove);
            this.tileSheetPicture.Click += new System.EventHandler(this.tileSheetPicture_Click);
            // 
            // sizingPanel
            // 
            this.sizingPanel.AutoScroll = true;
            this.sizingPanel.Controls.Add(this.tileSheetPicture);
            this.sizingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sizingPanel.Location = new System.Drawing.Point(0, 0);
            this.sizingPanel.Name = "sizingPanel";
            this.sizingPanel.Size = new System.Drawing.Size(281, 245);
            this.sizingPanel.TabIndex = 3;
            // 
            // TileSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(281, 245);
            this.Controls.Add(this.sizingPanel);
            this.Name = "TileSheetForm";
            this.Text = "TileSheetForm";
            this.Resize += new System.EventHandler(this.TileSheetForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tileSheetPicture)).EndInit();
            this.sizingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox tileSheetPicture;
        private System.Windows.Forms.Panel sizingPanel;
    }
}