namespace Lab4CS
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl11 = new Lab4CS.UserControl1();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl12 = new Lab4CS.UserControl1();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl13 = new Lab4CS.UserControl1();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.elementHost4 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl14 = new Lab4CS.UserControl1();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.elementHost1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Вкладка 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(3, 3);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(786, 418);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.userControl11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.elementHost2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Вкладка 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // elementHost2
            // 
            this.elementHost2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost2.Location = new System.Drawing.Point(3, 3);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(786, 418);
            this.elementHost2.TabIndex = 0;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.userControl12;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.elementHost3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Вкладка 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // elementHost3
            // 
            this.elementHost3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost3.Location = new System.Drawing.Point(0, 0);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(792, 424);
            this.elementHost3.TabIndex = 0;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = this.userControl13;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.elementHost4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(792, 424);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // elementHost4
            // 
            this.elementHost4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost4.Location = new System.Drawing.Point(0, 0);
            this.elementHost4.Name = "elementHost4";
            this.elementHost4.Size = new System.Drawing.Size(792, 424);
            this.elementHost4.TabIndex = 0;
            this.elementHost4.Text = "elementHost4";
            this.elementHost4.Child = this.userControl14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Главная форма";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private UserControl1 userControl11;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private UserControl1 userControl12;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private UserControl1 userControl13;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Integration.ElementHost elementHost4;
        private UserControl1 userControl14;
    }
}

