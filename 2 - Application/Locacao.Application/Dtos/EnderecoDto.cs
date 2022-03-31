using System;
using System.Collections.Generic;
using System.Text;

namespace Locacao.Application.Dtos
{
    public class EnderecoDto
    {
        public string Logradouro { get; set; }
        public string NumeroResidencia { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
