namespace Lab1CS
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
            this.Guide = new System.Windows.Forms.ListBox();
            this.create = new System.Windows.Forms.Button();
            this.change = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Guide
            // 
            this.Guide.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Guide.FormattingEnabled = true;
            this.Guide.ItemHeight = 16;
            this.Guide.Location = new System.Drawing.Point(31, 26);
            this.Guide.Name = "Guide";
            this.Guide.Size = new System.Drawing.Size(310, 244);
            this.Guide.TabIndex = 0;
            this.Guide.SelectedIndexChanged += new System.EventHandler(this.Guide_SelectedIndexChanged);
            // 
            // create
            // 
            this.create.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.create.Location = new System.Drawing.Point(91, 292);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(188, 38);
            this.create.TabIndex = 1;
            this.create.Text = "Создать новую запись";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // change
            // 
            this.change.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.change.Location = new System.Drawing.Point(91, 338);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(188, 38);
            this.change.TabIndex = 2;
            this.change.Text = "Изменить выбранную";
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.change_Click);
            // 
            // remove
            // 
            this.remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.remove.Location = new System.Drawing.Point(91, 384);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(188, 38);
            this.remove.TabIndex = 3;
            this.remove.Text = "Удалить выбранную";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 450);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.change);
            this.Controls.Add(this.create);
            this.Controls.Add(this.Guide);
            this.Name = "MainForm";
            this.Text = "Главное меню";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Guide;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.Button remove;
    }
}

