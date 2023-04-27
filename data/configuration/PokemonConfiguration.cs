using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeApi.Domain;

namespace PokeApi.data.configuration
{
    public class PokemonConfiguration : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.ToTable("Pokemons");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Order).IsRequired();
            builder.Property(p => p.Weight).IsRequired();
            builder.Property(p => p.Height).IsRequired();
            builder.HasMany(p => p.Types).WithMany(t => t.Pokemons);
            builder.HasMany(p => p.Abilities).WithOne(a => a.Pokemon);

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}