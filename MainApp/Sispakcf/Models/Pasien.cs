using CommunityToolkit.Mvvm.ComponentModel;

namespace Sispakcf.Models
{
    public partial class Pasien:ObservableObject
    {
        public int Id { get; set; }
        
        [ObservableProperty]
        private string nama;
        
        [ObservableProperty]
        private string email;
        
        [ObservableProperty]
        private string alamat;
        
        [ObservableProperty]
        private DateTime tanggalLahir;
        
        [ObservableProperty]
        private string pekerjaan;
        
        [ObservableProperty]
        private string telepon;
        public int Umur => DateTime.Now.Year - TanggalLahir.Year;
        public ICollection<Konsultasi> Konsultasi { get; set; } = new List<Konsultasi>();
        public string? UserId { get; set; } 

    }
}
