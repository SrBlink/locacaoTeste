using System;

namespace Locacao.Application.Dtos
{
    public class ReservaRequestPostDto : BaseRequestDto
    {
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }
        public DateTime? DataRetirada { get; set; }
        public DateTime? DataPrevistaDevolucao { get; set; }
    }
}
