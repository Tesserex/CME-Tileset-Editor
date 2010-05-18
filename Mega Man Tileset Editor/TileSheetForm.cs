﻿using System;
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
        private Tileset tileset;
        private Point highlight;
        private Pen highlightPen;

        public event Action<Point> SheetClicked;
        public bool Snap { get; set; }

        public TileSheetForm()
        {
            InitializeComponent();
        }

        public TileSheetForm(Form owner, Tileset tileset)
        {
            InitializeComponent();

            this.MdiParent = owner;

            this.tileset = tileset;
            tileSheetImage = new Bitmap(tileset.Sheet.Width, tileset.Sheet.Height);
            tileSheetImage.SetResolution(tileset.Sheet.HorizontalResolution, tileset.Sheet.VerticalResolution);
            tileSheetPicture.Image = tileSheetImage;
            tileSheetPicture.Size = tileset.Sheet.Size;

            CenterImage();

            highlightPen = new Pen(Brushes.Green);
            Snap = true;

            ReDraw();
        }

        private void ReDraw()
        {
            if (tileset == null) return;
            if (tileset.Sheet == null) return;

            using (Graphics g = Graphics.FromImage(tileSheetPicture.Image))
            {
                g.DrawImage(tileset.Sheet, 0, 0);

                if (highlight != Point.Empty)
                {
                    g.DrawRectangle(highlightPen, highlight.X, highlight.Y, tileset.TileSize, tileset.TileSize);
                }
            }

            tileSheetPicture.Refresh();
        }

        private void tileSheetPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (Snap)
            {
                highlight.X = e.X / tileset.TileSize;
                highlight.Y = e.Y / tileset.TileSize;

                highlight.X *= tileset.TileSize;
                highlight.Y *= tileset.TileSize;
            }
            else
            {
                highlight.X = e.X - tileset.TileSize / 2;
                highlight.Y = e.Y - tileset.TileSize / 2;
            }

            ReDraw();
        }

        private void TileSheetForm_Resize(object sender, EventArgs e)
        {
            CenterImage();
        }

        private void CenterImage()
        {
            tileSheetPicture.Left = (sizingPanel.Width - tileSheetPicture.Width) / 2;
            tileSheetPicture.Top = (sizingPanel.Height - tileSheetPicture.Height) / 2;
        }

        private void tileSheetPicture_Click(object sender, EventArgs e)
        {
            if (SheetClicked != null) SheetClicked(highlight);
        }
    }
}