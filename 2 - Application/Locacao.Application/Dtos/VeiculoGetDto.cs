using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Application.Dtos
{
    public class VeiculoGetDto
    {
        public Guid? Id { get; set; }
        public string Placa { get; set; }
        public Guid ModeloId { get; set; }
        public ModeloDto Modelo { get; set; }
    }
}
