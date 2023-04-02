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
        string test;
        string fajlNev = "tartalyok.csv";
        public MainWindow()
        {
            InitializeComponent();

            rdoTeglatest.IsChecked = true;

        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            string sor = $"{txtNev.Text};{txtAel.Text};{txtBel.Text};{txtCel.Text}";
            StreamWriter sw = new StreamWriter(fajlNev, true);
            sw.WriteLine(sor);
            sw.Close();
            MessageBox.Show($"A {test} rögzítve lett a fájlban.");
        }

        private void btnFelvesz_Click_1(object sender, RoutedEventArgs e)
        {
            Tartaly tartaly = new Tartaly(txtNev.Text, Convert.ToInt16(txtAel.Text), Convert.ToInt16(txtBel.Text), Convert.ToInt16(txtCel.Text));
            test = rdoTeglatest.IsChecked == true ? "Téglatest" : "Kocka";
            string felvettSor = $"{test}: {tartaly.Terfogat * 1000} cm3 = ({tartaly.Terfogat} liter), töltöttsége: {tartaly.Toltottseg}, méretei: {txtAel.Text} x {txtBel.Text} x {txtCel.Text}";
            lbTartalyok.Items.Add(felvettSor);
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
            Tartaly tartaly = new Tartaly(txtNev.Text, Convert.ToInt16(txtAel), Convert.ToInt16(txtBel), Convert.ToInt16(txtCel));
            tartaly.Tolt(Convert.ToDouble(btnTolt.Content));


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
    }
}
