using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Application.Dtos
{
    public class VeiculoResponseGetDto
    {
        public Guid? Id { get; set; }
        public string Placa { get; set; }
        public Guid ModeloId { get; set; }
        public ModeloResponseGetDto Modelo { get; set; }
    }
}
