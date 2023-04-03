using SajatOsztalyok;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp3_Tartalyok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tartaly> tartalyok = new List<Tartaly>();
        string test = null;
        string fajlNev = "tartalyok.csv";
        double aEl;
        double bEl;
        double cEl;
        public MainWindow()
        {
            InitializeComponent();
            rdoTeglatest.IsChecked = true;
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            Tartaly tartaly1 = new Tartaly(txtNev.Text, Convert.ToInt16(aEl), Convert.ToInt16(bEl), Convert.ToInt16(cEl));
            if (txtNev.Text.Length == 0)
            {
                MessageBox.Show("Nem adta meg a test nevét!");
                return;
            }
            else if (SzamEllenorzes())
            {
                string sor = $"{txtNev.Text};{txtAel.Text};{txtBel.Text};{txtCel.Text};{tartaly1.Toltottseg / 100 * tartaly1.Terfogat}";
                StreamWriter sw = new StreamWriter(fajlNev, true);
                sw.WriteLine(sor);
                sw.Close();
                MessageBox.Show($"A {test} rögzítve lett a fájlban.");
                return;
            }


        }

        private void btnFelvesz_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtNev.Text.Length == 0)
            {
                MessageBox.Show("Nem adta meg a test nevét!");
            }
            if (SzamEllenorzes())
            {
                Tartaly tartaly = new Tartaly(txtNev.Text, Convert.ToInt16(aEl), Convert.ToInt16(bEl), Convert.ToInt16(cEl));
                string felvettSor = $"{txtNev.Text}: {tartaly.Terfogat * 1000} cm3 = ({tartaly.Terfogat} liter), töltöttsége: {tartaly.Toltottseg}, méretei: {txtAel.Text} x {txtBel.Text} x {txtCel.Text}";
                lbTartalyok.Items.Add(felvettSor);
            }

        }

        private void rdoTeglatest_Checked(object sender, RoutedEventArgs e)
        {
            txtNev.Text = "Téglatest";
            txtBel.IsReadOnly = false;
            txtCel.IsReadOnly = false;
            txtCel.Background = Brushes.LightSkyBlue;
            txtBel.Background = Brushes.LightSkyBlue;
            txtAel.Text = "";
            txtBel.Text = "";
            txtCel.Text = "";

        }

        private void rdoKocka_Checked(object sender, RoutedEventArgs e)
        {
            txtNev.Text = "Kocka";
            txtBel.IsReadOnly = true;
            txtCel.IsReadOnly = true;
            txtCel.Background = Brushes.LightGray;
            txtBel.Background = Brushes.LightGray;
            txtAel.Text = "10";
            txtBel.Text = "10";
            txtCel.Text = "10";

        }

        private void btnTolt_Click(object sender, RoutedEventArgs e)
        {
            double tolt;
            try
            {
                tolt = double.Parse(txtTolt.Text);
                Tartaly tartaly = new Tartaly(txtNev.Text, Convert.ToInt16(txtAel), Convert.ToInt16(txtBel), Convert.ToInt16(txtCel));
                tartaly.Tolt(tolt);
            }
            catch (FormatException)
            {
                MessageBox.Show("Nem jó a számformátum!");
                txtTolt.Text = "1";
                txtTolt.Focus();
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Egyéb nem azonosított hiba!");
                txtTolt.Text = "1";
                txtTolt.Focus();
                return;
            }

        }

        private void btnDuplaz_Click(object sender, RoutedEventArgs e)
        {
            Tartaly tartaly = new Tartaly(txtNev.Text, Convert.ToInt16(txtAel), Convert.ToInt16(txtBel), Convert.ToInt16(txtCel));
            tartaly.DuplazMeretet();
        }

        private void txtAel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (rdoKocka.IsChecked == true)
            {
                txtBel.Text = txtAel.Text;
                txtCel.Text = txtAel.Text;
            }

        }

        private void txtAel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rdoKocka.IsChecked == true)
            {
                txtBel.Text = txtAel.Text;
                txtCel.Text = txtAel.Text;
            }
        }

        private bool SzamEllenorzes()
        {
            try
            {
                int aEl = Convert.ToInt16(txtAel.Text);
                int bEl = Convert.ToInt16(txtBel.Text);
                int cEl = Convert.ToInt16(txtCel.Text);
                return true;

            }
            catch (FormatException)
            {
                MessageBox.Show("Nem jó a számformátum!");
                MilyenTest();
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Egyéb nem azonosított hiba!");
                MilyenTest();
                return false;
            }


        }

        private void MilyenTest()
        {
            if (test == "Kocka")
            {
                txtNev.Text = "Kocka";
                txtBel.IsReadOnly = true;
                txtCel.IsReadOnly = true;
                txtCel.Background = Brushes.LightGray;
                txtBel.Background = Brushes.LightGray;
                txtAel.Text = "10";
                txtBel.Text = "10";
                txtCel.Text = "10";
            }
            else
            {
                txtNev.Text = "Téglatest";
                txtBel.IsReadOnly = false;
                txtCel.IsReadOnly = false;
                txtCel.Background = Brushes.LightSkyBlue;
                txtBel.Background = Brushes.LightSkyBlue;
                txtAel.Text = "";
                txtBel.Text = "";
                txtCel.Text = "";
            }
        }
    }
}
