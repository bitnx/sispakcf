namespace MainApp.Models
{
    public class Konsultasi
    {
        public int Id { get; set; }

        public DateTime Tanggal{ get; set; }

        public ICollection<Jawaban> GejalaPasien { get; set; } = new List<Jawaban>();

    }
}
