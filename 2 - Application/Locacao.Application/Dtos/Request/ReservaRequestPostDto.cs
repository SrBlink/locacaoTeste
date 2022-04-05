using System;

namespace Locacao.Application.Dtos
{
    public class ReservaRequestPostDto : BaseRequestDto
    {
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }
    }
}
