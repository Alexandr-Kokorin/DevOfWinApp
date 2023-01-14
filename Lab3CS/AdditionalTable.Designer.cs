namespace Lab3CS
{
    partial class AdditionalTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.registrationNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сolumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сolumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.registrationNumber,
            this.сolumn2,
            this.сolumn3});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(444, 450);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.Visible = false;
            // 
            // registrationNumber
            // 
            this.registrationNumber.HeaderText = "Регистрационный номер";
            this.registrationNumber.Name = "registrationNumber";
            this.registrationNumber.ReadOnly = true;
            this.registrationNumber.Width = 150;
            // 
            // сolumn2
            // 
            this.сolumn2.HeaderText = "Название мультимедиа";
            this.сolumn2.Name = "сolumn2";
            this.сolumn2.ReadOnly = true;
            this.сolumn2.Width = 150;
            // 
            // сolumn3
            // 
            this.сolumn3.HeaderText = "Количество подушек безопасности";
            this.сolumn3.Name = "сolumn3";
            this.сolumn3.ReadOnly = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(92, 118);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(260, 40);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 1;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(144, 80);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(155, 16);
            this.label.TabIndex = 2;
            this.label.Text = "Загрузка базы данных";
            // 
            // AdditionalTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 450);
            this.Controls.Add(this.label);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.dataGridView);
            this.Name = "AdditionalTable";
            this.Text = "AdditionalTable";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdditionalTable_FormClosing);
            this.Load += new System.EventHandler(this.AdditionalTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn registrationNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn сolumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn сolumn3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label;
    }
}