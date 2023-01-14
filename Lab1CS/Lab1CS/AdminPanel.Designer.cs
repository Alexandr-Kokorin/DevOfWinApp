namespace Lab1CS
{
    partial class AdminPanel
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
            this.status = new System.Windows.Forms.ComboBox();
            this.passText = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.FormattingEnabled = true;
            this.status.Items.AddRange(new object[] {
            "user",
            "admin"});
            this.status.Location = new System.Drawing.Point(32, 35);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(171, 21);
            this.status.TabIndex = 0;
            this.status.SelectedIndexChanged += new System.EventHandler(this.status_SelectedIndexChanged);
            // 
            // passText
            // 
            this.passText.Enabled = false;
            this.passText.Location = new System.Drawing.Point(32, 80);
            this.passText.Name = "passText";
            this.passText.PasswordChar = '*';
            this.passText.Size = new System.Drawing.Size(171, 20);
            this.passText.TabIndex = 1;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(32, 128);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(76, 31);
            this.ok.TabIndex = 2;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(128, 128);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 31);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 177);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.status);
            this.Name = "AdminPanel";
            this.Text = "Панель администратора";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}