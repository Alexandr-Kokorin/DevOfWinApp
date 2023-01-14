using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1CS
{
    public partial class CreateAndChangeForm : Form
    {
        public Person person;
        private int state;
        private int cardNumber;

        public CreateAndChangeForm(int state, Person person)
        {
            InitializeComponent();
            this.state = state;
            if (state == 1) { 
                this.Text = "Создать";
                if (MainForm.secretMode == true) nameText.Text = "Иван";
            }
            if (state == 2) {
                cardNumber = person.CardNumber;
                this.Text = "Изменить";
                nameText.Text = person.Name;
                dateTimePicker.Value = person.Bithday;
                cardNumberText.Text = person.CardNumber.ToString();
                dateTimePicker.Enabled = false;
                cardNumberText.Enabled = false;
            }
        }

        private void cardNumberText_KeyPress(object sender, KeyPressEventArgs e) {
            if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete)) {
                e.Handled = true;
            }
            if (state == 1 || cardNumber == int.Parse(cardNumberText.Text)) accept.Location = new Point(28, 175);
        }

        private void accept_Click(object sender, EventArgs e) {
            int temp;
            if (nameText.Text != "" && cardNumberText.TextLength == 5 && dateTimePicker.Value <= DateTime.Now && int.TryParse(cardNumberText.Text, out temp))
            {
                person = new Person(nameText.Text, dateTimePicker.Value, int.Parse(cardNumberText.Text));
                this.DialogResult = DialogResult.OK;
                this.Close();
            } 
            else {
                if (nameText.Text == "") 
                    MessageBox.Show("Введите имя", "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (cardNumberText.TextLength != 5 || !int.TryParse(cardNumberText.Text, out temp))
                    MessageBox.Show("Введите карту правильно", "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (dateTimePicker.Value > DateTime.Now)
                    MessageBox.Show("Введите дату правильно", "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keyData) {
            if (state == 2 && (keyData & Keys.Control) == Keys.Control && (keyData & Keys.Shift) == Keys.Shift && (keyData & Keys.L) == Keys.L) {
                AdminPanel panel = new AdminPanel();
                panel.change += userOrAdminState;
                panel.Show();
            }
            return base.ProcessCmdKey(ref message, keyData);
        }

        private void userOrAdminState(int state)
        {
            if (state == 1)
            {
                this.Text = "Изменить";
                this.BackColor = Color.White;
                nameText.BackColor = Color.White;
                cardNumberText.BackColor = Color.White;
                dateTimePicker.BackColor = Color.White;
                accept.BackColor = Color.White;
                cancel.BackColor = Color.White;
                dateTimePicker.Enabled = false;
                cardNumberText.Enabled = false;
            }
            if (state == 2)
            {
                this.Text = "Изменить (Admin)";
                this.BackColor = Color.GreenYellow;
                nameText.BackColor = Color.LightYellow;
                cardNumberText.BackColor = Color.LightYellow;
                dateTimePicker.BackColor = Color.LightYellow;
                accept.BackColor = Color.LightYellow;
                cancel.BackColor = Color.LightYellow;
                dateTimePicker.Enabled = true;
                cardNumberText.Enabled = true;
            }
        }

        private void acceptMove(MouseEventArgs e, int addX, int addY) {
            if (state == 1 || cardNumber == int.Parse(cardNumberText.Text)) return;
            int distance = (int)Math.Sqrt(Math.Pow(128 - e.X - addX, 2) + Math.Pow(191 - e.Y - addY, 2));
            if (distance <= 228) {
                accept.Location = new Point(28 + (114 - distance / 2), accept.Location.Y);
                if (distance <= 22) accept.Location = new Point(142, 175);
            }
        }

        private void CreateAndChangeForm_MouseMove(object sender, MouseEventArgs e) {
            acceptMove(e, 0, 0);
        }

        private void cancel_MouseMove(object sender, MouseEventArgs e) {
            acceptMove(e, 142, 175);
        }

    }
}
