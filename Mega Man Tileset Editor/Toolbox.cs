using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MegaMan;

namespace Mega_Man_Tileset_Editor
{
    public partial class Toolbox : Form
    {
        private Tileset tileset;
        private Bitmap image;
        private int selected;
        private int currentFrame;

        public int Selected
        {
            get { return selected; }
            set
            {
                if (tileset == null || value >= tileset.Count) return;
                selected = value;
                currentFrame = 0;
                trackBar1.Value = 0;
                trackBar1.Maximum = tileset[selected].Sprite.Count - 1;
                trackBar1.Enabled = (tileset[selected].Sprite.Count > 0);
                numericUpDown1.Value = (tileset[selected].Sprite.Count > 0) ? tileset[selected].Sprite[0].Duration : 0;
                textTileName.Text = tileset[selected].Name;
                comboProperties.SelectedItem = tileset[selected].Properties.Name;
                ReDraw();
            }
        }

        public Toolbox()
        {
            InitializeComponent();
        }

        public Toolbox(Form owner, Tileset tileset)
        {
            InitializeComponent();

            this.MdiParent = owner;

            this.tileset = tileset;
            image = new Bitmap(tileset.TileSize, tileset.TileSize);
            image.SetResolution(tileset.Sheet.HorizontalResolution, tileset.Sheet.VerticalResolution);
            picture.Image = image;
            picture.Size = image.Size;

            foreach (string propname in tileset.Properties.Keys)
            {
                comboProperties.Items.Add(propname);
            }

            tilePanel.MinimumSize = new Size(tileset.TileSize, tileset.TileSize);

            CenterImage();

            ReDraw();
        }

        public void SetFrameImage(Point point)
        {
            Bitmap frame = new Bitmap(tileset.TileSize, tileset.TileSize);
            frame.SetResolution(tileset.Sheet.HorizontalResolution, tileset.Sheet.VerticalResolution);
            using (Graphics g = Graphics.FromImage(frame))
            {
                g.DrawImage(tileset.Sheet, 0, 0, new Rectangle(point.X, point.Y, tileset.TileSize, tileset.TileSize), GraphicsUnit.Pixel);
            }

            tileset[selected].Sprite[currentFrame].SetSheetPosition(new Rectangle(point, new Size(tileset.TileSize, tileset.TileSize)));
            ReDraw();
        }

        protected override void OnResize(EventArgs e)
        {
            CenterImage();
            ReDraw();
            base.OnResize(e);
        }

        protected override void OnMove(EventArgs e)
        {
            
            this.Anchor = AnchorStyles.None;
            if (this.Top < 15)
            {
                this.Top = 5;
                this.Anchor |= AnchorStyles.Top;
            }
            if (this.Left < 15)
            {
                this.Left = 5;
                this.Anchor |= AnchorStyles.Left;
            }
            if (this.Bottom > this.MdiParent.ClientRectangle.Height - 15)
            {
                this.Top = this.MdiParent.ClientRectangle.Height - this.Height - 5;
                this.Anchor |= AnchorStyles.Bottom;
            }
            if (this.Right > this.MdiParent.ClientRectangle.Width - 15)
            {
                this.Left = this.MdiParent.ClientRectangle.Width - this.Width - 5;
                this.Anchor |= AnchorStyles.Right;
            }
            
            base.OnMove(e);
        }

        private void ReDraw()
        {
            if (tileset == null) return;
            if (tileset.Sheet == null) return;
            if (tileset.Count == 0) return;

            using (Graphics g = Graphics.FromImage(picture.Image))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                Image frame = tileset[selected].Sprite[currentFrame].CutTile;
                if (frame != null) g.DrawImage(frame, 0, 0, picture.Image.Width, picture.Image.Height);
                else g.Clear(Color.Black);
            }

            picture.Refresh();
        }

        private void CenterImage()
        {
            int size = Math.Min(tilePanel.Width-3, tilePanel.Height-3);
            picture.Width = size;
            picture.Height = size;

            if (tileset != null)
            {
                if (image != null) image.Dispose();
                image = new Bitmap(size, size);
                image.SetResolution(tileset.Sheet.HorizontalResolution, tileset.Sheet.VerticalResolution);
                picture.Image = image;
            }

            picture.Left = (tilePanel.Width - picture.Width) / 2;
            picture.Top = (tilePanel.Height - picture.Height) / 2;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (tileset == null || trackBar1.Value >= tileset[selected].Sprite.Count) return;

            currentFrame = trackBar1.Value;
            numericUpDown1.Value = tileset[selected].Sprite[currentFrame].Duration;
            ReDraw();
        }

        private void buttonAddFrame_Click(object sender, EventArgs e)
        {
            tileset[selected].Sprite.AddFrame();
            trackBar1.Maximum = tileset[selected].Sprite.Count - 1;
            trackBar1.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tileset[selected].Sprite[currentFrame].Duration = (int)numericUpDown1.Value;
        }

        private void comboProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            tileset[selected].Properties = tileset.Properties[comboProperties.SelectedItem.ToString()];
        }

        private void textTileName_TextChanged(object sender, EventArgs e)
        {
            tileset[selected].Name = textTileName.Text;
        }
    }
}
