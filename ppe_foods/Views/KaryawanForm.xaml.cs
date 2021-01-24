using ppe_foods.Models;
using ppe_foods.ViewModels;
using System.Windows;

namespace ppe_foods.Views
{
    /// <summary>
    /// Interaction logic for KaryawanForm.xaml
    /// </summary>
    public partial class KaryawanForm : Window
    {
        public KaryawanForm(KaryawanViewModel vm)
        {
            InitializeComponent();
            if (vm.ModelKaryawan == null)
            {
                vm.ModelKaryawan = new Karyawan();
            }
            DataContext = vm;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
