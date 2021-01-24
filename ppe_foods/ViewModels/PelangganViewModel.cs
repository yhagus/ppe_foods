using ppe_foods.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ppe_foods.ViewModels
{
    public class PelangganViewModel : BaseViewModel
    {
        public PelangganViewModel()
        {
            datapelanggan = new ObservableCollection<Pelanggan>();
            modelpelanggan = new Pelanggan();

            CreateCommand = new Command(async () => await CreatePelangganAsync());
            UpdateCommand = new Command(async () => await UpdatePelangganAsync());
            DeleteCommand = new Command(async () => await DeletePelangganAsync());
            ReadCommand = new Command(async () => await ReadPelangganAsync());
            ReadCommand.Execute(null);
        }
        public event Action OnReload;
        private DBFoodsEntities dbo = new DBFoodsEntities();
        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Pelanggan modelpelanggan;
        public Pelanggan ModelPelanggan
        {
            get { return modelpelanggan; }
            set { SetProperty(ref modelpelanggan, value); }
        }
        private ObservableCollection<Pelanggan> datapelanggan;

        public ObservableCollection<Pelanggan> DataPelanggan
        {
            get { return datapelanggan; }
            set { SetProperty(ref datapelanggan, value); }
        }
        private Pelanggan selectedpelanggan;

        public Pelanggan SelectedPelanggan
        {
            get { return selectedpelanggan; }
            set { SetProperty(ref selectedpelanggan, value); }
        }

        private async Task ReadPelangganAsync()
        {
            try
            {
                DataPelanggan?.Clear();
                foreach (Pelanggan pelanggan in dbo.Pelanggans)
                {
                    DataPelanggan.Add(pelanggan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data");
            }
        }
        private async Task CreatePelangganAsync()
        {
            try
            {
                dbo.Pelanggans.Add(ModelPelanggan);
                dbo.SaveChanges();
                MessageBox.Show("Berhasil menambahkan data");
                ModelPelanggan = new Pelanggan();
                OnReload?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambahkan data");
            }
            finally
            {
                await ReadPelangganAsync();
            }
        }
        private async Task UpdatePelangganAsync()
        {
            try
            {
                var data = dbo.Pelanggans.Where(e => e.ID_Pelanggan.Equals(SelectedPelanggan.ID_Pelanggan)).SingleOrDefault();
                if (data != null)
                {
                    data.Nama = SelectedPelanggan.Nama;
                    data.Telepon = SelectedPelanggan.Telepon;
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
        private async Task DeletePelangganAsync()
        {
            try
            {
                var data = dbo.Pelanggans.Where(e => e.ID_Pelanggan.Equals(SelectedPelanggan.ID_Pelanggan)).SingleOrDefault();
                if (data != null)
                {
                    dbo.Pelanggans.Remove(data);
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
                await ReadPelangganAsync();
            }
        }
    }
}
