namespace MainApp.Models
{
    public class Pasien
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Alamat { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string Pekerjaan { get; set; }
        public string Telepon { get; set; }
        public int Umur => DateTime.Now.Year - TanggalLahir.Year;
        public ICollection<Konsultasi> Konsultasi { get; set; }   =new List<Konsultasi>();
        public string? UserId { get; set; }

    }
}
