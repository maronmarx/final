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

        public DbSet<Etudiants> etudiants { get; set; }
        public DbSet<Ville> villes { get; set; }  
        public DbSet<Etablissement> etablissements { get; set; }
        public DbSet<Filiere> filieres { get; set; }
        public DbSet<Formation> formations { get; set; }

    }
}


