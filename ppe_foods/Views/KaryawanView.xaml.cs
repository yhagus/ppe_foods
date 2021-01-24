using ppe_foods.ViewModels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ppe_foods.Views
{
    /// <summary>
    /// Interaction logic for KaryawanView.xaml
    /// </summary>
    public partial class KaryawanView : UserControl
    {
        public KaryawanView()
        {
            InitializeComponent();

            vm = new KaryawanViewModel();

            vm.OnReload += () =>
            {
                LstData.ItemsSource = null;
                LstData.ItemsSource = vm.DataKaryawan;
                if (form != null)
                {
                    form.Close();
                }
                vm.ModelKaryawan = null;
            };
            DataContext = vm;
        }

        private KaryawanViewModel vm;
        private KaryawanForm form;

        private async Task InitFormAsync()
        {
            await Task.Delay(0);
            form = new KaryawanForm(vm);
            form.ShowDialog();
        }

        private async void LstData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Task.Delay(0);
        }

        private async void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            vm.ModelKaryawan = null;
            await InitFormAsync();
        }
    }
}
