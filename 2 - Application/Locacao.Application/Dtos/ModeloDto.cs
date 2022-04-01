using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Application.Dtos
{
    public class ModeloDto
    {
        public string Nome { get; set; }

        public Guid FabricanteId { get; set; }

        public FabricanteDto Fabricante { get; set; }
    }
}
