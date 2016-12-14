namespace naturalSort
{
    partial class mainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.openFileButton = new System.Windows.Forms.Button();
			this.sortButton = new System.Windows.Forms.Button();
			this.buttonRand = new System.Windows.Forms.Button();
			this.textBoxRand = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// openFileButton
			// 
			this.openFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.openFileButton.Location = new System.Drawing.Point(83, 12);
			this.openFileButton.Name = "openFileButton";
			this.openFileButton.Size = new System.Drawing.Size(181, 89);
			this.openFileButton.TabIndex = 0;
			this.openFileButton.Text = "Выбрать файл";
			this.openFileButton.UseVisualStyleBackColor = true;
			this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
			// 
			// sortButton
			// 
			this.sortButton.Enabled = false;
			this.sortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.sortButton.Location = new System.Drawing.Point(83, 224);
			this.sortButton.Name = "sortButton";
			this.sortButton.Size = new System.Drawing.Size(181, 88);
			this.sortButton.TabIndex = 1;
			this.sortButton.Text = "Сортировать";
			this.sortButton.UseVisualStyleBackColor = true;
			this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
			// 
			// buttonRand
			// 
			this.buttonRand.Location = new System.Drawing.Point(199, 159);
			this.buttonRand.Name = "buttonRand";
			this.buttonRand.Size = new System.Drawing.Size(75, 23);
			this.buttonRand.TabIndex = 2;
			this.buttonRand.Text = "Случайно";
			this.buttonRand.UseVisualStyleBackColor = true;
			this.buttonRand.Click += new System.EventHandler(this.buttonRand_Click);
			// 
			// textBoxRand
			// 
			this.textBoxRand.Location = new System.Drawing.Point(68, 161);
			this.textBoxRand.Name = "textBoxRand";
			this.textBoxRand.Size = new System.Drawing.Size(100, 20);
			this.textBoxRand.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(65, 145);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Количество элементов";
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(350, 324);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxRand);
			this.Controls.Add(this.buttonRand);
			this.Controls.Add(this.sortButton);
			this.Controls.Add(this.openFileButton);
			this.Name = "mainForm";
			this.Text = "Естественная сортировка";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button sortButton;
		private System.Windows.Forms.Button buttonRand;
		private System.Windows.Forms.TextBox textBoxRand;
		private System.Windows.Forms.Label label1;
    }
}

