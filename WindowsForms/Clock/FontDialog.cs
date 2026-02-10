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
using System.Drawing.Text;

namespace Clock
{
	public partial class FontDialog : Form
	{
		PrivateFontCollection pfc;
		MainForm parent;
		Dictionary<string, string> fonts;
		float fontSize;
		public Font Font { get; private set; }
		public string FontFile { get; set; }
		public float FontSize
		{
			get => fontSize;
			set => numericUpDownFontSize.Value = (decimal)(fontSize = 
				value < (float)numericUpDownFontSize.Minimum ? (float)numericUpDownFontSize.Minimum :
				value > (float)numericUpDownFontSize.Maximum ? (float)numericUpDownFontSize.Maximum :
				value);
		}
		public FontDialog(MainForm parent, string fontFile)
		{
			InitializeComponent();
			pfc = null;
			fonts = new Dictionary<string, string>();
			this.FontFile = fontFile;
			this.StartPosition = FormStartPosition.Manual;
			this.parent = parent;
			LoadFonts();
		}
		void LoadFonts()
		{
			//AllocConsole();
			//Console.WriteLine(Application.ExecutablePath);
			//Directory.SetCurrentDirectory($"{Application.ExecutablePath}");
			Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..\\Fonts");
			//Console.WriteLine($"{Directory.GetParent(Application.StartupPath)?.Parent?.FullName}\\Fonts");
			//Console.WriteLine(Directory.GetCurrentDirectory());
			//LoadFonts(Directory.GetCurrentDirectory(), "*.otf");
			//LoadFonts(Directory.GetCurrentDirectory(), "*.ttf");
			Traverse(Directory.GetCurrentDirectory());
			comboBoxFonts.Items.AddRange(fonts.Keys.ToArray());
			//comboBoxFonts.SelectedIndex = 0;
			comboBoxFonts.SelectedItem = this.FontFile.Split('\\').Last();
		}
		void LoadFonts(string path, string extension)
		{
			string[] files = Directory.GetFiles(path, extension);
			for (int i = 0; i < files.Length; i++)
			{
				//Console.WriteLine(files[i]);
				//files[i] = files[i].Split('\\').Last();
				fonts.Add(files[i].Split('\\').Last()/*.Split('.').First()*/, files[i]);
			}
			//comboBoxFonts.Items.AddRange(files);
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
			//LoadFonts();
			//ApplyFontExample(FontFile);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			this.Font = labelExample.Font;
			this.FontFile = fonts[comboBoxFonts.SelectedItem.ToString()];
			this.FontSize = (float)numericUpDownFontSize.Value;
		}
		public Font ApplyFontExample(string filename)
		{
			if (pfc != null) pfc.Dispose();
			pfc = new PrivateFontCollection();
			pfc.AddFontFile(filename);
			return labelExample.Font = new Font(pfc.Families[0], (float)numericUpDownFontSize.Value);
		}
		private void comboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
		{
			ApplyFontExample(fonts[comboBoxFonts.SelectedItem.ToString()]);
		}

		private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
		{
			ApplyFontExample(fonts[comboBoxFonts.SelectedItem.ToString()]);
		}
	}
}
