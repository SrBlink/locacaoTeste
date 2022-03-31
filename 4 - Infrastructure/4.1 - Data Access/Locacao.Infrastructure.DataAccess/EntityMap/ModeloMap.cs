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
                    Id = new Guid("737b2921-ae1a-4529-acd1-cf0c8ceec90d"),
                    FabricanteId = new Guid("6d0d79ba-e365-4a8a-839d-5e7860f5fce9"),
                    Nome = "ModelT"
                }
            });
        }
    }
}