using SajatOsztalyok;
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

namespace WpfApp3_Tartalyok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tartaly> tartalyok = new List<Tartaly>();
        public MainWindow()
        {
            InitializeComponent();
            Tartaly tartaly = new Tartaly();
            rdoTeglatest.IsChecked= true;

        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            //string fájlSor = $"{txta}"
        }

        private void btnFelvesz_Click_1(object sender, RoutedEventArgs e)
        {
            
            string test = rdoTeglatest.IsChecked == true ? "Téglatest" : "Kocka";
            //string felvettSor = $"{test}: {tartalyok.}";
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
            txtBel.IsReadOnly= true;
            txtCel.IsReadOnly= true;
            txtCel.Background = Brushes.LightGray;
            txtBel.Background = Brushes.LightGray;
            txtAel.Text = "10";
            txtBel.Text = "10";
            txtCel.Text = "10";

        }

        private void btnTolt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDuplaz_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
