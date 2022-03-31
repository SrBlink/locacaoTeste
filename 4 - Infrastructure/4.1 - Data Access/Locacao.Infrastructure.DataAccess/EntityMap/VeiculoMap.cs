using Locacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Infrastructure.DataAccess.EntityMap
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder
                .ToTable("Veiculo")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Placa)
                .HasMaxLength(250)
                .IsRequired(true);

            builder.HasOne(x => x.Modelo).WithMany().HasForeignKey(x => x.ModeloId);

            builder.HasData(new Veiculo[] {
                new Veiculo{
                    Id = new Guid("737b2921-ae1a-4529-acd1-cf0c8ceec90d"),
                    ModeloId = new Guid("737b2921-ae1a-4529-acd1-cf0c8ceec90d"),
                    Placa = "EQU2520"
                }
            });
        }
    }
}
