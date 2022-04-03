using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Application.Dtos
{
    public class ReservaRequestPatchDto : BaseRequestDto
    {
        public DateTime DataRetirada { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
    }
}
