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
	/// Interaction logic for SrednjaSkola.xaml
	/// </summary>
	public partial class SrednjaSkola : Window
	{
		
		public SrednjaSkola()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			SQLMetode.PopuniTabelu(tabela, "Srednja_skola");
		}

		private void btnNazad_Click(object sender, RoutedEventArgs e)
		{
			new MainWindow().Show();
			this.Close();
		}

		private void tabela_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (tabela.SelectedIndex != -1)
				try
				{
					DataRowView row = (DataRowView)tabela.SelectedItem;
					txtSrednjaSkolaID.Text = row[0].ToString();
					txtNazivSrednjeSkole.Text = row[1].ToString();
					txtNazivMestaSrednjeSkole.Text = row[2].ToString();
					txtUlicaIBrojSrednjeSkole.Text = row[3].ToString();
					txtBrojTelefonaSrednjeSkole.Text = row[4].ToString();
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
				}
				catch (Exception ex)
				{
					MessageBox.Show("Podaci nisu dobro uneti");
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
					cmd.CommandText = "INSERT INTO Srednja_skola (Naziv_srednje_skole, Naziv_mesta_srednje_skole, Ulica_i_broj_srednje_skole, Broj_telefona_srednje_skole, Email_adresa_srednje_skole) VALUES('" + txtNazivSrednjeSkole.Text + "','" + txtNazivMestaSrednjeSkole.Text + "','" + txtUlicaIBrojSrednjeSkole.Text + "','" + txtBrojTelefonaSrednjeSkole.Text + "','" + txtEmailPrviDeo.Text + "@" + txtEmailDrugiDeo.Text + "." + txtEmailTreciDeo.Text + "')";
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

				SQLMetode.PopuniTabelu(tabela, "Srednja_skola");
			}
			else
			{
				MessageBox.Show("Sva polja moraju biti popunjena.");
			}
		}

		private bool ProveriPopunjenostPolja()
		{
			// Proveri da li su sva polja popunjena
			if (string.IsNullOrWhiteSpace(txtNazivSrednjeSkole.Text) ||
				string.IsNullOrWhiteSpace(txtNazivMestaSrednjeSkole.Text) ||
				string.IsNullOrWhiteSpace(txtUlicaIBrojSrednjeSkole.Text) ||
				string.IsNullOrWhiteSpace(txtBrojTelefonaSrednjeSkole.Text) ||
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
				cmd.CommandText = "Update Srednja_skola SET Naziv_srednje_skole='" + txtNazivSrednjeSkole.Text + "',Naziv_mesta_srednje_skole='" + txtNazivMestaSrednjeSkole.Text + "',Ulica_i_broj_srednje_skole='" + txtUlicaIBrojSrednjeSkole.Text + "',Broj_telefona_srednje_skole='" + txtBrojTelefonaSrednjeSkole.Text + "',Email_adresa_srednje_skole='" + txtEmailPrviDeo.Text + "@" + txtEmailDrugiDeo.Text + "." + txtEmailTreciDeo.Text + "' WHERE Srednja_skola_ID=" + Convert.ToInt32(txtSrednjaSkolaID.Text);
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
			SQLMetode.PopuniTabelu(tabela, "Srednja_skola");
		}

		private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
		{
			string connectionString = SQLMetode.ConnString;
			SqlConnection con = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand();
			try
			{
				cmd.CommandText = "DELETE FROM Srednja_skola WHERE Srednja_skola_ID=" + Convert.ToInt32(txtSrednjaSkolaID.Text);
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
			SQLMetode.PopuniTabelu(tabela, "Srednja_skola");
		}
	}
}
