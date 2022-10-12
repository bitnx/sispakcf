using MainApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MainApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Gejala>  Gejala { get; set; }
        public DbSet<Pasien>  Pasien { get; set; }
        public DbSet<Solusi> Solusi { get; set; }
    }
}