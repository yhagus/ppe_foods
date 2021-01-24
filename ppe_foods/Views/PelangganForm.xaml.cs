using ppe_foods.Models;
using ppe_foods.ViewModels;
using System.Windows;

namespace ppe_foods.Views
{
    /// <summary>
    /// Interaction logic for PelangganForm.xaml
    /// </summary>
    public partial class PelangganForm : Window
    {
        public PelangganForm(PelangganViewModel vm)
        {
            InitializeComponent();
            if (vm.ModelPelanggan == null)
            {
                vm.ModelPelanggan = new Pelanggan();
            }
            DataContext = vm;
        }
    }
}
