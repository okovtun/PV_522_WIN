using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace Clock
{
	public partial class MainForm : Form
	{
		ColorDialog backgroundDialog;
		ColorDialog foregroundDialog;
		FontDialog fontDialog;
		public MainForm()
		{
			InitializeComponent();
			this.Location = new Point
				(
					Screen.PrimaryScreen.Bounds.Width - this.Width - 50,
					50
				);
			tsmiShowControls.Checked = true;
			backgroundDialog = new ColorDialog();
			foregroundDialog = new ColorDialog();
			//fontDialog = new FontDialog(this);
			LoadSettings();
		}
		void SaveSettings()
		{
			Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
			string filename = "Settings.ini";
			StreamWriter writer = new StreamWriter(filename);
			writer.WriteLine($"{this.Location.X}x{this.Location.Y}");
			writer.WriteLine(tsmiTopmost.Checked);
			writer.WriteLine(tsmiShowControls.Checked);
			writer.WriteLine(tsmiShowDate.Checked);
			writer.WriteLine(tsmiShowWeekday.Checked);
			writer.WriteLine(tsmiAutorun.Checked);
			writer.WriteLine(labelTime.BackColor.ToArgb());
			writer.WriteLine(labelTime.ForeColor.ToArgb());
			writer.WriteLine(fontDialog.FontFile);
			writer.WriteLine(fontDialog.FontSize);
			writer.Close();
			Process.Start("notepad", filename);
		}
		void LoadSettings()
		{
			Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
			StreamReader reader=null;
			try
			{
				reader = new StreamReader("Settings.ini");
				string location = reader.ReadLine();
				this.Location = new Point
					(
					Convert.ToInt16(location.Split('x').First()), 
					Convert.ToInt16(location.Split('x').Last())
					);
				tsmiTopmost.Checked = bool.Parse(reader.ReadLine());
				tsmiShowControls.Checked = bool.Parse(reader.ReadLine());
				tsmiShowDate.Checked = bool.Parse(reader.ReadLine());
				tsmiShowWeekday.Checked = bool.Parse(reader.ReadLine());
				tsmiAutorun.Checked = bool.Parse(reader.ReadLine());
				labelTime.BackColor = backgroundDialog.Color = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));
				labelTime.ForeColor = foregroundDialog.Color = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));
				//fontDialog = new FontDialog(this);
				//fontDialog.FontFile = reader.ReadLine();
				fontDialog = new FontDialog(this, reader.ReadLine());
				fontDialog.FontSize = (float)Convert.ToDouble(reader.ReadLine());
				labelTime.Font = fontDialog.ApplyFontExample(fontDialog.FontFile);
				reader.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message);
			}
			if (reader != null) reader.Close();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			labelTime.Text = DateTime.Now.ToString
				(
				"hh:mm:ss tt",
				System.Globalization.CultureInfo.InvariantCulture
				);
			if (checkBoxShowDate.Checked)
				labelTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";
			if (checkBoxShowWeekday.Checked)
				labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
			notifyIcon.Text = labelTime.Text;
		}
		void SetVisibility(bool visible)
		{
			checkBoxShowDate.Visible = visible; //Делает 'checkBoxShowDate' невидимым
			checkBoxShowWeekday.Visible = visible;//Делает 'checkBoxShowWeekday' невидимым
			buttonHideControls.Visible = visible; //Делает кнопку 'buttonHideControls' невидимой
			this.ShowInTaskbar = visible;//Скрываем кнопку приложения в панели задач
			this.FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;//Полностью убираем границы окна.
			this.TransparencyKey = visible ? Color.Empty : this.BackColor;//Делаем окно прозрачным.
																		  //Для того чтобы сделать окно прозрачным, его TransparencyKey должен совпадать с BackColor.
		}
		private void buttonHideControls_Click(object sender, EventArgs e) => tsmiShowControls.Checked = false;
		private void labelTime_DoubleClick(object sender, EventArgs e) => tsmiShowControls.Checked = true;

		private void tsmiTopmost_CheckedChanged(object sender, EventArgs e) =>
			//this.TopMost = tsmiTopmost.Checked;
			//this.TopMost = ((ToolStripMenuItem)sender).Checked;
			this.TopMost = (sender as ToolStripMenuItem).Checked;

		private void tsmiShowControls_CheckedChanged(object sender, EventArgs e) => SetVisibility(tsmiShowControls.Checked);
		private void tsmiExit_Click(object sender, EventArgs e) => this.Close();

		private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (!this.TopMost)
			{
				this.TopMost = true;
				this.TopMost = false;
			}
		}

		private void checkBoxShowDate_CheckedChanged(object sender, EventArgs e) =>
			tsmiShowDate.Checked = (sender as CheckBox).Checked;

		private void checkBoxShowWeekday_CheckedChanged(object sender, EventArgs e) =>
			tsmiShowWeekday.Checked = (sender as CheckBox).Checked;

		private void tsmiShowDate_CheckedChanged(object sender, EventArgs e) =>
			checkBoxShowDate.Checked = (sender as ToolStripMenuItem).Checked;

		private void tsmiShowWeekday_CheckedChanged(object sender, EventArgs e) =>
			checkBoxShowWeekday.Checked = (sender as ToolStripMenuItem).Checked;

		private void tsmiBackgroundColor_Click(object sender, EventArgs e)
		{
			DialogResult result = backgroundDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				labelTime.BackColor = backgroundDialog.Color;
			}
		}

		private void tsmiForegroundColor_Click(object sender, EventArgs e)
		{
			if (foregroundDialog.ShowDialog() == DialogResult.OK)
				labelTime.ForeColor = foregroundDialog.Color;
		}

		private void tsmiFont_Click(object sender, EventArgs e)
		{
			if (fontDialog.ShowDialog() == DialogResult.OK)
			{
				labelTime.Font = fontDialog.Font;
			}
		}

		private void tsmiAutorun_CheckedChanged(object sender, EventArgs e)
		{
			string key_name = "Clock_PV_522";
			RegistryKey rk = Registry.CurrentUser.
				OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//true - открыть ветку на запись.
			if (tsmiAutorun.Checked) rk.SetValue(key_name, Application.ExecutablePath);
			else rk.DeleteValue(key_name, false);
			//false - НЕ бросать исключение при отсутствии удаляемой ветки.
			rk.Dispose();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveSettings();
		}
	}
}
