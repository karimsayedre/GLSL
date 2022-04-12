using System;
using System.Windows.Forms;

namespace GLSLx64
{
	partial class SettingsWindow
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.General = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBoxPrintLog = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBoxLiveCompile = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.extensionsGridStyle = new System.Windows.Forms.DataGridTableStyle();
			this.extsCol = new System.Windows.Forms.DataGridTextBoxColumn();
			this.extensionsGrid = new System.Windows.Forms.DataGrid();
			this.flowLayoutPanel1.SuspendLayout();
			this.General.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.extensionsGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.General);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(75, 25);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(677, 413);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// General
			// 
			this.General.AccessibleDescription = "asdfasdfasdf";
			this.General.AccessibleName = "asdf";
			this.General.Controls.Add(this.tabPage1);
			this.General.Controls.Add(this.tabPage2);
			this.General.Controls.Add(this.tabPage4);
			this.General.Location = new System.Drawing.Point(3, 3);
			this.General.Name = "General";
			this.General.SelectedIndex = 0;
			this.General.Size = new System.Drawing.Size(674, 379);
			this.General.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.numericUpDown1);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.textBox4);
			this.tabPage1.Controls.Add(this.textBox3);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.checkBoxPrintLog);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.checkBoxLiveCompile);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(666, 353);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(142, 68);
			this.numericUpDown1.Maximum = new decimal(new int[] {
			10000,
			0,
			0,
			0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
			this.numericUpDown1.TabIndex = 14;
			this.numericUpDown1.ThousandsSeparator = true;
			this.numericUpDown1.Value = new decimal(new int[] {
			200,
			0,
			0,
			0});
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 75);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Compile delay (ms)";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(142, 162);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(354, 20);
			this.textBox4.TabIndex = 12;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(142, 136);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(354, 20);
			this.textBox3.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 169);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "User key words 2";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 139);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "User key words 1";
			// 
			// checkBoxPrintLog
			// 
			this.checkBoxPrintLog.AutoSize = true;
			this.checkBoxPrintLog.Location = new System.Drawing.Point(142, 117);
			this.checkBoxPrintLog.Name = "checkBoxPrintLog";
			this.checkBoxPrintLog.Size = new System.Drawing.Size(15, 14);
			this.checkBoxPrintLog.TabIndex = 8;
			this.checkBoxPrintLog.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 117);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Pring shader log";
			// 
			// checkBoxLiveCompile
			// 
			this.checkBoxLiveCompile.AutoSize = true;
			this.checkBoxLiveCompile.Location = new System.Drawing.Point(142, 94);
			this.checkBoxLiveCompile.Name = "checkBoxLiveCompile";
			this.checkBoxLiveCompile.Size = new System.Drawing.Size(15, 14);
			this.checkBoxLiveCompile.TabIndex = 6;
			this.checkBoxLiveCompile.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 95);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Live Compilation";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(142, 38);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(354, 20);
			this.textBox2.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Compiler arguments";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(502, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(45, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(142, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(354, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Compiler Executable";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.vScrollBar1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(666, 353);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Extensions";
			this.tabPage2.UseVisualStyleBackColor = true;

			// 
			// extensionsGridStyle
			// 
			this.extensionsGridStyle.DataGrid = null;
			this.extensionsGridStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
				this.extsCol});
			this.extensionsGridStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.extensionsGridStyle.MappingName = "Extensions";
			// 
			// extsCol
			// 
			this.extsCol.HeaderText = "asdfasdf";
			this.extsCol.Width = 75;
			// 
			// extensionsGrid
			// 
			this.extensionsGrid.DataMember = "";
			this.extensionsGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.extensionsGrid.Location = new System.Drawing.Point(0, 0);
			this.extensionsGrid.Name = "extensionsGrid";
			this.extensionsGrid.Size = new System.Drawing.Size(130, 80);
			this.extensionsGrid.TabIndex = 0;


			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Location = new System.Drawing.Point(649, 0);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(17, 353);
			this.vScrollBar1.TabIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(666, 353);
			this.tabPage4.TabIndex = 2;
			this.tabPage4.Text = "Stages";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "exe";
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Compiler Executable (*.exe)|*.exe";
			this.openFileDialog1.Title = "Find Compiler";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);




			// 
			// SettingsWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 460);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "SettingsWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Settings Window";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.General.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.extensionsGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.TabControl General;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkBoxPrintLog;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBoxLiveCompile;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.VScrollBar vScrollBar1;
		private System.Windows.Forms.DataGridTableStyle extensionsGridStyle;
		private System.Windows.Forms.DataGrid extensionsGrid;
		private DataGridTextBoxColumn extsCol;
	}
}