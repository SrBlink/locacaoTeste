using Locacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Locacao.Infrastructure.DataAccess.EntityMap
{
    public class ModeloMap : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder
                .ToTable("Modelo")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Nome)
                .HasMaxLength(250)
                .IsRequired(true);

            builder.HasOne(x => x.Fabricante).WithMany().HasForeignKey(x => x.FabricanteId);

            builder.HasData(new Modelo[] {
                new Modelo{
                    Id = Guid.NewGuid(),
                    FabricanteId = new Guid("61d4e90e-6d25-4f7f-864c-431d95fbec68"),
                    Nome = "UNO"
                },
                new Modelo{
                    Id = Guid.NewGuid(),
                    FabricanteId = new Guid("10f71d32-9501-4ba1-adbc-80627f206184"),
                    Nome = "AMAROK"
                },
                new Modelo{
                    Id = new Guid("737b2921-ae1a-4529-acd1-cf0c8ceec90d"),
                    FabricanteId = new Guid("6d0d79ba-e365-4a8a-839d-5e7860f5fce9"),
                    Nome = "AEROSTAR"
                },
                new Modelo{
                    Id = Guid.NewGuid(),
                    FabricanteId = new Guid("d764e865-1320-4f1f-8e45-89b85e799f75"),
                    Nome = "R8 GT SPYDER"
                },
                new Modelo{
                    Id = Guid.NewGuid(),
                    FabricanteId = new Guid("41f0ca61-e30a-44c0-9528-54c8c2da9c97"),
                    Nome = "CITAN"
                },
                new Modelo{
                    Id = Guid.NewGuid(),
                    FabricanteId = new Guid("3cf2a334-7be3-4aca-bb38-d3b5be815e95"),
                    Nome = "CHEROKEE"
                },

            });
        }
    }
}
