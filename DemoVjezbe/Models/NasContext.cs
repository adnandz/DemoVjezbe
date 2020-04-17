using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoVjezbe.Models
{
    public class NasContext: DbContext
    {
        public NasContext (DbContextOptions<NasContext> options): base (options)
        {
        }

        public DbSet<Automobil> Automobil { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Automobil>().ToTable("Automobil");
            modelBuilder.Entity<Proizvodjac>().ToTable("Proizvodjac");
        }
    }
}
