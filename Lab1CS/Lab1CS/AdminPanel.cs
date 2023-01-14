using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1CS
{
    public partial class AdminPanel : Form
    {

        public delegate void RegimeChange(int state);
        public event RegimeChange change;
        public AdminPanel()
        {
            InitializeComponent();
            status.SelectedItem = "user";
        }

        private void status_SelectedIndexChanged(object sender, EventArgs e) {
            if (status.SelectedItem.ToString() == "admin") passText.Enabled = true;
            else {
                passText.Enabled = false;
                passText.Text = "";
            }
        }

        private void ok_Click(object sender, EventArgs e) {
            const string password = "eLBe7vPtPninOOoBQzdsZw==";
            string result = status.SelectedItem.ToString() + passText.Text;
            var hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(result));
            if (Convert.ToBase64String(hash) == password) {
                change?.Invoke(2);
                this.Close();
            }
            if (status.SelectedItem.ToString() == "user")
            {
                change?.Invoke(1);
                this.Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
