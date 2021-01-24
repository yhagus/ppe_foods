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
    /// Interaction logic for PenjualanView.xaml
    /// </summary>
    public partial class PenjualanView : UserControl
    {
        public PenjualanView()
        {
            InitializeComponent();

            vm = new PenjualanViewModel();

            vm.OnReload += () =>
            {
                LstData.ItemsSource = null;
                LstData.ItemsSource = vm.DataPenjualan;
                if (form != null)
                {
                    form.Close();
                }
                vm.ModelPenjualan = null;
            };
            DataContext = vm;
        }
        private PenjualanViewModel vm;
        private PenjualanForm form;

        private async Task InitFormAsync()
        {
            await Task.Delay(0);
            form = new PenjualanForm(vm);
            form.ShowDialog();
        }

        private async void LstData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Task.Delay(0);
        }

        private async void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            vm.ModelPenjualan = null;
            await InitFormAsync();
        }

    }
}
