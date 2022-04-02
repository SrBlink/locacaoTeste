using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Application.Dtos
{
    public  class VeiculoRequestPostDto : BaseRequestDto
    {
        public string Placa { get; set; }
        public Guid ModeloId { get; set; }
    }
}
