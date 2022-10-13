namespace Sispakcf.Models
{
    public class Hasil
    {
        public Hasil() { }
        public int SolusiId { get; set; }
        public string Nama { get; set; }
        public double Nilai { get; set; }

        public Hasil(Solusi solusi, double odd)
        {
            SolusiId = solusi.Id;
            Nama = solusi.Nama;
            Nilai = odd;
        }
    }
}
