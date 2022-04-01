using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Application.Dtos
{
    public  class VeiculoPostDto
    {
        public string Placa { get; set; }
        public Guid ModeloId { get; set; }
    }
}
