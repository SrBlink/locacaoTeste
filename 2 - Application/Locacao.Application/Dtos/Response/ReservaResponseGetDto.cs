using System;

namespace Locacao.Application.Dtos
{
    public class ReservaResponseGetDto
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public Guid ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public Guid VeiculoId { get; set; }
        public string VeiculoPlaca { get; set; }
        public DateTime? DataRetirada { get; set; }
        public DateTime? DataPrevistaDevolucao { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}