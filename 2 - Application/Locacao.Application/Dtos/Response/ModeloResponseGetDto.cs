using System;

namespace Locacao.Application.Dtos
{
    public class ModeloResponseGetDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public FabricanteResponseGetDto Fabricante { get; set; }
    }
}