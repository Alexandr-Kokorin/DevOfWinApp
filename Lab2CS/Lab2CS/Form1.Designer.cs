namespace Lab2CS
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.backgroundSelection = new System.Windows.Forms.Button();
            this.colorSelection = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.randomFunction = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.backgroundSelection);
            this.groupBox.Controls.Add(this.colorSelection);
            this.groupBox.Controls.Add(this.save);
            this.groupBox.Controls.Add(this.randomFunction);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox.Location = new System.Drawing.Point(600, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox.Size = new System.Drawing.Size(200, 450);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Элементы управления";
            // 
            // backgroundSelection
            // 
            this.backgroundSelection.Location = new System.Drawing.Point(10, 158);
            this.backgroundSelection.Name = "backgroundSelection";
            this.backgroundSelection.Size = new System.Drawing.Size(180, 36);
            this.backgroundSelection.TabIndex = 3;
            this.backgroundSelection.Text = "Выбрать фон";
            this.backgroundSelection.UseVisualStyleBackColor = true;
            this.backgroundSelection.Click += new System.EventHandler(this.backgroundSelection_Click);
            // 
            // colorSelection
            // 
            this.colorSelection.Location = new System.Drawing.Point(10, 114);
            this.colorSelection.Name = "colorSelection";
            this.colorSelection.Size = new System.Drawing.Size(180, 36);
            this.colorSelection.TabIndex = 2;
            this.colorSelection.Text = "Выбрать цвет";
            this.colorSelection.UseVisualStyleBackColor = true;
            this.colorSelection.Click += new System.EventHandler(this.colorSelection_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(10, 70);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(180, 36);
            this.save.TabIndex = 1;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // randomFunction
            // 
            this.randomFunction.Location = new System.Drawing.Point(10, 26);
            this.randomFunction.Name = "randomFunction";
            this.randomFunction.Size = new System.Drawing.Size(180, 36);
            this.randomFunction.TabIndex = 0;
            this.randomFunction.Text = "Случайная функция";
            this.randomFunction.UseVisualStyleBackColor = true;
            this.randomFunction.Click += new System.EventHandler(this.randomFunction_Click);
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(600, 450);
            this.panel.TabIndex = 1;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.groupBox);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Главная форма";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button backgroundSelection;
        private System.Windows.Forms.Button colorSelection;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button randomFunction;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

