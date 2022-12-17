using Microsoft.EntityFrameworkCore;
using FinalOr.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinalOr.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Etablissement>()

                  .HasForeignKey(e => e.id_formation)
                  .WillCascadeOnDelete(false);

            modelBuilder.Entity<Etablissement>()
                  .HasForeignKey(f => f.id_filier)
                  .WillCascadeOnDelete(false);
            modelBuilder.Entity<Etablissement>()
                  .HasForeignKey(v => v.id_ville)
                  .WillCascadeOnDelete(false);*/

            base.OnModelCreating(modelBuilder);
            
        }
        public DbSet<Etudiants> etudiants { get; set; }
        public DbSet<Ville> villes { get; set; }  
        public DbSet<Etablissement> etablissements { get; set; }
        public DbSet<Filiere> filieres { get; set; }
        public DbSet<Formation> formations { get; set; }

    }
}


