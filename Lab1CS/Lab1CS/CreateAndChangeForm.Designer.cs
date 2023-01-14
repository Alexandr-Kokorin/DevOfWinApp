namespace Lab1CS
{
    partial class CreateAndChangeForm
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
            this.nameText = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cardNumberText = new System.Windows.Forms.TextBox();
            this.accept = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(28, 28);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(200, 20);
            this.nameText.TabIndex = 0;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(28, 73);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 1;
            // 
            // cardNumberText
            // 
            this.cardNumberText.Location = new System.Drawing.Point(28, 119);
            this.cardNumberText.MaxLength = 5;
            this.cardNumberText.Name = "cardNumberText";
            this.cardNumberText.Size = new System.Drawing.Size(200, 20);
            this.cardNumberText.TabIndex = 2;
            this.cardNumberText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cardNumberText_KeyPress);
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(28, 175);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(86, 33);
            this.accept.TabIndex = 3;
            this.accept.Text = "Принять";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(142, 175);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(86, 33);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Отменить";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cancel_MouseMove);
            // 
            // CreateAndChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(260, 231);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.cardNumberText);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.nameText);
            this.Name = "CreateAndChangeForm";
            this.Text = "CreateAndChangeForm";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CreateAndChangeForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox nameText;
        public System.Windows.Forms.DateTimePicker dateTimePicker;
        public System.Windows.Forms.TextBox cardNumberText;
        public System.Windows.Forms.Button accept;
        public System.Windows.Forms.Button cancel;
    }
}