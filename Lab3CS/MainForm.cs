using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab3CS
{
    public partial class MainForm : Form
    {

        public static Dictionary<string, AdditionalTable> additionalTables = new Dictionary<string, AdditionalTable>();

        public MainForm() {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e) {
            DataTable dataTable = getDataTable();
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            dataSet.WriteXml("save.xml");
        }

        private DataTable getDataTable() {
            DataTable dataTable = new DataTable();
            foreach (DataGridViewColumn column in dataGridView.Columns) {
                if (column.Visible) dataTable.Columns.Add(column.DataPropertyName);
            }
            object[] cellValues = new object[dataGridView.Columns.Count];
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++) {
                for (int j = 0; j < dataGridView.Rows[i].Cells.Count; j++) {
                    cellValues[j] = dataGridView.Rows[i].Cells[j].Value;
                }
                dataTable.Rows.Add(cellValues);
            }
            return dataTable;
        }

        private void load_Click(object sender, EventArgs e) {
            if (!File.Exists("save.xml")) return;
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("save.xml");
            bindingSource.DataSource = dataSet.Tables[0];
        }

        private void exit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
            foreach (DataGridViewRow row in dataGridView.Rows) {
                if (row.Cells[4].Value != null) {
                    if (row.Cells[4].Value.ToString() == "Легковой")
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (row.Cells[4].Value.ToString() == "Грузовой")
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0 &&
                dataGridView.Rows[e.RowIndex].Cells[0].Value != null &&
                dataGridView.Rows[e.RowIndex].Cells[1].Value != null &&
                dataGridView.Rows[e.RowIndex].Cells[2].Value != null &&
                dataGridView.Rows[e.RowIndex].Cells[3].Value != null &&
                dataGridView.Rows[e.RowIndex].Cells[4].Value != null &&
                dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString() != "" &&
                dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString() != "" &&
                dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString() != "" &&
                dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString() != "" &&
                dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString() != "") {
                ICarBrand carBrand;
                if (dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString() == "Легковой") {
                    carBrand = new PassengerCar(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString(),
                                     dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString(),
                                     dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString(),
                                     dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
                } else {
                    carBrand = new Truck(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString(),
                              dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString(),
                              dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString(),
                              dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
                if (!additionalTables.ContainsKey(ICarBrandToKey(carBrand))) {
                    AdditionalTable additionalTable = new AdditionalTable(carBrand);
                    additionalTables.Add(ICarBrandToKey(carBrand), additionalTable);
                    additionalTable.Show();
                } else {
                    additionalTables[(ICarBrandToKey(carBrand))].Focus();
                }
            }
        }

        private string ICarBrandToKey(ICarBrand carBrand) {
            return carBrand.Brand + "." + carBrand.Model + "." + (carBrand is PassengerCar).ToString();
        }
    }
}
