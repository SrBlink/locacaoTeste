using System;

namespace Locacao.Application.Dtos
{
    public class ReservaFinalizarRequestPatchDto : BaseRequestDto
    {
        public DateTime DataDevolucao { get; set; }
    }
}
