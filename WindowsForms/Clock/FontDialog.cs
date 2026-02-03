using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;    //Input/Output
using System.Runtime.InteropServices;

namespace Clock
{
	public partial class FontDialog : Form
	{
		MainForm parent;
		public FontDialog(MainForm parent)
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;
			this.parent = parent;
		}
		void LoadFonts()
		{
			AllocConsole();
			Console.WriteLine(Application.ExecutablePath);
			//Directory.SetCurrentDirectory($"{Application.ExecutablePath}");
			Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..\\Fonts");
			//Console.WriteLine($"{Directory.GetParent(Application.StartupPath)?.Parent?.FullName}\\Fonts");
			Console.WriteLine(Directory.GetCurrentDirectory());
			//LoadFonts(Directory.GetCurrentDirectory(), "*.otf");
			//LoadFonts(Directory.GetCurrentDirectory(), "*.ttf");
			Traverse(Directory.GetCurrentDirectory());
		}
		void LoadFonts(string path, string extension)
		{
			string[] files = Directory.GetFiles(path, extension);
			for (int i = 0; i < files.Length; i++)
			{
				//Console.WriteLine(files[i]);
				files[i] = files[i].Split('\\').Last();
			}
			comboBoxFonts.Items.AddRange(files);
		}
		void Traverse(string path)
		{
			LoadFonts(path, "*.ttf");
			LoadFonts(path, "*.otf");
			string[] directories = Directory.GetDirectories(path);
			if (directories.Length == 0) return;
			for (int i = 0; i < directories.Length; i++)
			{
				Traverse(directories[i]);
			}
		}
		[DllImport("kernel32.dll")]
		public static extern void AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern void FreeConsole();

		private void FontDialog_Load(object sender, EventArgs e)
		{
			this.Location = new Point
				(
					this.parent.Location.X - this.Width/4,
					this.parent.Location.Y + 100
				);
			LoadFonts();
		}
	}
}
