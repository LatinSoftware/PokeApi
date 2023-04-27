using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PokeApi.data.configuration
{
    public class TypeConfiguration : IEntityTypeConfiguration<Domain.Type>
    {
        public void Configure(EntityTypeBuilder<Domain.Type> builder)
        {
            builder.ToTable("Types");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}