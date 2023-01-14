namespace Lab2CS
{
    partial class BackgroundSettings
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
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.colorSelect = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.hatchingSelect = new System.Windows.Forms.ComboBox();
            this.enterCharacters = new System.Windows.Forms.TextBox();
            this.imageSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "цвет",
            "штриховка",
            "символы",
            "изображение"});
            this.checkedListBox.Location = new System.Drawing.Point(21, 20);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(146, 72);
            this.checkedListBox.TabIndex = 0;
            this.checkedListBox.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_SelectedIndexChanged);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(12, 167);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 1;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(103, 167);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // colorSelect
            // 
            this.colorSelect.Location = new System.Drawing.Point(21, 107);
            this.colorSelect.Name = "colorSelect";
            this.colorSelect.Size = new System.Drawing.Size(146, 29);
            this.colorSelect.TabIndex = 3;
            this.colorSelect.Text = "Выбрать цвет";
            this.colorSelect.UseVisualStyleBackColor = true;
            this.colorSelect.Visible = false;
            this.colorSelect.Click += new System.EventHandler(this.colorSelect_Click);
            // 
            // hatchingSelect
            // 
            this.hatchingSelect.FormattingEnabled = true;
            this.hatchingSelect.Items.AddRange(new object[] {
            "горизонтальная",
            "вертикальная",
            "наклонная-1",
            "наклонная-2",
            "перекрестная"});
            this.hatchingSelect.Location = new System.Drawing.Point(21, 107);
            this.hatchingSelect.Name = "hatchingSelect";
            this.hatchingSelect.Size = new System.Drawing.Size(146, 21);
            this.hatchingSelect.TabIndex = 4;
            this.hatchingSelect.Visible = false;
            // 
            // enterCharacters
            // 
            this.enterCharacters.Location = new System.Drawing.Point(21, 108);
            this.enterCharacters.Name = "enterCharacters";
            this.enterCharacters.Size = new System.Drawing.Size(146, 20);
            this.enterCharacters.TabIndex = 5;
            this.enterCharacters.Visible = false;
            // 
            // imageSelect
            // 
            this.imageSelect.AutoCompleteCustomSource.AddRange(new string[] {
            "котики",
            "собачки"});
            this.imageSelect.FormattingEnabled = true;
            this.imageSelect.Items.AddRange(new object[] {
            "котики",
            "собачки"});
            this.imageSelect.Location = new System.Drawing.Point(21, 107);
            this.imageSelect.Name = "imageSelect";
            this.imageSelect.Size = new System.Drawing.Size(146, 21);
            this.imageSelect.TabIndex = 6;
            this.imageSelect.Visible = false;
            // 
            // BackgroundSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 202);
            this.Controls.Add(this.imageSelect);
            this.Controls.Add(this.enterCharacters);
            this.Controls.Add(this.hatchingSelect);
            this.Controls.Add(this.colorSelect);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.checkedListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BackgroundSettings";
            this.Text = "Настройки фона";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button colorSelect;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox hatchingSelect;
        private System.Windows.Forms.TextBox enterCharacters;
        private System.Windows.Forms.ComboBox imageSelect;
    }
}