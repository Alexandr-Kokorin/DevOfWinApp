using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3CS
{
    public partial class AdditionalTable : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private ICarBrand carBrand;
        private Loader loader;

        public AdditionalTable(ICarBrand carBrand) {
            InitializeComponent();
            if (carBrand is PassengerCar) {
                сolumn2.HeaderText = "Название мультимедиа";
                сolumn3.HeaderText = "Количество подушек безопасности";
            } else {
                сolumn2.HeaderText = "Количество колес";
                сolumn3.HeaderText = "Объем кузова";
            }
            this.carBrand = carBrand;
            progressBar.Visible = true;
            label.Visible = true;
            dataGridView.Visible = false;
            loader = new Loader(carBrand);
        }

        private void AdditionalTable_Load(object sender, EventArgs e) {
            Thread thread = new Thread(new ThreadStart(loader.load));
            thread.Start();
            progressBar.Maximum = loader.numberOfEntries;
            progressBar.Value = 0;
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 100;
            timer.Start();
        }

        private void TimerEventProcessor(object sender, EventArgs e) {
            int progress = loader.getProgress();
            if (progress != -1 && progress != progressBar.Value) progressBar.Value = progress;
            else if (progress == -1) {
                loadTable();
                progressBar.Visible = false;
                label.Visible = false;
                dataGridView.Visible = true;
                timer.Tick -= new EventHandler(TimerEventProcessor);
                timer.Stop();
            }
        }

        private void loadTable () {
            foreach (ICarBrand carBrand in loader.get()) {
                string[] row = new string[3];
                if (carBrand is PassengerCar) {
                    PassengerCar passengerCar = (PassengerCar)carBrand;
                    row[0] = passengerCar.RegistrationNumber;
                    row[1] = passengerCar.MediaName;
                    row[2] = passengerCar.NumberOfAirbags;
                } else {
                    Truck truck = (Truck)carBrand;
                    row[0] = truck.RegistrationNumber;
                    row[1] = truck.NumberOfWheels;
                    row[2] = truck.BodyVolume;
                }
                dataGridView.Rows.Add(row);
            }
        }

        private void AdditionalTable_FormClosing(object sender, FormClosingEventArgs e) {
            MainForm.additionalTables.Remove(ICarBrandToKey(carBrand));
        }

        private string ICarBrandToKey(ICarBrand carBrand) {
            return carBrand.Brand + "." + carBrand.Model + "." + (carBrand is PassengerCar).ToString();
        }
    }
}
