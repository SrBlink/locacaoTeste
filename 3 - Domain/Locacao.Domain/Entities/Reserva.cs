using System;

namespace Locacao.Domain.Entities
{
    public class Reserva : BaseEntity
    {
        public DateTime Data { get; set; }
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }
        public DateTime? DataRetirada { get; set; }
        public DateTime? DataPrevistaDevolucao { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Veiculo Veiculo { get; set; }

    }
}
