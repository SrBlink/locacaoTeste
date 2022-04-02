using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Application.Dtos
{
    public class ModeloResponseGetDto
    {
        public string Nome { get; set; }

        public Guid FabricanteId { get; set; }

        public FabricanteResponseGetDto Fabricante { get; set; }
    }
}
