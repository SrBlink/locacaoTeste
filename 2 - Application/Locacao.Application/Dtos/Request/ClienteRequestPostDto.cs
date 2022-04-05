using System;

namespace Locacao.Application.Dtos
{
    public class ClienteRequestPostDto : BaseRequestDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cnh { get; set; }
        public string Logradouro { get; set; }
        public string NumeroResidencia { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}