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
        private List<TileSheetForm> sheetForms = new List<TileSheetForm>();
        private TileSheetForm activeSheet;
        private TileListForm listForm;
        private Toolbox toolboxForm;

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
            Tileset tileset = new Tileset(tileImage, 16);
            tileset.SheetPathAbs = path;

            LoadTilesetForms(tileset);
        }

        private void LoadTilesetForms(Tileset tiles)
        {
            if (tiles == null) return;

            if (listForm == null)
            {
                listForm = new TileListForm(this, tiles);
                listForm.Show();
                listForm.Top = 10;
                listForm.Left = 10;
                listForm.SelectedChanged += new Action<int>(listForm_SelectedChanged);
            }

            if (toolboxForm == null)
            {
                toolboxForm = new Toolbox(this, tiles);
                toolboxForm.Show();
                toolboxForm.Top = 120;
                toolboxForm.Left = 350;
            }

            var sheet = new TileSheetForm(this, tiles);
            sheet.Show();
            sheet.Top = 120;
            sheet.Left = 10;
            sheet.SheetClicked += new Action<Point>(sheetForm_SheetClicked);
            sheet.GotFocus += new EventHandler(sheet_GotFocus);
            sheetForms.Add(sheet);

            ChangeSheet(sheet);
        }

        void sheet_GotFocus(object sender, EventArgs e)
        {
            ChangeSheet((TileSheetForm)sender);
        }

        public void ChangeSheet(TileSheetForm form)
        {
            this.activeSheet = form;
            if (listForm != null) listForm.ChangeTileset(activeSheet.Tileset);
            if (toolboxForm != null) toolboxForm.ChangeTileset(activeSheet.Tileset);
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
            foreach (var sheet in sheetForms) sheet.Snap = customizeToolStripMenuItem.Checked;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeSheet.Tileset == null) return;
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
                activeSheet.Tileset.Save(dialog.FileName);
                this.activeSheet.Text = dialog.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeSheet == null) return;
            if (activeSheet.Tileset.FilePath != null) activeSheet.Tileset.Save();
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
                Tileset tileset = new Tileset(path);

                LoadTilesetForms(tileset);

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
