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
    public partial class MainForm : Form
    {
        private List<Person> people = new List<Person>();
        private Database database = new Database();

        private Size sizeScreen = Screen.PrimaryScreen.Bounds.Size;
        private const string combination = "1423";
        private string now = "";
        public static bool secretMode = false;

        public MainForm()
        {
            InitializeComponent();
            people = database.readData();
            foreach (Person person in people)
                guideAdd(person);
        }

        private void guideAdd(Person person) {
            int years = person.calcAge(DateTime.Now);
            string yearsName;
            if ((years % 10 >= 5 && years % 10 <= 9) || years % 10 == 0 || (years >= 11 && years <= 14)) yearsName = "лет";
            else if (years % 10 >= 2 && years % 10 <= 4) yearsName = "года";
            else yearsName = "год";
            Guide.Items.Add(person.Name + " - " + years+ " " + yearsName);
        }

        private void create_Click(object sender, EventArgs e) {
            CreateAndChangeForm form = new CreateAndChangeForm(1, null);
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK) {
                people.Add(form.person);
                guideAdd(form.person);
            }
        }

        private void change_Click(object sender, EventArgs e) {
            if (Guide.SelectedIndex == -1) return;
            CreateAndChangeForm form = new CreateAndChangeForm(2, people[Guide.SelectedIndex]);
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK) {
                people.RemoveAt(Guide.SelectedIndex);
                Guide.Items.RemoveAt(Guide.SelectedIndex);
                people.Add(form.person);
                guideAdd(form.person);
            }
        }

        private void remove_Click(object sender, EventArgs e) {
            if (Guide.SelectedIndex == -1) return;
            DialogResult dialogResult = MessageBox.Show(
                "Уверены, что хотите удалить?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes) {
                people.RemoveAt(Guide.SelectedIndex);
                Guide.Items.RemoveAt(Guide.SelectedIndex);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            database.writeData(people);
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e) {
            if (secretMode == false) {
                Control control = sender as Control;
                Point point = control.PointToScreen(this.Location);
                if (point.X < sizeScreen.Width / 2 && point.Y < sizeScreen.Height / 2) now += "1";
                if (point.X > sizeScreen.Width / 2 && point.Y < sizeScreen.Height / 2) now += "2";
                if (point.X < sizeScreen.Width / 2 && point.Y > sizeScreen.Height / 2) now += "3";
                if (point.X > sizeScreen.Width / 2 && point.Y > sizeScreen.Height / 2) now += "4";
                for (int i = 0; i < now.Length; i++) {
                    if (now[i] != combination[i]) {
                        now = "";
                        return;
                    }
                }
                if (combination == now) {
                    nowGuide = "";
                    secretMode = true;
                }
            }
        }

        private const string combinationGuide = "20";
        private string nowGuide = "";

        private void Guide_SelectedIndexChanged(object sender, EventArgs e) {
            if (secretMode == true) {
                nowGuide += Guide.SelectedIndex;
                for (int i = 0; i < nowGuide.Length; i++) {
                    if (nowGuide[i] != combinationGuide[i]) {
                        nowGuide = "";
                        return;
                    }
                }
                if (combinationGuide == nowGuide) {
                    now = "";
                    secretMode = false;
                }
            }
        }
    }
}
