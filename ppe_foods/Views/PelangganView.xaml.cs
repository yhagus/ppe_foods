using ppe_foods.ViewModels;
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

namespace ppe_foods.Views
{
    /// <summary>
    /// Interaction logic for PelangganView.xaml
    /// </summary>
    public partial class PelangganView : UserControl
    {
        public PelangganView()
        {
            InitializeComponent();

            vm = new PelangganViewModel();

            vm.OnReload += () =>
            {
                LstData.ItemsSource = null;
                LstData.ItemsSource = vm.DataPelanggan;
                if (form != null)
                {
                    form.Close();
                }
                vm.ModelPelanggan = null;
            };
            DataContext = vm;
        }

        private PelangganViewModel vm;
        private PelangganForm form;

        private async Task InitFormAsync()
        {
            await Task.Delay(0);
            form = new PelangganForm(vm);
            form.ShowDialog();
        }

        private async void LstData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Task.Delay(0);
        }

        private async void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            vm.ModelPelanggan = null;
            await InitFormAsync();
        }
    }
}
