using Locacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locacao.Infrastructure.DataAccess.EntityMap
{
    public class ReservaMap : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder
                .ToTable("Reserva")
                .HasKey(x => x.Id);

            builder.Property(x => x.Data)
                .HasColumnType("date")
                .IsRequired(true);

            builder.Property(x => x.DataRetirada)
                .HasColumnType("date")
                .IsRequired(false);

            builder.Property(x => x.DataPrevistaDevolucao)
                .HasColumnType("date")
                .IsRequired(false);

            builder.Property(x => x.DataDevolucao)
                .HasColumnType("date")
                .IsRequired(false);


            builder.HasOne(x => x.Veiculo).WithMany().HasForeignKey(x => x.VeiculoId);

            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId);

        }
    }
}