using System.Windows;

namespace ppe_foods.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MenuKaryawan_Click(object sender, RoutedEventArgs e)
        {
            App.ViewRouting(false);
            App.ViewRouting(true, new KaryawanView());
        }

        private void MenuBarang_Click(object sender, RoutedEventArgs e)
        {
            App.ViewRouting(false);
            App.ViewRouting(true, new BarangView());
        }

        private void MenuPelanggan_Click(object sender, RoutedEventArgs e)
        {
            App.ViewRouting(false);
            App.ViewRouting(true, new PelangganView());
        }

        private void MenuPenjualan_Click(object sender, RoutedEventArgs e)
        {
            App.ViewRouting(false);
            App.ViewRouting(true, new PenjualanView());
        }
    }
}
