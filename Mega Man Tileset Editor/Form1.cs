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
        private Dictionary<string, TileSheetForm> savedSheets = new Dictionary<string, TileSheetForm>();
        private TileSheetForm activeSheet;
        private TileListForm listForm;
        private Toolbox toolboxForm;

        private bool snap;
        public bool Snap { get { return snap; } private set { snap = value; customizeToolStripMenuItem.Checked = value; } }

        public Form1()
        {
            InitializeComponent();
            Snap = true;
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

                try
                {
                    TilesetEditor editor = TilesetEditor.CreateNew(path, 16);
                    LoadTilesetForms(editor);
                }
                catch
                {
                    MessageBox.Show("The selected image file either doesn't exist or could not be read as an image.", "Image Load Error", MessageBoxButtons.OK);
                }
            }
        }

        private void LoadTilesetForms(TilesetEditor tiles)
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
            
            if (!string.IsNullOrEmpty(tiles.FilePath)) savedSheets.Add(tiles.FilePath, sheet);

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
            Snap = !Snap;
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
                string oldname = activeSheet.Tileset.FilePath;

                activeSheet.Tileset.SaveAs(dialog.FileName);
                this.activeSheet.Text = dialog.FileName;

                if (!string.IsNullOrEmpty(oldname)) savedSheets.Remove(oldname);
                savedSheets.Add(dialog.FileName, activeSheet);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeSheet == null) return;
            if (string.IsNullOrEmpty(activeSheet.Tileset.FilePath)) SaveAs();
            else activeSheet.Tileset.Save();
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
                if (savedSheets.ContainsKey(path))
                {
                    savedSheets[path].Focus();
                    return;
                }

                TilesetEditor tileset = TilesetEditor.FromFile(path);

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
