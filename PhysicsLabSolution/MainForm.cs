using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsLabSolution
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void buttonLoadSpectrum_Click(object sender, EventArgs e)
		{
			var lastOpenDirectory = Properties.Settings.Default.LastOpenDirectory;
			lastOpenDirectory = String.IsNullOrEmpty(lastOpenDirectory) && !Directory.Exists(lastOpenDirectory)
				? Directory.GetCurrentDirectory()
				: lastOpenDirectory;

			using (var openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = lastOpenDirectory;
				openFileDialog.Filter = @"Excel 2003 files (*.xls)|*.xls|Excel 2007 files (*.xlsx)|*.xlsx|Excel files (*.xls,*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 3;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					textBoxLoadSpectrum.Text = openFileDialog.FileName;

					var fileInfo = new FileInfo(openFileDialog.FileName);
					Properties.Settings.Default.LastOpenDirectory = fileInfo.DirectoryName;
					Properties.Settings.Default.Save();
				}
			}
		}
	}
}
