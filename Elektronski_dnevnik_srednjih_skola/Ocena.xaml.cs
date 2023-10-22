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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Elektronski_dnevnik_srednjih_skola
{
	/// <summary>
	/// Interaction logic for Ocena.xaml
	/// </summary>
	public partial class Ocena : Window
	{
		int RadnikID;
		int PredmetID;
		int UcenikID;
		public Ocena()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			SQLMetode.PopuniTabelu(tabela, "Ocena");
			SQLMetode.PopuniCMB(cmbRadnik, "Radnik", "Ime_radnika", "Prezime_radnika");
			SQLMetode.PopuniCMB(cmbPredmet, "Predmet", "Naziv_predmeta");
			SQLMetode.PopuniCMB(cmbUcenik, "Ucenik", "Ime_ucenika", "Prezime_ucenika");
			SQLMetode.PopuniTabelu(tabela, "Ocena");
		}

		private void btnNazad_Click(object sender, RoutedEventArgs e)
		{
			new MainWindow().Show();
			this.Close();
		}

		private void tabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (tabela.SelectedIndex != -1)
			{
				try
				{
					DataRowView row = (DataRowView)tabela.SelectedItem;
					txtOcenaID.Text = row[0].ToString();
					slVrednost.SetValue(Slider.ValueProperty, Convert.ToDouble(row[1]));
					RadnikID = Convert.ToInt32(row[2]);
					cmbRadnik.SelectedItem = SQLMetode.PronadjiNestoPrekoID("Radnik", "Radnik_ID", "Ime_radnika", "Prezime_radnika", RadnikID);
					PredmetID = Convert.ToInt32(row[3]);
					cmbPredmet.SelectedItem = SQLMetode.PronadjiNestoPrekoID("Predmet", "Predmet_ID", "Naziv_predmeta", PredmetID);
					UcenikID = Convert.ToInt32(row[4]);
					cmbUcenik.SelectedItem = SQLMetode.PronadjiNestoPrekoID("Ucenik", "Ucenik_ID", "Ime_ucenika" + " " + "Prezime_ucenika", UcenikID);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Podaci nisu dobro uneti");
				}
			}
		}

		private void btnUnesi_Click(object sender, RoutedEventArgs e)
		{
			// Proveri da li su sva polja popunjena
			if (ProveriPopunjenostPolja())
			{
				string connectionString = SQLMetode.ConnString;
				SqlConnection con = new SqlConnection(connectionString);
				SqlCommand cmd = new SqlCommand();

				try
				{
					cmd.CommandText = "INSERT INTO Ocena (Vrednost, Radnik_ID, Predmet_ID, Ucenik_ID) VALUES(" + slVrednost.Value.ToString() + "," + cmbRadnik.SelectedItem.ToString() + "," + cmbPredmet.SelectedItem.ToString() + "," + cmbUcenik.SelectedItem.ToString() + ")";
					cmd.Connection = con;
					con.Open();
					cmd.ExecuteScalar();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					cmd.Dispose();
					con.Close();
				}

				SQLMetode.PopuniTabelu(tabela, "Ocena");
			}
			else
			{
				MessageBox.Show("Sva polja moraju biti popunjena.");
			}
		}

		private bool ProveriPopunjenostPolja()
        {
            // Proveri da li su sva polja popunjena
            if (string.IsNullOrWhiteSpace(cmbRadnik.SelectedItem?.ToString()) ||
                string.IsNullOrWhiteSpace(cmbPredmet.SelectedItem?.ToString()) ||
                string.IsNullOrWhiteSpace(cmbUcenik.SelectedItem?.ToString()))
            {
                return false;
            }

            return true;
        }


		private void btnIzmeni_Click(object sender, RoutedEventArgs e)
		{
			string connectionString = SQLMetode.ConnString;
			SqlConnection con = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand();
			try
			{
				cmd.CommandText = "Update Ocena SET Vrednost=" + slVrednost.Value.ToString() + ",Radnik_ID=" + cmbRadnik.SelectedItem.ToString() + ",Predmet_ID=" + cmbPredmet.SelectedItem.ToString() + "," + cmbUcenik.SelectedItem.ToString() + " WHERE Ocena_ID=" + Convert.ToInt32(txtOcenaID.Text);
				cmd.Connection = con;
				con.Open();
				SqlDataReader reader = cmd.ExecuteReader();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Podaci nisu dobro uneti");
			}
			finally
			{
				cmd.Dispose();
				con.Close();
			}
			SQLMetode.PopuniTabelu(tabela, "Ocena");
		}

		private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
		{
			string connectionString = SQLMetode.ConnString;
			SqlConnection con = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand();
			try
			{
				cmd.CommandText = "DELETE FROM Ocena WHERE Ocena_ID=" + Convert.ToInt32(txtOcenaID.Text);
				cmd.Connection = con;
				con.Open();
				cmd.ExecuteScalar();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Podaci nisu dobro uneti");
			}
			finally
			{
				cmd.Dispose();
				con.Close();
			}
			SQLMetode.PopuniTabelu(tabela, "Ocena");
		}

		private void slVrednost_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			txtVrednost.Text = Math.Round(slVrednost.Value).ToString();
		}
	}
}
