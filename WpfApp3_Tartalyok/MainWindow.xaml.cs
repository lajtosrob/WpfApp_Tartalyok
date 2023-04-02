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
            rdoTeglatest.IsChecked= true;
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFelvesz_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void rdoTeglatest_Checked(object sender, RoutedEventArgs e)
        {
            txtNev.Text = "Téglatest";

        }

        private void rdoKocka_Checked(object sender, RoutedEventArgs e)
        {
            txtNev.Text = "Kocka";
        }

        private void btnTolt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDuplaz_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
