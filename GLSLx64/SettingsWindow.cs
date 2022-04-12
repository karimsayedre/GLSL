using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GLSLx64
{
	public partial class SettingsWindow : Form
	{
		public SettingsWindow()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() != DialogResult.OK) 
				return;

			textBox1.Text = openFileDialog1.FileName;
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			if (openFileDialog1 != null && textBox1 != null)
				textBox1.Text = openFileDialog1.FileName;
		}

	}
}
