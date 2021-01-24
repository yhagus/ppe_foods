using ppe_foods.ViewModels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ppe_foods.Views
{
    /// <summary>
    /// Interaction logic for BarangView.xaml
    /// </summary>
    public partial class BarangView : UserControl
    {
        public BarangView()
        {
            InitializeComponent();

            vm = new BarangViewModel();

            vm.OnReload += () =>
            {
                LstData.ItemsSource = null;
                LstData.ItemsSource = vm.DataBarang;
                if (form != null)
                {
                    form.Close();
                }
                vm.ModelBarang = null;
            };
            DataContext = vm;
        }

        private BarangViewModel vm;
        private BarangForm form;

        private async Task InitFormAsync()
        {
            await Task.Delay(0);
            form = new BarangForm(vm);
            form.ShowDialog();
        }

        private async void LstData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Task.Delay(0);
        }
        private async void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            vm.ModelBarang = null;
            await InitFormAsync();
        }
    }
}
