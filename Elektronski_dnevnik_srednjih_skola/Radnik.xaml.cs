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
	/// Interaction logic for Radnik.xaml
	/// </summary>
	public partial class Radnik : Window
	{
		public Radnik()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			SQLMetode.PopuniTabelu(tabela, "Radnik");
			cmbPozicija.Items.Clear();
			List<string> pozicije = new List<string>();
			pozicije.Add("Nastavnik");
			pozicije.Add("Direktor");
			pozicije.Add("Pedagog");
			pozicije.Add("Psiholog");
			cmbPozicija.ItemsSource = pozicije;
			SQLMetode.PopuniTabelu(tabela, "Radnik");
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
					txtRadnikID.Text = row[0].ToString();
					cmbPozicija.SelectedItem = row[1].ToString();
					txtImeRadnika.Text = row[2].ToString();
					txtPrezimeRadnika.Text = row[3].ToString();

					if (DateTime.TryParse(row[4].ToString(), out DateTime datumZaposlenja))
					{
						dpDatumZaposlenja.SelectedDate = datumZaposlenja;
					}

					txtUlicaIBrojRadnika.Text = row[5].ToString();
					txtBrojTelefonaRadnika.Text = row[6].ToString();

					string email = row[7].ToString();
					int atIndex = email.IndexOf("@");
					int dotIndex = email.LastIndexOf(".");

					if (atIndex != -1 && dotIndex != -1 && dotIndex > atIndex)
					{
						txtEmailPrviDeo.Text = email.Substring(0, atIndex);
						txtEmailDrugiDeo.Text = email.Substring(atIndex + 1, dotIndex - atIndex - 1);
						txtEmailTreciDeo.Text = email.Substring(dotIndex + 1);
					}
					else
					{
						// Prikazati celu e-mail adresu ako ne uspe razdvajanje
						txtEmailPrviDeo.Text = email;
						txtEmailDrugiDeo.Text = "";
						txtEmailTreciDeo.Text = "";
					}
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
					cmd.CommandText = "INSERT INTO Radnik (Pozicija, Ime_radnika, Prezime_radnika, Datum_zaposlenja, Ulica_i_broj_radnika, Broj_telefona_radnika, Email_adresa_radnika) VALUES('" + cmbPozicija.SelectedItem.ToString() + "','" + txtImeRadnika.Text + "','" + txtPrezimeRadnika.Text + "','" + dpDatumZaposlenja.SelectedDate.ToString() + "','" + txtUlicaIBrojRadnika.Text + "','" + txtBrojTelefonaRadnika.Text + "','" + txtEmailPrviDeo.Text + "@" + txtEmailDrugiDeo.Text + "." + txtEmailTreciDeo.Text + "')";
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

				SQLMetode.PopuniTabelu(tabela, "Radnik");
			}
			else
			{
				MessageBox.Show("Sva polja moraju biti popunjena.");
			}
		}

		private bool ProveriPopunjenostPolja()
		{
			// Proveri da li su sva polja popunjena
			if (cmbPozicija.SelectedItem == null ||
				string.IsNullOrWhiteSpace(txtImeRadnika.Text) ||
				string.IsNullOrWhiteSpace(txtPrezimeRadnika.Text) ||
				dpDatumZaposlenja.SelectedDate == null ||
				string.IsNullOrWhiteSpace(txtUlicaIBrojRadnika.Text) ||
				string.IsNullOrWhiteSpace(txtBrojTelefonaRadnika.Text) ||
				string.IsNullOrWhiteSpace(txtEmailPrviDeo.Text) ||
				string.IsNullOrWhiteSpace(txtEmailDrugiDeo.Text) ||
				string.IsNullOrWhiteSpace(txtEmailTreciDeo.Text))
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
				cmd.CommandText = "Update Radnik SET Pozicija='" + cmbPozicija.SelectedItem.ToString() + "',Ime_radnika='" + txtImeRadnika.Text + "',Prezime_radnika='" + txtPrezimeRadnika.Text+ "',Datum_zaposlenja='" + dpDatumZaposlenja.SelectedDate.ToString() + "',Ulica_i_broj_radnika='" + txtUlicaIBrojRadnika.Text + "',Broj_telefona_radnika='" + txtBrojTelefonaRadnika.Text + "',Email_adresa_radnika='" + txtEmailPrviDeo.Text + "@" + txtEmailDrugiDeo.Text + "." + txtEmailTreciDeo.Text + "' WHERE Radnik_ID=" + Convert.ToInt32(txtRadnikID.Text);
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
			SQLMetode.PopuniTabelu(tabela, "Radnik");
		}

		private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
		{
			string connectionString = SQLMetode.ConnString;
			SqlConnection con = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand();
			try
			{
				cmd.CommandText = "DELETE FROM Radnik WHERE Radnik_ID=" + Convert.ToInt32(txtRadnikID.Text);
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
			SQLMetode.PopuniTabelu(tabela, "Radnik");
		}
	}
}

