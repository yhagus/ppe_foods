using ppe_foods.Models;
using ppe_foods.ViewModels;
using System;
using System.Windows;

namespace ppe_foods.Views
{
    /// <summary>
    /// Interaction logic for PenjualanForm.xaml
    /// </summary>
    public partial class PenjualanForm : Window
    {
        public PenjualanForm(PenjualanViewModel vm)
        {
            InitializeComponent();
            if (vm.ModelPenjualan == null)
            {
                vm.ModelPenjualan = new Penjualan();
                vm.ModelPenjualan.Tanggal = DateTime.Today;
            }
            DataContext = vm;
        }
    }
}
