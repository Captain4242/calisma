using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class VeritabaniBag:DbContext
    {
        string baglantiCumlesi = "Server=.; Database=ders_vt; Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(baglantiCumlesi);
        }
        public DbSet<Ders> Dersler { get; set; }
    }
}
