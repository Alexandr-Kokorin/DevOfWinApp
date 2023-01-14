using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab4CS
{
    public partial class MainForm : Form
    {
        private static List<Graphic> graphics;
        private static int index;

        public MainForm()
        {
            InitializeComponent();
            graphics = new List<Graphic>();
            graphics.Add(new Graphic(1));
            graphics.Add(new Graphic(2));
            graphics.Add(new Graphic(3));
            graphics.Add(new Graphic(4));
            userControl11.Content = graphics[0].myViewport3D;
            userControl12.Content = graphics[1].myViewport3D;
            userControl13.Content = graphics[2].myViewport3D;
            userControl14.Content = graphics[3].myViewport3D;
            index = 0;
        }

        public static Graphic getGraphic() {
            return graphics[index];
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e) {
            index = tabControl.SelectedIndex;
        }
    }
}
