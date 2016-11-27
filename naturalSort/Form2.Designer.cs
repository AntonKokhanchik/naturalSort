namespace naturalSort
{
	partial class Form2
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
			this.button1 = new System.Windows.Forms.Button();
			this.OKLabel = new System.Windows.Forms.Label();
			this.errorLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(166, 29);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "ОК";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// OKLabel
			// 
			this.OKLabel.AutoSize = true;
			this.OKLabel.Location = new System.Drawing.Point(108, 9);
			this.OKLabel.Name = "OKLabel";
			this.OKLabel.Size = new System.Drawing.Size(172, 13);
			this.OKLabel.TabIndex = 1;
			this.OKLabel.Text = "Сортировка завершена успешно";
			// 
			// errorLabel
			// 
			this.errorLabel.AutoSize = true;
			this.errorLabel.Location = new System.Drawing.Point(6, 9);
			this.errorLabel.Name = "errorLabel";
			this.errorLabel.Size = new System.Drawing.Size(404, 13);
			this.errorLabel.TabIndex = 1;
			this.errorLabel.Text = "Возникла ошибка, возможно указанный файл имеет неправильную структуру";
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(422, 64);
			this.Controls.Add(this.errorLabel);
			this.Controls.Add(this.OKLabel);
			this.Controls.Add(this.button1);
			this.Name = "Form2";
			this.Text = "Сортировка завершена";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label OKLabel;
		private System.Windows.Forms.Label errorLabel;
	}
}