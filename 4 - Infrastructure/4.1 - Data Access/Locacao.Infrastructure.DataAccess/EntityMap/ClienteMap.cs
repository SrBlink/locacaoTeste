using Locacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Locacao.Infrastructure.DataAccess.EntityMap
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable("Cliente")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Nome)
                .HasMaxLength(250)
                .IsRequired(true);

            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsRequired(true);

            builder.Property(x => x.DataNascimento)
                .HasColumnType("date")
                .IsRequired(true);

            builder.Property(x => x.Cnh)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(x => x.Logradouro)
                .HasMaxLength(60)
                .IsRequired(true);

            builder.Property(x => x.Bairro)
                .HasMaxLength(60)
                .IsRequired(true);

            builder.Property(x => x.NumeroResidencia)
                .HasMaxLength(10)
                .IsRequired(true);

            builder.Property(x => x.Cidade)
                .HasMaxLength(250)
                .IsRequired(true);

        }
    }
}