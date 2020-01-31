namespace PhysicsLabSolution
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.groupBoxLoadSpectrum = new System.Windows.Forms.GroupBox();
			this.buttonLoadSpectrum = new System.Windows.Forms.Button();
			this.textBoxLoadSpectrum = new System.Windows.Forms.TextBox();
			this.groupBoxLoadSpectrum.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxLoadSpectrum
			// 
			this.groupBoxLoadSpectrum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxLoadSpectrum.Controls.Add(this.textBoxLoadSpectrum);
			this.groupBoxLoadSpectrum.Controls.Add(this.buttonLoadSpectrum);
			this.groupBoxLoadSpectrum.Location = new System.Drawing.Point(12, 12);
			this.groupBoxLoadSpectrum.Name = "groupBoxLoadSpectrum";
			this.groupBoxLoadSpectrum.Size = new System.Drawing.Size(428, 68);
			this.groupBoxLoadSpectrum.TabIndex = 0;
			this.groupBoxLoadSpectrum.TabStop = false;
			this.groupBoxLoadSpectrum.Text = "Загрузить спектр";
			// 
			// buttonLoadSpectrum
			// 
			this.buttonLoadSpectrum.Location = new System.Drawing.Point(6, 29);
			this.buttonLoadSpectrum.Name = "buttonLoadSpectrum";
			this.buttonLoadSpectrum.Size = new System.Drawing.Size(75, 23);
			this.buttonLoadSpectrum.TabIndex = 0;
			this.buttonLoadSpectrum.Text = "Открыть";
			this.buttonLoadSpectrum.UseVisualStyleBackColor = true;
			this.buttonLoadSpectrum.Click += new System.EventHandler(this.buttonLoadSpectrum_Click);
			// 
			// textBoxLoadSpectrum
			// 
			this.textBoxLoadSpectrum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLoadSpectrum.Location = new System.Drawing.Point(87, 31);
			this.textBoxLoadSpectrum.Name = "textBoxLoadSpectrum";
			this.textBoxLoadSpectrum.ReadOnly = true;
			this.textBoxLoadSpectrum.Size = new System.Drawing.Size(332, 20);
			this.textBoxLoadSpectrum.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.groupBoxLoadSpectrum);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Решение ренгеновских спектральных характеристик магнитных материалов";
			this.groupBoxLoadSpectrum.ResumeLayout(false);
			this.groupBoxLoadSpectrum.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxLoadSpectrum;
		private System.Windows.Forms.Button buttonLoadSpectrum;
		private System.Windows.Forms.TextBox textBoxLoadSpectrum;
	}
}

