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
                    Id = new Guid("61d4e90e-6d25-4f7f-864c-431d95fbec68"),
                    Nome = "FIAT"
                },
                new Fabricante{
                    Id = new Guid("10f71d32-9501-4ba1-adbc-80627f206184"),
                    Nome = "VW"
                },
                new Fabricante{
                    Id = new Guid("6d0d79ba-e365-4a8a-839d-5e7860f5fce9"),
                    Nome = "FORD"
                },
                new Fabricante{
                    Id = new Guid("d764e865-1320-4f1f-8e45-89b85e799f75"),
                    Nome = "AUDI"
                },
                new Fabricante{
                    Id = new Guid("41f0ca61-e30a-44c0-9528-54c8c2da9c97"),
                    Nome = "MERCEDES"
                },
                new Fabricante{
                    Id = new Guid("3cf2a334-7be3-4aca-bb38-d3b5be815e95"),
                    Nome = "JEEP"
                },
            });
        }
    }
}