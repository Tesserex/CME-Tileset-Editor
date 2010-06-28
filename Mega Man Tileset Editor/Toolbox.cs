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
        private Point oldLocation;

        public int Selected
        {
            get { return selected; }
            set
            {
                if (tileset == null || value >= tileset.Count) return;
                selected = value;
                currentFrame = 0;
                frameTicker.Value = 1;
                frameTicker.Minimum = 1;
                frameTicker.Maximum = tileset[selected].Sprite.Count;
                frameDuration.Value = (tileset[selected].Sprite.Count > 0) ? tileset[selected].Sprite[0].Duration : 0;
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

            ChangeTileset(tileset);
        }

        public void ChangeTileset(Tileset tileset)
        {
            this.tileset = tileset;

            if (image != null) image.Dispose();
            image = new Bitmap(tileset.TileSize, tileset.TileSize);
            image.SetResolution(tileset.Sheet.HorizontalResolution, tileset.Sheet.VerticalResolution);
            picture.Image = image;
            picture.Size = image.Size;

            comboProperties.Items.Clear();
            foreach (TileProperties props in tileset.Properties)
            {
                comboProperties.Items.Add(props.Name);
            }
            comboProperties.Items.Add("<New...>");

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

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!Environment.HasShutdownStarted)
            {
                e.Cancel = true;
                this.oldLocation = this.Location;
                this.Hide();
            }
            base.OnClosing(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (this.Visible && this.oldLocation != Point.Empty) this.Location = this.oldLocation;
            base.OnVisibleChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterImage();
            ReDraw();
        }

        protected override void OnMove(EventArgs e)
        {
            if (this.Top < 15)
            {
                this.Top = 5;
            }
            if (this.Left < 15)
            {
                this.Left = 5;
            }
            if (this.Bottom > this.MdiParent.ClientRectangle.Height - 15)
            {
                this.Top = this.MdiParent.ClientRectangle.Height - this.Height - 5;
            }
            if (this.Right > this.MdiParent.ClientRectangle.Width - 15)
            {
                this.Left = this.MdiParent.ClientRectangle.Width - this.Width - 5;
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

            picture.Left = (tilePanel.Width - picture.Width - 10) / 2 + 5;
            picture.Top = (tilePanel.Height - picture.Height - 10) / 2 + 5;
        }

        private void frameTicker_Change(object sender, EventArgs e)
        {
            if (tileset == null || frameTicker.Value > tileset[selected].Sprite.Count) return;

            currentFrame = (int)frameTicker.Value - 1;
            frameDuration.Value = tileset[selected].Sprite[currentFrame].Duration;
            ReDraw();
        }

        private void buttonAddFrame_Click(object sender, EventArgs e)
        {
            tileset[selected].Sprite.AddFrame();
            frameTicker.Maximum = tileset[selected].Sprite.Count - 1;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tileset[selected].Sprite[currentFrame].Duration = (int)frameDuration.Value;
        }

        private void comboProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProperties.SelectedIndex == comboProperties.Items.Count - 1) // <New...> selected
            {
                MegaMan.TileProperties properties = new TileProperties();
                properties.Name = "NewProperties";
                TilePropForm propForm = new TilePropForm(properties);
                propForm.OkPressed += propForm_OkPressed;
                propForm.Show();

                comboProperties.SelectedIndex = 0;
            }
            else tileset[selected].Properties = tileset.GetProperties(comboProperties.SelectedItem.ToString());
        }

        private void propForm_OkPressed(object sender, EventArgs e)
        {
            TilePropForm propform = ((TilePropForm)sender);
            tileset.AddProperties(propform.Properties);
            if (!comboProperties.Items.Contains(propform.Properties.Name)) comboProperties.Items.Add(propform.Properties.Name);
        }

        private void textTileName_TextChanged(object sender, EventArgs e)
        {
            tileset[selected].Name = textTileName.Text;
        }

        private void propEdit_Click(object sender, EventArgs e)
        {
            TileProperties properties = tileset.GetProperties(comboProperties.SelectedItem.ToString());
            TilePropForm propForm = new TilePropForm(properties);
            propForm.OkPressed += propForm_OkPressed;
            propForm.Show();
        }
    }
}
