using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionJDR.Data;

namespace GestionJDR.Data
{
    public class GestionJDRContext : DbContext
    {
        public GestionJDRContext (DbContextOptions<GestionJDRContext> options)
            : base(options)
        {
        }

        public DbSet<Joueur> Joueurs { get; set; }
        public DbSet<Possede> Possedent { get; set; }
        public DbSet<Personnage> Personnages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personnage>().ToTable("Personnage");
            modelBuilder.Entity<Possede>().ToTable("Possede");
            modelBuilder.Entity<Joueur>().ToTable("Joueur");
        }
    }
}
