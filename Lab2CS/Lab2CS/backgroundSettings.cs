using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2CS
{
    public partial class BackgroundSettings : Form
    {
        public int selectedIndex;
        public Color color;
        public int hatching;
        public string characters;
        public int image;

        public BackgroundSettings() {
            InitializeComponent();
            checkedListBox.SetItemChecked(0, true);
            checkedListBox.SelectedIndex = 0;
            colorDialog.Color = Color.White;
            hatchingSelect.SelectedIndex = 0;
            imageSelect.SelectedIndex = 0;
            color = Color.White;
            hatching = 0;
            characters = "";
            image = 0;
            selectedIndex = 0;
        }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (checkedListBox.CheckedItems.Count > 1) {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                    checkedListBox.SetItemChecked(i, false);
                checkedListBox.SetItemChecked(checkedListBox.SelectedIndex, true);
            }
            colorSelect.Visible = false;
            hatchingSelect.Visible = false;
            enterCharacters.Visible = false;
            imageSelect.Visible = false;
            switch (checkedListBox.SelectedIndex) {
                case 0: colorSelect.Visible = true; break;
                case 1: hatchingSelect.Visible = true; break;
                case 2: enterCharacters.Visible = true; break;
                case 3: imageSelect.Visible = true; break;
            }
        }

        private void colorSelect_Click(object sender, EventArgs e) {
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                color = colorDialog.Color;
            }
        }

        private void ok_Click(object sender, EventArgs e) {
            hatching = hatchingSelect.SelectedIndex;
            characters = enterCharacters.Text;
            selectedIndex = checkedListBox.SelectedIndex;
            image = imageSelect.SelectedIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
