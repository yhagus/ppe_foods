using ppe_foods.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ppe_foods.ViewModels
{
    public class BarangViewModel : BaseViewModel
    {
        public BarangViewModel()
        {
            databarang = new ObservableCollection<Barang>();
            modelbarang = new Barang();

            CreateCommand = new Command(async () => await CreateBarangAsync());
            UpdateCommand = new Command(async () => await UpdateBarangAsync());
            DeleteCommand = new Command(async () => await DeleteBarangAsync());
            ReadCommand = new Command(async () => await ReadBarangAsync());
            ReadCommand.Execute(null);
        }
        public event Action OnReload;
        private DBFoodsEntities dbo = new DBFoodsEntities();
        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Barang modelbarang;
        public Barang ModelBarang
        {
            get { return modelbarang; }
            set { SetProperty(ref modelbarang, value); }
        }

        private Barang selectedbarang;
        public Barang SelectedBarang
        {
            get { return selectedbarang; }
            set { SetProperty(ref selectedbarang, value); }
        }

        private ObservableCollection<Barang> databarang;
        public ObservableCollection<Barang> DataBarang
        {
            get { return databarang; }
            set { SetProperty(ref databarang, value); }
        }
        private async Task ReadBarangAsync()
        {
            try
            {
                DataBarang?.Clear();
                foreach (Barang barang in dbo.Barangs)
                {
                    DataBarang.Add(barang);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data");
            }
        }
        private async Task CreateBarangAsync()
        {
            try
            {
                dbo.Barangs.Add(ModelBarang);
                dbo.SaveChanges();
                MessageBox.Show("Berhasil menambahkan data");
                ModelBarang = new Barang();
                OnReload?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambahkan data");
            }
            finally
            {
                await ReadBarangAsync();
            }
        }
        private async Task UpdateBarangAsync()
        {
            try
            {
                var data = dbo.Barangs.Where(e => e.ID_Barang.Equals(SelectedBarang.ID_Barang)).SingleOrDefault();
                if (data != null)
                {
                    data.Nama = SelectedBarang.Nama;
                    data.Harga = SelectedBarang.Harga;
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
        private async Task DeleteBarangAsync()
        {
            try
            {
                var data = dbo.Barangs.Where(e => e.ID_Barang.Equals(SelectedBarang.ID_Barang)).SingleOrDefault();
                if (data != null)
                {
                    dbo.Barangs.Remove(data);
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
                await ReadBarangAsync();
            }
        }
    }
}
