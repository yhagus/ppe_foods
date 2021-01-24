using ppe_foods.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ppe_foods.ViewModels
{
    public class PenjualanViewModel : BaseViewModel
    {
        public PenjualanViewModel()
        {
            DataBarang = new ObservableCollection<Barang>(dbo.Barangs.ToList());

            datapenjualan = new ObservableCollection<Penjualan>();
            modelpenjualan = new Penjualan();

            CreateCommand = new Command(async () => await CreatePenjualanAsync());
            UpdateCommand = new Command(async () => await UpdatePenjualanAsync());
            DeleteCommand = new Command(async () => await DeletePenjualanAsync());
            ReadCommand = new Command(async () => await ReadPenjualanAsync());
            ReadCommand.Execute(null);
        }
        private DBFoodsEntities dbo = new DBFoodsEntities();

        public event Action OnReload;
        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Penjualan modelpenjualan;
        public Penjualan ModelPenjualan
        {
            get { return modelpenjualan; }
            set { SetProperty(ref modelpenjualan, value); }
        }

        private Penjualan selectedpenjualan;
        public Penjualan SelectedPenjualan
        {
            get { return selectedpenjualan; }
            set { SetProperty(ref selectedpenjualan, value); }
        }

        private ObservableCollection<Penjualan> datapenjualan;
        public ObservableCollection<Penjualan> DataPenjualan
        {
            get { return datapenjualan; }
            set { SetProperty(ref datapenjualan, value); }
        }
        public ObservableCollection<Barang> DataBarang { get; set; }

        private async Task ReadPenjualanAsync()
        {
            try
            {
                DataPenjualan?.Clear();
                foreach (Penjualan penjualan in dbo.Penjualans)
                {
                    DataPenjualan.Add(penjualan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat");
            }
        }
        private async Task CreatePenjualanAsync()
        {
            try
            {
                dbo.Penjualans.Add(ModelPenjualan);
                dbo.SaveChanges();
                MessageBox.Show("Berhasil menambahkan data");
                ModelPenjualan = new Penjualan();
                OnReload?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambahkan data");
            }
            finally
            {
                await ReadPenjualanAsync();
            }
        }
        private async Task UpdatePenjualanAsync()
        {
            try
            {
                var data = dbo.Penjualans.Where(e => e.ID_Penjualan.Equals(SelectedPenjualan.ID_Penjualan)).SingleOrDefault();
                if (data != null)
                {
                    data.ID_Barang = SelectedPenjualan.ID_Barang;
                    data.Tanggal = SelectedPenjualan.Tanggal;
                    data.Jumlah = SelectedPenjualan.Jumlah;
                    dbo.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan");
                }
                MessageBox.Show("Berhasil mengubah data");
            }
            catch
            {
                MessageBox.Show("Gagal update data");
            }
            finally
            {
                await Task.Delay(0);
            }
        }
        private async Task DeletePenjualanAsync()
        {
            try
            {
                var data = dbo.Penjualans.Where(e => e.ID_Penjualan.Equals(SelectedPenjualan.ID_Penjualan)).SingleOrDefault();
                if (data != null)
                {
                    dbo.Penjualans.Remove(data);
                    dbo.SaveChanges();
                    MessageBox.Show("Data berhasil dihapus");
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan");
                }
            }
            catch
            {
                MessageBox.Show("Gagal hapus data");
            }
            finally
            {
                await ReadPenjualanAsync();
            }
        }
    }
}
