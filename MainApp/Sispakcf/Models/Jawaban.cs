namespace Sispakcf.Models
{
    public class Jawaban
    {
        public int Id { get; set; }

        public Gejala Gejala { get; set; }

        public Pilihan NilaiPilihan { get; set; }


        public double NilaiAngka => GetNilaiAngka();

        private double GetNilaiAngka()
        {
            switch (NilaiPilihan)
            {
                case Pilihan.TidakPasti:
                    return -1;
                case Pilihan.HampirTidakPasti:
                    return -0.8;
                case Pilihan.KemungkinanTidak:
                    return -0.6;
                case Pilihan.MungkinTidak:
                    return -0.4;
                case Pilihan.TidakTahu:
                    return 0;
                case Pilihan.Mungkin:
                    return 0.4;
                case Pilihan.KemungkinanBesar:
                    return 0.6;
                case Pilihan.HampirPasti:
                    return 0.8;
                case Pilihan.Pasti:
                    return 1;
                default:
                   return 0;
            }
        }
    }



    public enum Pilihan
    {
        TidakPasti,
        HampirTidakPasti,
        KemungkinanTidak,
        MungkinTidak,
        TidakTahu,
        Mungkin,
        KemungkinanBesar,
        HampirPasti,
        Pasti,
        None

    }
}
