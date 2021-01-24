using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ppe_foods.Models;

namespace ppe_foods.ViewModels
{
    public class KaryawanViewModel : BaseViewModel
    {
        public KaryawanViewModel()
        {
            datakaryawan = new ObservableCollection<Karyawan>();
            modelkaryawan = new Karyawan();

            CreateCommand = new Command(async () => await CreateKaryawanAsync());
            UpdateCommand = new Command(async () => await UpdateKaryawanAsync());
            DeleteCommand = new Command(async () => await DeleteKaryawanAsync());
            ReadCommand = new Command(async () => await ReadKaryawanAsync());
            ReadCommand.Execute(null);
        }
        public event Action OnReload;

        private DBFoodsEntities dbo = new DBFoodsEntities();
        public ICommand CreateCommand { get; set; }
        public ICommand ReadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private Karyawan modelkaryawan;
        public Karyawan ModelKaryawan
        {
            get { return modelkaryawan; }
            set { SetProperty(ref modelkaryawan, value); }
        }
        private Karyawan selectedkaryawan;
        public Karyawan SelectedKaryawan
        {
            get { return selectedkaryawan; }
            set { SetProperty(ref selectedkaryawan, value); }
        }

        private ObservableCollection<Karyawan> datakaryawan;
        public ObservableCollection<Karyawan> DataKaryawan
        {
            get{ return datakaryawan; }
            set{ SetProperty(ref datakaryawan, value); }
        }
        private async Task ReadKaryawanAsync()
        {
            try
            {
                DataKaryawan?.Clear();
                foreach (Karyawan karyawan in dbo.Karyawans)
                {
                    DataKaryawan.Add(karyawan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data");
            }
        }
        private async Task CreateKaryawanAsync()
        {
            try
            {
                dbo.Karyawans.Add(ModelKaryawan);
                dbo.SaveChanges();
                MessageBox.Show("Berhasil menambahkan data");
                ModelKaryawan = new Karyawan();
                OnReload?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambahkan data");
            }
            finally
            {
                await ReadKaryawanAsync();
            }
        }
        private async Task UpdateKaryawanAsync()
        {
            try
            {
                var data = dbo.Karyawans.Where(e => e.ID_Karyawan.Equals(SelectedKaryawan.ID_Karyawan)).SingleOrDefault();
                if (data != null)
                {
                    data.Nama = SelectedKaryawan.Nama;
                    data.Umur = SelectedKaryawan.Umur;
                    data.Telepon = SelectedKaryawan.Telepon;
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
        private async Task DeleteKaryawanAsync()
        {
            try
            {
                var data = dbo.Karyawans.Where(e => e.ID_Karyawan.Equals(SelectedKaryawan.ID_Karyawan)).SingleOrDefault();
                if (data != null)
                {
                    dbo.Karyawans.Remove(data);
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
                await ReadKaryawanAsync();
            }
        }
    }
}
