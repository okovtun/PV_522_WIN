using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListBox
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		void DlgProc(object sender, EventArgs e)
		{
			//MessageBox.Show(sender.GetType().ToString().Split('.').Last());
			//MessageBox.Show(sender.GetType().ToString());
			//switch (sender.GetType().ToString().Split('.').Last())
			switch (sender.GetType().Name)
			{
				case nameof(TextBox):if ((e as KeyEventArgs).Key == Key.Enter) DlgProc(btnAdd, null);	break;
				case nameof(ListBox):if ((e as KeyEventArgs).Key == Key.Delete) DlgProc(btnDel, null);	break;
				case nameof(Button):
					switch ((sender as Button).Content)
					{
						case "ADD":
							if (!listBox.Items.Contains(tbInput.Text))
							{
								if (tbInput.Text.Trim() == "") break;
								listBox.Items.Add(tbInput.Text);
								tbInput.Text = "";
								tbInput.Focus();
							}
							break;
						case "DEL":
							if (listBox.SelectedIndex >= 0)
								listBox.Items.RemoveAt(listBox.SelectedIndex);
							break;
						case "CLR": listBox.Items.Clear(); break;
					}
					break;
			}
		}

		private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show(listBox.SelectedItem.ToString());
		}

		//private void KeyDown(object sender, KeyEventArgs e)
		//{
		//	if (sender is TextBox && e.Key == Key.Enter) button_Click(btnAdd, null);
		//	if (sender is System.Windows.Controls.ListBox && e.Key == Key.Delete) button_Click(btnDel, null);
		//}
	}
}
