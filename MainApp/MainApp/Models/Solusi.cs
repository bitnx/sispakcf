namespace MainApp.Models
{
    public class Solusi
    {
        public int Id { get; set; }
        public string Nama { get; set; }

        public ICollection<Pengetahuan> BasisPengetahuan { get; set; }  = new List<Pengetahuan>();
    }
}
