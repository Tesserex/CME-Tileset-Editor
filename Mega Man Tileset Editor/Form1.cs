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
    public partial class Form1 : Form
    {
        private TileSheetForm sheetForm;
        private TileListForm listForm;
        private Toolbox toolboxForm;
        private Tileset tileset;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "PNG (*.png)|*.png|GIF (*.gif)|*.gif";
            dialog.Title = "Choose Image for Tile Sheet";
            
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = dialog.FileName;
                Image sheet;

                try
                {
                    sheet = Image.FromFile(path);
                }
                catch
                {
                    MessageBox.Show("The selected image file either doesn't exist or could not be read as an image.", "Image Load Error", MessageBoxButtons.OK);
                    return;
                }

                NewTileset(sheet, path);
            }
        }

        private void NewTileset(Image tileImage, string path)
        {
            tileset = new Tileset(tileImage, 16);
            tileset.SheetPathAbs = path;

            LoadTilesetForms();
        }

        private void LoadTilesetForms()
        {
            if (tileset == null) return;

            sheetForm = new TileSheetForm(this, tileset);
            sheetForm.Text = "Untitled";
            sheetForm.Show();
            sheetForm.Top = 120;
            sheetForm.Left = 10;

            listForm = new TileListForm(this, tileset);
            listForm.Show();
            listForm.Top = 10;
            listForm.Left = 10;

            toolboxForm = new Toolbox(this, tileset);
            toolboxForm.Show();
            toolboxForm.Top = 120;
            toolboxForm.Left = 350;

            listForm.SelectedChanged += new Action<int>(listForm_SelectedChanged);
            sheetForm.SheetClicked += new Action<Point>(sheetForm_SheetClicked);
        }

        void sheetForm_SheetClicked(Point obj)
        {
            toolboxForm.SetFrameImage(obj);
        }

        private void listForm_SelectedChanged(int obj)
        {
            toolboxForm.Selected = obj;
        }

        private void tileSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sheetForm != null) sheetForm.Show();
        }

        private void tilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listForm != null) listForm.Show();
        }

        private void toolboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolboxForm != null) toolboxForm.Show();
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sheetForm.Snap = customizeToolStripMenuItem.Checked;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.OverwritePrompt = true;
            dialog.Filter = "XML (*.xml)|*.xml";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                tileset.Save(dialog.FileName);
                sheetForm.Text = dialog.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tileset.FilePath != null) tileset.Save();
            else SaveAs();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "XML (*.xml)|*.xml";
            dialog.Title = "Load Tileset";
            
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = dialog.FileName;
                tileset = new Tileset(path);

                LoadTilesetForms();

                toolboxForm.Selected = 0;
            }
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listForm != null) this.listForm.SelectNext();
        }

        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listForm != null) this.listForm.SelectPrev();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
