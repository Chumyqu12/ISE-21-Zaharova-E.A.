namespace _222lllll
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(184, 26);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(148, 201);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Location = new System.Drawing.Point(394, 26);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(139, 201);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// label4
			// 
			this.label4.AllowDrop = true;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(31, 166);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "DopColor";
			this.label4.DragDrop += new System.Windows.Forms.DragEventHandler(this.DopDrop);
			this.label4.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainEnter);
			// 
			// label3
			// 
			this.label3.AllowDrop = true;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(31, 134);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "MainColor";
			this.label3.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainDrop);
			this.label3.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainEnter);
			// 
			// panel1
			// 
			this.panel1.AllowDrop = true;
			this.panel1.Location = new System.Drawing.Point(18, 26);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(102, 90);
			this.panel1.TabIndex = 2;
			this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelDrop);
			this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelEnter);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 119);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "лодочка";
			this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelLodka_down);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(45, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "катер";
			this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelCutterdown);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel9);
			this.groupBox2.Controls.Add(this.panel8);
			this.groupBox2.Controls.Add(this.panel7);
			this.groupBox2.Controls.Add(this.panel6);
			this.groupBox2.Controls.Add(this.panel5);
			this.groupBox2.Controls.Add(this.panel4);
			this.groupBox2.Controls.Add(this.panel3);
			this.groupBox2.Controls.Add(this.panel2);
			this.groupBox2.Location = new System.Drawing.Point(184, 293);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(168, 97);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Color";
			// 
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.panel9.Location = new System.Drawing.Point(131, 57);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(16, 19);
			this.panel9.TabIndex = 7;
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.panel8.Location = new System.Drawing.Point(94, 57);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(19, 20);
			this.panel8.TabIndex = 6;
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.Aqua;
			this.panel7.Location = new System.Drawing.Point(58, 58);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(19, 19);
			this.panel7.TabIndex = 5;
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.Fuchsia;
			this.panel6.Location = new System.Drawing.Point(22, 58);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(19, 19);
			this.panel6.TabIndex = 4;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.panel5.Location = new System.Drawing.Point(131, 25);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(17, 18);
			this.panel5.TabIndex = 3;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.panel4.Location = new System.Drawing.Point(95, 25);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(18, 18);
			this.panel4.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.panel3.Location = new System.Drawing.Point(57, 25);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(20, 19);
			this.panel3.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.panel2.Location = new System.Drawing.Point(22, 25);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(19, 19);
			this.panel2.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(53, 256);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(67, 20);
			this.button1.TabIndex = 4;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(56, 296);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(63, 22);
			this.button2.TabIndex = 5;
			this.button2.Text = "  Cancel       ";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(589, 424);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "Form2";
			this.Text = "Form2";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}