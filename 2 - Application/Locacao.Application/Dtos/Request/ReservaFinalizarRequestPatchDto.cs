using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Application.Dtos
{
    public class ReservaFinalizarRequestPatchDto : BaseRequestDto
    {
        public DateTime DataDevolucao { get; set; }
    }
}
