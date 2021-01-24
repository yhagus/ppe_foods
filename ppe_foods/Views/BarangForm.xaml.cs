using ppe_foods.Models;
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
using System.Windows.Shapes;

namespace ppe_foods.Views
{
    /// <summary>
    /// Interaction logic for BarangForm.xaml
    /// </summary>
    public partial class BarangForm : Window
    {
        public BarangForm(BarangViewModel vm)
        {
            InitializeComponent();
            if (vm.ModelBarang == null)
            {
                vm.ModelBarang = new Barang();
            }
            DataContext = vm;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
