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
    public partial class TileSheetForm : Form
    {
        private Bitmap tileSheetImage;
        public TilesetEditor Tileset { get; private set; }
        private Point highlight;
        private Pen highlightPen;
        private Point oldLocation;
        private Form1 owner;

        public event Action<Point> SheetClicked;
        public bool Snap { get { return owner.Snap; } }

        public TileSheetForm()
        {
            InitializeComponent();
        }

        public TileSheetForm(Form1 owner, TilesetEditor tileset)
        {
            InitializeComponent();

            this.owner = owner;
            this.MdiParent = owner;

            this.Tileset = tileset;
            tileSheetImage = new Bitmap(tileset.Sheet.Width, tileset.Sheet.Height);
            tileSheetImage.SetResolution(tileset.Sheet.HorizontalResolution, tileset.Sheet.VerticalResolution);
            tileSheetPicture.Image = tileSheetImage;
            tileSheetPicture.Size = tileset.Sheet.Size;

            if (string.IsNullOrEmpty(tileset.FilePath)) this.Text = "Untitled";
            else this.Text = tileset.FilePath;

            tileset.DirtyChanged += new Action<bool>(tileset_DirtyChanged);

            CenterImage();

            highlightPen = new Pen(Brushes.Green);

            ReDraw();
        }

        void tileset_DirtyChanged(bool dirty)
        {
            if (dirty) this.Text = "* ";
            if (string.IsNullOrEmpty(Tileset.FilePath)) this.Text += "Untitled";
            else this.Text += Tileset.FilePath;
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

        private void ReDraw()
        {
            if (Tileset == null) return;
            if (Tileset.Sheet == null) return;

            using (Graphics g = Graphics.FromImage(tileSheetPicture.Image))
            {
                g.Clear(Color.LightGray);
                g.DrawImage(Tileset.Sheet, 0, 0);

                if (highlight != Point.Empty)
                {
                    g.DrawRectangle(highlightPen, highlight.X, highlight.Y, Tileset.TileSize, Tileset.TileSize);
                }
            }

            tileSheetPicture.Refresh();
        }

        private void tileSheetPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (Snap)
            {
                highlight.X = e.X / Tileset.TileSize;
                highlight.Y = e.Y / Tileset.TileSize;

                highlight.X *= Tileset.TileSize;
                highlight.Y *= Tileset.TileSize;
            }
            else
            {
                highlight.X = e.X - Tileset.TileSize / 2;
                highlight.Y = e.Y - Tileset.TileSize / 2;
            }

            ReDraw();
        }

        private void TileSheetForm_Resize(object sender, EventArgs e)
        {
            CenterImage();
        }

        private void CenterImage()
        {
            tileSheetPicture.Left = Math.Max(0, (sizingPanel.Width - tileSheetPicture.Width) / 2);
            tileSheetPicture.Top = Math.Max(0, (sizingPanel.Height - tileSheetPicture.Height) / 2);
        }

        private void tileSheetPicture_Click(object sender, EventArgs e)
        {
            if (SheetClicked != null) SheetClicked(highlight);
        }
    }
}
