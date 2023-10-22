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
	/// Interaction logic for Predmet.xaml
	/// </summary>
	public partial class Predmet : Window
	{
		public Predmet()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			SQLMetode.PopuniTabelu(tabela, "Predmet");
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
					txtPredmetID.Text = row[0].ToString();
					txtNazivPredmeta.Text = row[1].ToString();
					txtOpisPredmeta.Text = row[2].ToString();
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
					cmd.CommandText = "INSERT INTO Predmet (Naziv_predmeta, Opis_predmeta) VALUES('" + txtNazivPredmeta.Text + "','" + txtOpisPredmeta.Text + "')";
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

				SQLMetode.PopuniTabelu(tabela, "Predmet");
			}
			else
			{
				MessageBox.Show("Sva polja moraju biti popunjena.");
			}
		}

		private bool ProveriPopunjenostPolja()
		{
			// Proveri da li su sva polja popunjena
			if (string.IsNullOrWhiteSpace(txtNazivPredmeta.Text) || string.IsNullOrWhiteSpace(txtOpisPredmeta.Text))
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
				cmd.CommandText = "Update Radnik SET Naziv_predmeta='" + txtNazivPredmeta.Text + "',Opis_predmeta='" + txtOpisPredmeta.Text + "' WHERE Predmet_ID=" + Convert.ToInt32(txtPredmetID.Text);
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
			SQLMetode.PopuniTabelu(tabela, "Predmet");
		}

		private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
		{
			string connectionString = SQLMetode.ConnString;
			SqlConnection con = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand();
			try
			{
				cmd.CommandText = "DELETE FROM Predmet WHERE Predmet_ID=" + Convert.ToInt32(txtPredmetID.Text);
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
			SQLMetode.PopuniTabelu(tabela, "Predmet");
		}
	}
}
