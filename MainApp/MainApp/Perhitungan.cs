using MainApp.Data;
using MainApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Diagnostics;

namespace MainApp
{

    public class PreparePerhitungan
    {
        public PreparePerhitungan()
        {
            var jawabPasien = new List<Jawaban>() {  
            new Jawaban(){ NilaiPilihan = Pilihan.HampirPasti, Gejala= new Gejala{ Id = 1} },
            new Jawaban(){ NilaiPilihan = Pilihan.Pasti, Gejala= new Gejala{ Id = 2} },
            new Jawaban(){ NilaiPilihan = Pilihan.TidakPasti, Gejala= new Gejala{ Id = 4} },
            };    
        }
        


    }



    public class Perhitungan
    {
        private ApplicationDbContext dbcontext;

        public Perhitungan(ApplicationDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public ArrayList Hitung(List<Jawaban> jawabans)
        {
            var odds = new ArrayList();
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
            }

            return odds;
        }
    }
}
