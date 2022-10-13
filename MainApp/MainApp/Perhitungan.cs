using MainApp.Data;
using MainApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Diagnostics;

namespace MainApp
{
    public class Perhitungan
    {
        private ApplicationDbContext dbcontext;

        public Perhitungan(ApplicationDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public IEnumerable<Hasil> Hitung(List<Jawaban> jawabans)
        {
            var odds = new ArrayList();
            ICollection<Hasil> hasils = new  List<Hasil>();
            var solusis = dbcontext.Solusi.Include(x => x.BasisPengetahuan).ThenInclude(x => x.Gejala).ToList();
            foreach (var solusi in solusis)
            {
                double odd = 0;
                double lastgIndex = 0;
                var gindexes = new ArrayList();
                Debug.WriteLine($"S{solusi.Id}");
                for (int index = 0; index < solusi.BasisPengetahuan.Count; index++)
                {
                    var g = solusi.BasisPengetahuan.ToArray()[index];
                    double bobot = 0;
                    var jawab = jawabans.FirstOrDefault(x => x.Gejala.Id == g.Id);
                    if (jawab != null)
                    {
                        bobot = jawab.NilaiAngka;
                    }

                    var gindex = g.CF * bobot;
                    gindexes.Add(gindex);
                    if(index <= 0)
                    {
                        lastgIndex = gindex;
                        Debug.WriteLine($"Cf{index+1}= {gindex}");
                    }
                    else if (index == 1)
                    {
                        odd = lastgIndex + gindex * (1 - lastgIndex);
                        Debug.WriteLine($"Cf{index+1}= {lastgIndex}+{gindex} * ({1}-{lastgIndex})");
                    }  else if (index > 1)
                    {
                        odd = odd+gindex *(1-odd);
                        Debug.WriteLine($"Cf{index+1}= {odd}+{gindex} * ({1}-{odd})");
                    }

                }
                //solusi.odd = odd;
                Debug.WriteLine($"S1 ={odd}");
                Debug.WriteLine($"\r\r");
                odds.Add(odd);
                hasils.Add(new Hasil(solusi, odd));
            }
            return hasils;
        }
    }
}
