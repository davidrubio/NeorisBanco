using Microsoft.EntityFrameworkCore;
using Neoris.Models;

namespace Neoris.Cliente.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Neoris.Models.Cliente>().HasKey(c => c.Secuencial);
            modelBuilder.Entity<Neoris.Models.Genero>().HasKey(c => c.Secuencial);
            modelBuilder.Entity<Neoris.Models.Persona>().HasKey(c => c.Secuencial);
        }
        public DbSet<Neoris.Models.Cliente> Cliente { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Persona> Persona { get; set; }
    }
}
