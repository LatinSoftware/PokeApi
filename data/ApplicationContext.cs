using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PokeApi.Domain;

namespace PokeApi.data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Domain.Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=database-2.cjii1wwtuye6.us-east-2.rds.amazonaws.com,1433;Database=Pokemons;User Id=;Password=;integrated security=false;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}