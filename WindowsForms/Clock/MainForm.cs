using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			this.Location = new Point
				(
					Screen.PrimaryScreen.Bounds.Width - this.Width - 50,
					50
				);
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
			checkBoxShowDate.Visible = visible;	//Делает 'checkBoxShowDate' невидимым
			checkBoxShowWeekday.Visible = visible;//Делает 'checkBoxShowWeekday' невидимым
			buttonHideControls.Visible = visible; //Делает кнопку 'buttonHideControls' невидимой
			this.ShowInTaskbar = visible;//Скрываем кнопку приложения в панели задач
			this.FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;//Полностью убираем границы окна.
			this.TransparencyKey = visible ? Color.Empty : this.BackColor;//Делаем окно прозрачным.
			//Для того чтобы сделать окно прозрачным, его TransparencyKey должен совпадать с BackColor.
		}
		private void buttonHideControls_Click(object sender, EventArgs e)
		{
			SetVisibility(false);
		}
		private void labelTime_DoubleClick(object sender, EventArgs e)
		{
			SetVisibility(true);
		}
	}
}
