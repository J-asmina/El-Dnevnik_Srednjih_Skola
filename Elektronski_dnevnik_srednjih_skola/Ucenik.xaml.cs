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
	/// Interaction logic for Ucenik.xaml
	/// </summary>
	public partial class Ucenik : Window
	{
		int ObrazovniProfilID;
		public Ucenik()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			SQLMetode.PopuniTabelu(tabela, "Ucenik");
			cmbGodina.Items.Clear();
			List<string> godina = new List<string>();
			godina.Add("1");
			godina.Add("2");
			godina.Add("3");
			godina.Add("4");
			cmbGodina.ItemsSource = godina;
			SQLMetode.PopuniTabelu(tabela, "Ucenik");
			SQLMetode.PopuniCMB(cmbObrazovniProfil, "Obrazovni_profil", "Naziv_obrazovnog_profila");
			SQLMetode.PopuniTabelu(tabela, "Ucenik");
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
					txtUcenikID.Text = row[0].ToString();
					txtImeUcenika.Text = row[1].ToString();
					txtPrezimeUcenika.Text = row[2].ToString();
					txtUlicaIBrojUcenika.Text = row[3].ToString();
					txtBrojTelefonaUcenika.Text = row[4].ToString();

					string email = row[5].ToString();
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
					cmbGodina.SelectedItem = row[6].ToString();
					ObrazovniProfilID = Convert.ToInt32(row[7]);
					cmbObrazovniProfil.SelectedItem = SQLMetode.PronadjiNestoPrekoID("Obrazovni_profil", "Obrazovni_profil_ID", "Naziv_obrazovnog_profila", ObrazovniProfilID);
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
					cmd.CommandText = "INSERT INTO Ucenik (Ime_ucenika, Prezime_ucenika, Ulica_i_broj_ucenika, Broj_telefona_ucenika, Email_adresa_ucenika, Godina, Obrazovni_profil_ID) VALUES('" + txtImeUcenika.Text + "','" + txtPrezimeUcenika.Text + "','" + txtUlicaIBrojUcenika.Text + "','" + txtBrojTelefonaUcenika.Text + "','" + txtEmailPrviDeo.Text + "@" + txtEmailDrugiDeo.Text + "." + txtEmailTreciDeo.Text + "'," + cmbGodina.SelectedItem.ToString() + "," + cmbObrazovniProfil.SelectedItem.ToString() + ")";
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

				SQLMetode.PopuniTabelu(tabela, "Ucenik");
			}
			else
			{
				MessageBox.Show("Sva polja moraju biti popunjena.");
			}
		}

		private bool ProveriPopunjenostPolja()
		{
			// Proveri da li su sva polja popunjena
			if (string.IsNullOrWhiteSpace(txtImeUcenika.Text) ||
				string.IsNullOrWhiteSpace(txtPrezimeUcenika.Text) ||
				string.IsNullOrWhiteSpace(txtUlicaIBrojUcenika.Text) ||
				string.IsNullOrWhiteSpace(txtBrojTelefonaUcenika.Text) ||
				string.IsNullOrWhiteSpace(txtEmailPrviDeo.Text) ||
				string.IsNullOrWhiteSpace(txtEmailDrugiDeo.Text) ||
				string.IsNullOrWhiteSpace(txtEmailTreciDeo.Text) ||
				cmbGodina.SelectedItem == null ||
				cmbObrazovniProfil.SelectedItem == null)
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
				cmd.CommandText = "Update Ucenik SET Ime_ucenika='" + txtImeUcenika.Text + "',Prezime_ucenika='" + txtPrezimeUcenika.Text + "',Ulica_i_broj_ucenika='" + txtUlicaIBrojUcenika.Text + "',Broj_telefona_ucenika='" + txtBrojTelefonaUcenika.Text + "',Email_adresa_ucenika='" + txtEmailPrviDeo.Text + "@" + txtEmailDrugiDeo.Text + "." + txtEmailTreciDeo.Text + "'," + cmbGodina.SelectedItem.ToString() + "," + cmbObrazovniProfil.SelectedIndex.ToString() + " WHERE Ucenik_ID=" + Convert.ToInt32(txtUcenikID.Text);
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
			SQLMetode.PopuniTabelu(tabela, "Ucenik");
		}

		private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
		{
			string connectionString = SQLMetode.ConnString;
			SqlConnection con = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand();
			try
			{
				cmd.CommandText = "DELETE FROM Ucenik WHERE Ucenik_ID=" + Convert.ToInt32(txtUcenikID.Text);
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
			SQLMetode.PopuniTabelu(tabela, "Ucenik");
		}
	}
}
