using System;

namespace Locacao.Application.Dtos
{
    public class VeiculoResponseGetDto
    {
        public Guid? Id { get; set; }
        public string Placa { get; set; }
        public ModeloResponseGetDto Modelo { get; set; }
    }
}
