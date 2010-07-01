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
    public partial class TilePropForm : Form
    {
        public TileProperties Properties { get; private set; }
        public TilesetEditor Tileset { get; private set; }

        public event EventHandler OkPressed;

        public TilePropForm(TilesetEditor editor, TileProperties properties)
        {
            InitializeComponent();

            this.Tileset = editor;
            this.Properties = properties;
            name.Text = properties.Name;
            checkBlocking.Checked = properties.Blocking;
            checkLethal.Checked = properties.Lethal;
            checkClimb.Checked = properties.Climbable;
            resistX.Value = (decimal)properties.ResistX;
            resistY.Value = (decimal)properties.ResistY;
            pushX.Value = (decimal)properties.PushX;
            pushY.Value = (decimal)properties.PushY;
            dragX.Value = (decimal)properties.DragX;
            dragY.Value = (decimal)properties.DragY;

            Tileset.Closed += (e) => this.Close();
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            this.Properties.Name = name.Text;
        }

        private void rmx_ValueChanged(object sender, EventArgs e)
        {
            Properties.ResistX = (float)resistX.Value;
        }

        private void rmy_ValueChanged(object sender, EventArgs e)
        {
            Properties.ResistY = (float)resistY.Value;
        }

        private void pcx_ValueChanged(object sender, EventArgs e)
        {
            Properties.PushX = (float)pushX.Value;
        }

        private void pcy_ValueChanged(object sender, EventArgs e)
        {
            Properties.PushY = (float)pushY.Value;
        }

        private void rcx_ValueChanged(object sender, EventArgs e)
        {
            Properties.DragX = (float)dragX.Value;
        }

        private void rcy_ValueChanged(object sender, EventArgs e)
        {
            Properties.DragY = (float)dragY.Value;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Tileset.AddProperties(Properties);
            if (OkPressed != null) OkPressed(this, new EventArgs());
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gravMult_ValueChanged(object sender, EventArgs e)
        {
            Properties.GravityMult = (float)gravMult.Value;
        }

        private void checkBlocking_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Blocking = checkBlocking.Checked;
        }

        private void checkLethal_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Lethal = checkLethal.Checked;
        }

        private void checkClimb_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Climbable = checkClimb.Checked;
        }
    }
}
