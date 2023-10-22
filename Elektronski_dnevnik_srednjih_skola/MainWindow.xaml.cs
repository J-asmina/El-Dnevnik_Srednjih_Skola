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

namespace Elektronski_dnevnik_srednjih_skola
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		private void btnSrednjaSkola_Click(object sender, RoutedEventArgs e)
		{
			SrednjaSkola ss  = new SrednjaSkola();
			ss.Show();
			Close();
		}

		private void btnRadnik_Click(object sender, RoutedEventArgs e)
		{
			Radnik r = new Radnik();
			r.Show();
			Close();
		}

		private void btnPredmet_Click(object sender, RoutedEventArgs e)
		{
			new Predmet().Show();
			Close();
		}

		private void btnOcena_Click(object sender, RoutedEventArgs e)
		{
			new Ocena().Show();
			Close();
		}

		private void btnUcenik_Click(object sender, RoutedEventArgs e)
		{
			new Ucenik().Show();
			Close();
		}

		private void btnObrazovniProfil_Click(object sender, RoutedEventArgs e)
		{
			new ObrazovniProfil().Show();
			Close();
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
