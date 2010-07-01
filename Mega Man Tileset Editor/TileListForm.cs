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
    public partial class TileListForm : Form
    {
        private TilesetEditor tileset;
        private Bitmap image;
        private int selected;
        private int hot;
        private Pen selectedPen, hotPen;
        private int zoom = 1;
        private int cols;

        private Point oldLocation;

        private bool _animate;
        private bool Animate
        {
            get { return _animate; }
            set
            {
                _animate = value;
                animateButton.Checked = value;
                Program.Animate(value);
                if (tileset != null)
                {
                    if (value) tileset.Play();
                    else tileset.Stop();
                }
            }
        }

        public event Action<int> SelectedChanged;

        public TileListForm()
        {
            InitializeComponent();
        }

        public TileListForm(Form owner, TilesetEditor tileset) : this()
        {
            selectedPen = new Pen(Brushes.Lime, 2);
            hotPen = new Pen(Brushes.Orange, 2);

            hot = selected = 0;

            this.MdiParent = owner;

            ChangeTileset(tileset);

            Program.FrameTick += new Action(Program_FrameTick);

            Animate = true;
        }

        public void ChangeTileset(TilesetEditor tileset)
        {
            if (this.tileset != null)
            {
                this.tileset.TileAdded -= tileset_TileAdded;
            }

            this.tileset = tileset;

            AdjustLayout(true);

            if (tileset != null)
            {
                tileset.TileAdded += tileset_TileAdded;

                if (Animate) tileset.Play();
                else tileset.Stop();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
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

        void Program_FrameTick()
        {
            if (tileset == null) return;
            tileset.Update();
            ReDraw();
        }

        public void SelectNext()
        {
            if (selected < tileset.Count - 1)
            {
                selected++;
                if (SelectedChanged != null) SelectedChanged(selected);
            }
        }

        public void SelectPrev()
        {
            if (selected > 0)
            {
                selected--;
                if (SelectedChanged != null) SelectedChanged(selected);
            }
        }

        void tileset_TileAdded()
        {
            AdjustLayout(true);
        }

        private void ReDraw()
        {
            if (image == null) return;
            if (tileset == null) return;
            if (tileset.Sheet == null) return;

            using (Graphics g = Graphics.FromImage(image))
            {
                g.Clear(Color.Black);

                int col = 0, y = 0;
                int hotX = -100, hotY = -100, selectedX = -100, selectedY = -100;
                for (int i = 0; i < tileset.Count; i++ )
                {
                    tileset.DrawTile(i, g, col * tileset.TileSize, y);
                    if (i == hot)
                    {
                        hotX = col * tileset.TileSize;
                        hotY = y;
                    }
                    if (i == selected)
                    {
                        selectedX = col * tileset.TileSize;
                        selectedY = y;
                    }

                    col++;
                    if (col >= this.cols)
                    {
                        col = 0;
                        y += tileset.TileSize;
                    }
                }

                // selection rectangle
                g.DrawRectangle(hotPen, hotX, hotY, tileset.TileSize, tileset.TileSize);
                g.DrawRectangle(selectedPen, selectedX, selectedY, tileset.TileSize, tileset.TileSize);
            }

            using (Graphics g = Graphics.FromImage(pictureList.Image))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(image, 0, 0, pictureList.Image.Width, pictureList.Image.Height);
            }

            pictureList.Refresh();
        }

        private void pictureList_MouseMove(object sender, MouseEventArgs e)
        {
            if (tileset == null) return;

            int col = e.X / (tileset.TileSize * zoom);
            int row = e.Y / (tileset.TileSize * zoom);

            hot = row * this.cols + col;

            ReDraw();
        }

        private void pictureList_Click(object sender, EventArgs e)
        {
            selected = hot;
            if (SelectedChanged != null) SelectedChanged(selected);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (tileset == null) return;
            tileset.AddTile();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (tileset == null) return;
            tileset.Stop();
            tileset.Play();
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            if (zoom < 5)
            {
                zoom++;
                ResizePicture();
                ReDraw();
            }
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            if (zoom > 1)
            {
                zoom--;
                ResizePicture();
                ReDraw();
            }
        }

        private void TileListForm_Resize(object sender, EventArgs e)
        {
            AdjustLayout(false);
        }

        private void AdjustLayout(bool forceRedraw)
        {
            int old = this.cols;
            if (tileset == null)
            {
                pictureList.Visible = false;
                this.cols = 0;
            }
            else
            {
                this.cols = (this.Width - 16) / (tileset.TileSize * zoom);
                this.cols = Math.Min(this.cols, tileset.Count);
                pictureList.Visible = true;
                if (this.cols != old)
                {
                    int rows = (int)Math.Ceiling(tileset.Count / (float)this.cols);

                    if (rows == 0 || cols == 0)
                    {
                        pictureList.Visible = false;
                    }
                    else
                    {
                        if (image != null) image.Dispose();
                        image = new Bitmap(this.cols * tileset.TileSize, rows * tileset.TileSize);
                        image.SetResolution(tileset.Sheet.HorizontalResolution, tileset.Sheet.VerticalResolution);

                        ResizePicture();
                    }
                }
            }
            if (this.cols != old || forceRedraw) ReDraw();
        }

        private void ResizePicture()
        {
            if (this.image == null) return;

            if (pictureList.Image != null) pictureList.Image.Dispose();
            pictureList.Image = new Bitmap(this.image.Width * zoom, this.image.Height * zoom);
            pictureList.Size = new Size(pictureList.Image.Size.Width, pictureList.Image.Size.Height);
        }

        private void animateButton_Click(object sender, EventArgs e)
        {
            Animate = !Animate;
        }

        private void pictureList_MouseLeave(object sender, EventArgs e)
        {
            hot = -1;
        }
    }
}
