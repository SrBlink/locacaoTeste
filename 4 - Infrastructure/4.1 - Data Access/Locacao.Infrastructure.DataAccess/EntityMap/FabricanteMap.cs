using Locacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Locacao.Infrastructure.DataAccess.EntityMap
{
    public class FabricanteMap : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder
               .ToTable("Fabricante")
               .HasKey(x => x.Id);

            builder
                .Property(x => x.Nome)
                .HasMaxLength(250);

            builder.HasData(new Fabricante[] {
                new Fabricante{
                    Id = Guid.NewGuid(),
                    Nome = "FIAT"
                },
                new Fabricante{
                    Id = Guid.NewGuid(),
                    Nome = "VW"
                },
                new Fabricante{
                    Id = new Guid("6d0d79ba-e365-4a8a-839d-5e7860f5fce9"),
                    Nome = "FORD"
                },
                new Fabricante{
                    Id = Guid.NewGuid(),
                    Nome = "AUDI"
                },
                new Fabricante{
                    Id = Guid.NewGuid(),
                    Nome = "MERCEDES"
                },
                new Fabricante{
                    Id = Guid.NewGuid(),
                    Nome = "JEEP"
                },
            });
        }
    }
}