using Locacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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

            builder.HasData(new Cliente[]
            {
                new Cliente(){
                    Id = Guid.NewGuid(),
                    Nome = "Joao"
                }
            });
        }
    }
}
