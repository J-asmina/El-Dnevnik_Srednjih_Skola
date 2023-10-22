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
    /// Interaction logic for ObrazovniProfil.xaml
    /// </summary>
    public partial class ObrazovniProfil : Window
    {
        public ObrazovniProfil()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SQLMetode.PopuniTabelu(tabela, "Obrazovni_profil");
            cmbTrajanje.Items.Clear();
            List<string> pozicije = new List<string>();
            pozicije.Add("3");
            pozicije.Add("4");
            cmbTrajanje.ItemsSource = pozicije;
            SQLMetode.PopuniTabelu(tabela, "Obrazovni_profil");
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
                    txtObrazovniProfilID.Text = row[0].ToString();
                    txtNazivObrazovnogProfila.Text = row[1].ToString();
                    cmbTrajanje.SelectedItem = row[2].ToString();
                    txtOpisObrazovnogProfila.Text = row[3].ToString();
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
                    cmd.CommandText = "INSERT INTO Obrazovni_profil (Naziv_obrazovnog_profila, Trajanje_obrazovnog_profila, Opis_obrazovnog_profila) VALUES('" + txtNazivObrazovnogProfila.Text + "'," + cmbTrajanje.SelectedItem.ToString() + ",'" + txtOpisObrazovnogProfila.Text + "')";
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

                SQLMetode.PopuniTabelu(tabela, "Obrazovni_profil");
            }
            else
            {
                MessageBox.Show("Sva polja moraju biti popunjena.");
            }
        }

        private bool ProveriPopunjenostPolja()
        {
            // Proveri da li su sva polja popunjena
            if (string.IsNullOrWhiteSpace(txtNazivObrazovnogProfila.Text) || cmbTrajanje.SelectedItem == null)
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
                cmd.CommandText = "UPDATE Obrazovni_profil SET Naziv_obrazovnog_profila='" + txtNazivObrazovnogProfila.Text + "', Trajanje_obrazovnog_profila=" + cmbTrajanje.SelectedItem.ToString() + ", Opis_obrazovnog_profila='" + txtOpisObrazovnogProfila.Text + "' WHERE Obrazovni_profil_ID=" + Convert.ToInt32(txtObrazovniProfilID.Text);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
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
            SQLMetode.PopuniTabelu(tabela, "Obrazovni_profil");
        }

        private void btnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = SQLMetode.ConnString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "DELETE FROM Obrazovni_profil WHERE Obrazovni_profil_ID=" + Convert.ToInt32(txtObrazovniProfilID.Text);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
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
            SQLMetode.PopuniTabelu(tabela, "Obrazovni_profil");
        }
    }
}
