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

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Binding
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		string boundText;
		public string BoundText
		{
			get => boundText;
			set
			{
				boundText = value;
				OnPropertyChanged();
				//OnPropertyChanged(nameof(BoundText));
			}
		}
		public MainWindow()
		{
			DataContext = this;
			InitializeComponent();
			txtInput.Focus();
		}
		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void BtnDefault_Click(object sender, RoutedEventArgs e)
		{
			BoundText = "Default";
		}
	}
}
